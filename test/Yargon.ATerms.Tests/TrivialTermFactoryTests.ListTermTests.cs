using System.Collections.Generic;
using NUnit.Framework;

namespace Yargon.ATerms
{
	partial class TrivialTermFactoryTests
	{
		[TestFixture]
		public sealed class ListTermTests : TestBase
		{
			#region SUT
			public TrivialTermFactory.ListTerm CreateSUT(IEnumerable<ITerm> terms)
			{
				return (TrivialTermFactory.ListTerm)Factory.List(terms);
			}

			public sealed class ListTerm_IListTerm : IListTermTests
			{
				public override IListTerm CreateSUT(IEnumerable<ITerm> terms)
				{
					return new ListTermTests().CreateSUT(terms);
				}
			}
			#endregion
		}
	}
}
