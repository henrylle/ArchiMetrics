// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAvailableRules.cs" company="Reimers.dk">
//   Copyright � Reimers.dk 2013
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the IAvailableRules type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArchiMetrics.Common
{
	using System;
	using System.Collections.Generic;
	using System.Collections.Specialized;
	using ArchiMetrics.Common.CodeReview;

	public interface IAvailableRules : IEnumerable<IEvaluation>, INotifyCollectionChanged, IDisposable
	{
		IEnumerable<IAvailability> Availabilities { get; }
	}
}