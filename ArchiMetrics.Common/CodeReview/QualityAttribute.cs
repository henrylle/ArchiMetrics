// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QualityAttribute.cs" company="Reimers.dk">
//   Copyright � Reimers.dk 2014
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the QualityAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArchiMetrics.Common.CodeReview
{
	using System;

	[Flags]
	public enum QualityAttribute
	{
		CodeQuality = 1, 
		Maintainability = 2, 
		Testability = 4, 
		Modifiability = 8, 
		Reusability = 16, 
		Conformance = 32, 
		Security = 64,
		Performance = 128
	}
}
