using System.Collections.Generic;
using Xunit;
using Moq;

namespace Yargon.ATerms
{
    /// <summary>
    /// Tests the <see cref="IListTerm"/> interface.
    /// </summary>
    public abstract class IListTermTests : TestBase
	{
		/// <summary>
		/// Creates the Subject Under Test.
		/// </summary>
		/// <param name="values">The values of the term.</param>
		/// <returns>The instance to test.</returns>
		public abstract IListTerm CreateSUT(IEnumerable<ITerm> values);

		[Fact]
		public void HasExpectedPropertyValues()
		{
			// Arrange
			var val0 = Factory.Int(0);
			var val1 = Factory.Int(1);
			var val2 = Factory.Int(2);
			var values = new ITerm[] { val0, val1, val2 };
			var sut = CreateSUT(values);

			// Assert
			Assert.Equal(values, sut.SubTerms);
			Assert.Equal(3, sut.Count);
			Assert.False(sut.IsEmpty);
			Assert.Equal(val0, sut.Head);
			Assert.Equal(new ITerm[]{ val1, val2 }, sut.Tail.SubTerms);
			Assert.Empty(sut.Annotations);
		}

		[Fact]
		public void ToStringReturnsAString()
		{
			// Arrange
			var val0 = Factory.Int(0);
			var val1 = Factory.Int(1);
			var val2 = Factory.Int(2);
			var values = new ITerm[] { val0, val1, val2 };
			var sut = CreateSUT(values);

			// Act
			var result = sut.ToString();

			// Assert
			Assert.Equal("[0,1,2]", result);
		}

		[Fact]
		public void TwoEqualTermsAreEqual()
		{
			// Arrange
			var val0 = Factory.Int(0);
			var val1 = Factory.Int(1);
			var val2 = Factory.Int(2);
			var values = new ITerm[] { val0, val1, val2 };
			var sut = CreateSUT(values);
			var other = CreateSUT(new []{val0,val1, val2});

			// Act
			var result = sut.Equals(other);

			// Assert
			Assert.True(result);
		}

		[Fact]
		public void TwoDifferentTermsAreDifferent()
		{
			// Arrange
			var val0 = Factory.Int(0);
			var val1 = Factory.Int(1);
			var val2 = Factory.Int(2);
			var values = new ITerm[] { val0, val1, val2 };
			var sut = CreateSUT(values);
			var other = CreateSUT(new[] { val0, val2 });

			// Act
			var result = sut.Equals(other);

			// Assert
			Assert.False(result);
		}

		[Fact]
		public void CallsVisitorMethod()
		{
			// Arrange
			var val0 = Factory.Int(0);
			var val1 = Factory.Int(1);
			var val2 = Factory.Int(2);
			var values = new ITerm[] { val0, val1, val2 };
			var sut = CreateSUT(values);
			var visitor = new Mock<ITermVisitor>();

			// Act
			sut.Accept(visitor.Object);

			// Assert
			visitor.Verify(v => v.VisitList(sut));
		}
	}
}
