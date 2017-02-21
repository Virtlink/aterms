using Xunit;
using Moq;

namespace Yargon.ATerms
{
    /// <summary>
    /// Tests the <see cref="IIntTerm"/> interface.
    /// </summary>
    public abstract class IIntTermTests : TestBase
	{
		/// <summary>
		/// Creates the Subject Under Test.
		/// </summary>
		/// <param name="value">The value of the term.</param>
		/// <returns>The instance to test.</returns>
		public abstract IIntTerm CreateSUT(int value);

		[Fact]
		public void HasExpectedPropertyValues()
		{
			// Arrange
			const int value = 42;
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
			const int value = 42;
			var sut = CreateSUT(value);

			// Act
			var result = sut.ToString();

			// Assert
			Assert.Equal("42", result);
		}

		[Fact]
		public void TwoEqualTermsAreEqual()
		{
			// Arrange
			const int value = 42;
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
			const int value = 42;
			const int otherValue = 24;
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
			var sut = CreateSUT(1);
			var visitor = new Mock<ITermVisitor>();

			// Act
			sut.Accept(visitor.Object);

			// Assert
			visitor.Verify(v => v.VisitInt(sut));
		}
	}
}
