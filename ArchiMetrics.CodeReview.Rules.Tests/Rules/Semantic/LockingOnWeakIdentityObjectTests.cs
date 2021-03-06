﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LockingOnWeakIdentityObjectTests.cs" company="Reimers.dk">
//   Copyright © Reimers.dk 2014
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the LockingOnWeakIdentityObjectTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArchiMetrics.CodeReview.Rules.Tests.Rules.Semantic
{
	using System.Linq;
	using System.Threading.Tasks;
	using ArchiMetrics.Analysis;
	using ArchiMetrics.CodeReview.Rules.Semantic;
	using ArchiMetrics.Common.CodeReview;
	using NUnit.Framework;

	public sealed class LockingOnWeakIdentityObjectTests
	{
		private LockingOnWeakIdentityObjectTests()
		{
		}

		public class GivenALockingOnWeakIdentityObjectRule : SolutionTestsBase
		{
			private NodeReviewer _inspector;

			[SetUp]
			public void Setup()
			{
				_inspector = new NodeReviewer(new[] { new LockingOnWeakIdentityObjectRule() }, Enumerable.Empty<ISymbolEvaluation>());
			}

			[TestCase(@"namespace MyNS
{
	public class MyClass
	{
		private string lockObject = ""text"";

		public int MyMethod()
		{
			lock(lockObject)
			{
				return 1;
			}
		}
	}
}")]
			[TestCase(@"namespace MyNS
{
	using System;

	public class MyClass
	{
		private string lockObject = ""text"";

		public int MyMethod()
		{
			lock(lockObject)
			{
				return 1;
			}
		}
	}
}")]
			[TestCase(@"namespace MyNS
{
	public class MyClass
	{
		private System.Threading.Thread lockObject = new System.Threading.Thread();

		public int MyMethod()
		{
			lock(lockObject)
			{
				return 1;
			}
		}
	}
}")]
			[TestCase(@"namespace MyNS
{
	using System.Threading;

	public class MyClass
	{
		private Thread lockObject = new Thread();

		public int MyMethod()
		{
			lock(lockObject)
			{
				return 1;
			}
		}
	}
}")]
			[TestCase(@"namespace MyNS
{
	public class MyClass
	{
		private System.ExecutionEngineException lockObject = new System.ExecutionEngineException();

		public int MyMethod()
		{
			lock(lockObject)
			{
				return 1;
			}
		}
	}
}")]
			[TestCase(@"namespace MyNS
{
	using System;

	public class MyClass
	{
		private ExecutionEngineException lockObject = new ExecutionEngineException();

		public int MyMethod()
		{
			lock(lockObject)
			{
				return 1;
			}
		}
	}
}")]
			[TestCase(@"namespace MyNS
{
	public class MyClass
	{
		private System.OutOfMemoryException lockObject = new System.OutOfMemoryException();

		public int MyMethod()
		{
			lock(lockObject)
			{
				return 1;
			}
		}
	}
}")]
			[TestCase(@"namespace MyNS
{
	using System;

	public class MyClass
	{
		private OutOfMemoryException lockObject = new OutOfMemoryException();

		public int MyMethod()
		{
			lock(lockObject)
			{
				return 1;
			}
		}
	}
}")]
			[TestCase(@"namespace MyNS
{
	public class MyClass
	{
		private System.StackOverflowException lockObject = new System.StackOverflowException();

		public int MyMethod()
		{
			lock(lockObject)
			{
				return 1;
			}
		}
	}
}")]
			[TestCase(@"namespace MyNS
{
	using System;

	public class MyClass
	{
		private StackOverflowException lockObject = new StackOverflowException();

		public int MyMethod()
		{
			lock(lockObject)
			{
				return 1;
			}
		}
	}
}")]
			public async Task WhenLockingOnWeakIdentityObjectThenReturnsFinding(string code)
			{
				var solution = CreateSolution(code);
				var finding = await _inspector.Inspect(solution);

				CollectionAssert.IsNotEmpty(finding);
			}
		}
	}
}