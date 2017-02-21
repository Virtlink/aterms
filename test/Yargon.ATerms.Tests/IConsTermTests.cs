using System.Collections.Generic;
using Xunit;
using Moq;

namespace Yargon.ATerms
{
    /// <summary>
    /// Tests the <see cref="IConsTerm"/> interface.
    /// </summary>
	public abstract class IConsTermTests : TestBase
	{
		/// <summary>
		/// Creates the Subject Under Test.
		/// </summary>
		/// <param name="name">The name of the constructor.</param>
		/// <param name="terms">The terms of the constructor.</param>
		/// <returns>The instance to test.</returns>
		public abstract IConsTerm CreateSUT(string name, IEnumerable<ITerm> terms);

		[Fact]
		public void HasExpectedPropertyValues()
		{
			// Arrange
			string consName = "Cons";
			var val0 = Factory.Int(0);
			var val1 = Factory.Int(1);
			var values = new ITerm[] { val0, val1 };
			var sut = CreateSUT(consName, values);

			// Assert
			Assert.Equal(consName, sut.Name);
			Assert.Equal(values, sut.SubTerms);
			Assert.Empty(sut.Annotations);
		}

		[Fact]
		public void ToStringReturnsAString()
		{
			// Arrange
			string consName = "Cons";
			var val0 = Factory.Int(0);
			var val1 = Factory.Int(1);
			var values = new ITerm[] { val0, val1 };
			var sut = CreateSUT(consName, values);

			// Act
			var result = sut.ToString();

			// Assert
			Assert.Equal("Cons(0,1)", result);
		}

		[Fact]
		public void TwoEqualTermsAreEqual()
		{
			// Arrange
			string consName = "Cons";
			var val0 = Factory.Int(0);
			var val1 = Factory.Int(1);
			var values = new ITerm[] { val0, val1 };
			var sut = CreateSUT(consName, values);
			var other = CreateSUT(consName, new[] { val0, val1 });

			// Act
			var result = sut.Equals(other);

			// Assert
			Assert.True(result);
		}

		[Fact]
		public void TwoDifferentTermsAreDifferent()
		{
			// Arrange
			string cons0Name = "Cons";
			string cons1Name = "Other";
			var val0 = Factory.Int(0);
			var val1 = Factory.Int(1);
			var values = new ITerm[] { val0, val1 };
			var sut = CreateSUT(cons0Name, values);
			var other = CreateSUT(cons1Name, new[] { val0 });

			// Act
			var result = sut.Equals(other);

			// Assert
			Assert.False(result);
		}

		[Fact]
		public void CallsVisitorMethod()
		{
			// Arrange
			var sut = CreateSUT("Cons", new[] { Factory.Int(0) });
			var visitor = new Mock<ITermVisitor>();
			
			// Act
			sut.Accept(visitor.Object);

			// Assert
			visitor.Verify(v => v.VisitCons(sut));
		}
	}
}
