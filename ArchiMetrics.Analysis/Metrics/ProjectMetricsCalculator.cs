// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectMetricsCalculator.cs" company="Reimers.dk">
//   Copyright � Reimers.dk 2014
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the ProjectMetricsCalculator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArchiMetrics.Analysis.Metrics
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using ArchiMetrics.Common;
	using ArchiMetrics.Common.Metrics;
	using Microsoft.CodeAnalysis;

	internal class ProjectMetricsCalculator : IProjectMetricsCalculator
	{
		private readonly ICodeMetricsCalculator _metricsCalculator;

		public ProjectMetricsCalculator(ICodeMetricsCalculator metricsCalculator)
		{
			_metricsCalculator = metricsCalculator;
		}

		public async Task<IEnumerable<IProjectMetric>> Calculate(Solution solution)
		{
			var tasks = (from project in solution.Projects
						 where project != null
						 let compilation = project.GetCompilationAsync()
						 select new { project, compilation })
						.AsArray();

			await Task.WhenAll(tasks.Select(x => x.compilation)).ConfigureAwait(false);

			var calculationTasks = tasks.Select(x => InnerCalculate(x.project, x.compilation, solution));

			return await Task.WhenAll(calculationTasks).ConfigureAwait(false);
		}

		public async Task<IProjectMetric> Calculate(Project project, Solution solution)
		{
			if (project == null)
			{
				return null;
			}

			var compilation = project.GetCompilationAsync();
			return await InnerCalculate(project, compilation, solution).ConfigureAwait(false);
		}

		private async Task<IProjectMetric> InnerCalculate(Project project, Task<Compilation> compilationTask, Solution solution)
		{
			if (project == null)
			{
				return null;
			}

			var compilation = await compilationTask.ConfigureAwait(false);
			var metricsTask = _metricsCalculator.Calculate(project, solution);

			IEnumerable<string> dependencies;
			if (solution != null)
			{
				var dependencyGraph = solution.GetProjectDependencyGraph();

				dependencies = dependencyGraph.GetProjectsThatThisProjectTransitivelyDependsOn(project.Id)
					.Select<ProjectId, Project>(id => solution.GetProject(id))
					.SelectMany(x => x.MetadataReferences.Select(y => y.Display).Concat(new[] { x.AssemblyName }));
			}
			else
			{
				dependencies = project.AllProjectReferences.SelectMany(x => x.Aliases)
					.Concat(project.MetadataReferences.Select(y => y.Display));
			}

			var assemblyTypes = compilation.Assembly.TypeNames;
			var metrics = (await metricsTask.ConfigureAwait(false)).AsArray();
			
			var internalTypesUsed = from metric in metrics
									from coupling in metric.ClassCouplings
									where coupling.Assembly == project.AssemblyName
									select coupling;

			var relationalCohesion = (internalTypesUsed.Count() + 1.0) / assemblyTypes.Count;

			return new ProjectMetric(project.Name, metrics, dependencies, relationalCohesion);
		}
	}
}