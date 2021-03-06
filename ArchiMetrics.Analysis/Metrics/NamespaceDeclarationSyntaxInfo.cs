// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NamespaceDeclarationSyntaxInfo.cs" company="Reimers.dk">
//   Copyright � Reimers.dk 2014
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the NamespaceDeclarationSyntaxInfo type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArchiMetrics.Analysis.Metrics
{
	using Microsoft.CodeAnalysis;

	public sealed class NamespaceDeclarationSyntaxInfo
	{
		public string CodeFile { get; set; }

		public string Name { get; set; }

		public SyntaxNode Syntax { get; set; }
	}
}
