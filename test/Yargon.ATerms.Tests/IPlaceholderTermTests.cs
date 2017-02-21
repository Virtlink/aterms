using Xunit;
using Moq;

namespace Yargon.ATerms
{
    /// <summary>
    /// Tests the <see cref="IPlaceholderTerm"/> interface.
    /// </summary>
    public abstract class IPlaceholderTermTests : TestBase
	{
		/// <summary>
		/// Creates the Subject Under Test.
		/// </summary>
		/// <param name="template">The template of the placeholder.</param>
		/// <returns>The instance to test.</returns>
		public abstract IPlaceholderTerm CreateSUT(ITerm template);

		[Fact]
		public void HasExpectedPropertyValues()
		{
			// Arrange
			var template = Factory.Int(0);
			var sut = CreateSUT(template);

			// Assert
			Assert.Equal(new ITerm[] { template }, sut.SubTerms);
			Assert.Empty(sut.Annotations);
		}

		[Fact]
		public void ToStringReturnsAString()
		{
			// Arrange
			var template = Factory.Int(0);
			var sut = CreateSUT(template);

			// Act
			var result = sut.ToString();

			// Assert
			Assert.Equal("<0>", result);
		}

		[Fact]
		public void TwoEqualTermsAreEqual()
		{
			// Arrange
			var template = Factory.Int(0);
			var sut = CreateSUT(template);
			var other = CreateSUT(template);

			// Act
			var result = sut.Equals(other);

			// Assert
			Assert.True(result);
		}

		[Fact]
		public void TwoDifferentTermsAreDifferent()
		{
			// Arrange
			var template0 = Factory.Int(0);
			var template1 = Factory.Int(1);
			var sut = CreateSUT(template0);
			var other = CreateSUT(template1);

			// Act
			var result = sut.Equals(other);

			// Assert
			Assert.False(result);
		}

		[Fact]
		public void CallsVisitorMethod()
		{
			// Arrange
			var sut = CreateSUT(Factory.Int(0));
			var visitor = new Mock<ITermVisitor>();

			// Act
			sut.Accept(visitor.Object);

			// Assert
			visitor.Verify(v => v.VisitPlaceholder(sut));
		}
	}
}
