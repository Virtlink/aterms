using Xunit;

namespace Yargon.ATerms.Tests
{
    /// <summary>
    /// Tests the <see cref="TrivialTermFactory"/> class.
    /// </summary>
	public sealed partial class TrivialTermFactoryTests
	{
		#region SUT
		public TrivialTermFactory CreateSUT()
		{
			return new TrivialTermFactory();
		}
        
		public sealed class TrivialTermFactory_TermFactory : TermFactoryTests
		{
			public override TermFactory CreateSUT()
			{
				return new TrivialTermFactoryTests().CreateSUT();
			}
		}
		#endregion
	}
}
