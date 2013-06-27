// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LeakingSessionRule.cs" company="Reimers.dk">
//   Copyright � Reimers.dk 2012
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993] for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the LeakingSessionRule type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArchiMetrics.CodeReview.Rules
{
	internal class LeakingSessionRule : LeakingTypeRule
	{
		protected override string TypeIdentifier
		{
			get
			{
				return "ISession";
			}
		}
	}
}