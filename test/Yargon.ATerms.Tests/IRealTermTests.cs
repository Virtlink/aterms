using Moq;
using Xunit;

namespace Yargon.ATerms
{
    /// <summary>
    /// Tests the <see cref="IRealTerm"/> interface.
    /// </summary>
    public abstract class IRealTermTests : TestBase
	{
		/// <summary>
		/// Creates the Subject Under Test.
		/// </summary>
		/// <param name="value">The value of the term.</param>
		/// <returns>The instance to test.</returns>
		public abstract IRealTerm CreateSUT(float value);

		[Fact]
		public void HasExpectedPropertyValues()
		{
			// Arrange
			const float value = 4.2f;
			var sut = CreateSUT(value);

			// Assert
			Assert.Equal(value, sut.Value);
			Assert.Empty(sut.Annotations);
			Assert.Empty(sut.SubTerms);
		}

		[Fact]
		public void ToStringReturnsAString()
		{
			// Arrange
			const float value = 4.2f;
			var sut = CreateSUT(value);

			// Act
			var result = sut.ToString();

			// Assert
			Assert.Equal("4.2", result);
		}

		[Fact]
		public void TwoEqualTermsAreEqual()
		{
			// Arrange
			const float value = 4.2f;
			var sut = CreateSUT(value);
			var other = CreateSUT(value);

			// Act
			var result = sut.Equals(other);

			// Assert
			Assert.True(result);
		}

		[Fact]
		public void TwoDifferentTermsAreDifferent()
		{
			// Arrange
			const float value = 4.2f;
			const float otherValue = 2.4f;
			var sut = CreateSUT(value);
			var other = CreateSUT(otherValue);

			// Act
			var result = sut.Equals(other);

			// Assert
			Assert.False(result);
		}

		[Fact]
		public void CallsVisitorMethod()
		{
			// Arrange
			var sut = CreateSUT(4.2f);
			var visitor = new Mock<ITermVisitor>();

			// Act
			sut.Accept(visitor.Object);

			// Assert
			visitor.Verify(v => v.VisitReal(sut));
		}
	}
}
