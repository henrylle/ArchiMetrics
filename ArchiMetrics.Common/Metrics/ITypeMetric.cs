// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITypeMetric.cs" company="Reimers.dk">
//   Copyright � Reimers.dk 2014
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the ITypeMetric type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArchiMetrics.Common.Metrics
{
	using System.Collections.Generic;

	public interface ITypeMetric : ICodeMetric
	{
		AccessModifierKind AccessModifier { get; }

		TypeMetricKind Kind { get; }

		IEnumerable<IMemberMetric> MemberMetrics { get; }

		int DepthOfInheritance { get; }

		int ClassCoupling { get; }
		
		int AfferentCoupling { get; }

		int EfferentCoupling { get; }

		double Instability { get; }

		bool IsAbstract { get; }

		ITypeDocumentation Documentation { get; }
	}
}