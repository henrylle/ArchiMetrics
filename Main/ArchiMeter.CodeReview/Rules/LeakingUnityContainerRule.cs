﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LeakingUnityContainerRule.cs" company="Roche">
//   Copyright © Roche 2012
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993] for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the LeakingUnityContainerRule type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArchiMeter.CodeReview.Rules
{
	internal class LeakingUnityContainerRule : LeakingTypeRule
	{
		protected override string TypeIdentifier
		{
			get
			{
				return "UnityContainer";
			}
		}
	}
}