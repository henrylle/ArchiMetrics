// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IKnownPatterns.cs" company="Reimers.dk">
//   Copyright � Reimers.dk 2014
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the IKnownPatterns type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArchiMetrics.Common.CodeReview
{
	using System.Collections.Generic;

	public interface IKnownPatterns : IEnumerable<string>
	{
		bool IsExempt(string word);

		void Add(params string[] patterns);

		void Remove(string pattern);

		void Clear();
	}
}
