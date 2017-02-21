using Xunit;
using Moq;

namespace Yargon.ATerms
{
    /// <summary>
    /// Tests the <see cref="IStringTerm"/> interface.
    /// </summary>
    public abstract class IStringTermTests : TestBase
	{
		/// <summary>
		/// Creates the Subject Under Test.
		/// </summary>
		/// <param name="value">The value of the term.</param>
		/// <returns>The instance to test.</returns>
		public abstract IStringTerm CreateSUT(string value);

		[Fact]
		public void HasExpectedPropertyValues()
		{
			// Arrange
			const string value = "abc";
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
			const string value = "abc";
			var sut = CreateSUT(value);

			// Act
			var result = sut.ToString();

			// Assert
			Assert.Equal("\"abc\"", result);
		}

		[Fact]
		public void TwoEqualTermsAreEqual()
		{
			// Arrange
			const string value = "abc";
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
			const string value = "abc";
			const string otherValue = "def";
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
			var sut = CreateSUT("abc");
			var visitor = new Mock<ITermVisitor>();

			// Act
			sut.Accept(visitor.Object);

			// Assert
			visitor.Verify(v => v.VisitString(sut));
		}
	}
}
