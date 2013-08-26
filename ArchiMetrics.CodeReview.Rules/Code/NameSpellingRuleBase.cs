// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NameSpellingRuleBase.cs" company="Reimers.dk">
//   Copyright � Reimers.dk 2012
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the NameSpellingRuleBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArchiMetrics.CodeReview.Rules.Code
{
	using System;
	using System.Linq;
	using System.Text.RegularExpressions;
	using ArchiMetrics.Common.CodeReview;

	internal abstract class NameSpellingRuleBase : CodeEvaluationBase
	{
		private readonly IKnownPatterns _knownPatterns;
		private readonly ISpellChecker _speller;

		public NameSpellingRuleBase(ISpellChecker speller, IKnownPatterns knownPatterns)
		{
			_speller = speller;
			_knownPatterns = knownPatterns;
		}

		protected bool IsSpelledCorrectly(string name)
		{
			var wordParts = name.ToTitleCase()
				.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
				.Where(s => !_knownPatterns.IsExempt(s));
			return wordParts.Aggregate(true, (b, s) => b && _speller.Spell(s));
		}
	}
}