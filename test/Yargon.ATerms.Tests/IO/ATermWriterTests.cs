using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Yargon.ATerms.IO
{
    /// <summary>
    /// Tests the <see cref="ATermWriter"/> class.
    /// </summary>
	public sealed class ATermWriterTests : TestBase
	{
		#region SUT
		private static readonly ATermFormat Format = ATermFormat.Instance;

		/// <summary>
		/// Creates the Subject Under Test.
		/// </summary>
		/// <returns>The instance to test.</returns>
		public ATermWriter CreateSUT()
		{
			return Format.CreateWriter();
		}

		/// <summary>
		/// Creates a reader, used in the test.
		/// </summary>
		/// <returns>The reader.</returns>
		public ATermReader CreateReader()
		{
			return Format.CreateReader(Factory);
		}
        
		public sealed class ATermWriterTests_TermTextWriterTests : TermTextWriterTests
		{
			public override TermTextWriter CreateSUT()
			{
				return new ATermWriterTests().CreateSUT();
			}

			public override TermTextReader CreateReader()
			{
				return new ATermWriterTests().CreateReader();
			}
		}
        
		public sealed class ATermWriterTests_ITermWriterTests : ITermWriterTests
		{
			public override ITermWriter CreateSUT()
			{
				return new ATermWriterTests().CreateSUT();
			}
			public override ITermReader CreateReader()
			{
				return new ATermWriterTests().CreateReader();
			}
		}
		#endregion

		[Fact]
		public void WritesCons()
		{
			// Arrange
			var sut = CreateSUT();
			string consName = "Cons";
			var term = Factory.Cons(consName, Factory.Int(0), Factory.Int(1));

			// Act
			var result = sut.ToString(term);

			// Assert
			Assert.Equal("Cons(0,1)", result);
		}

		[Fact]
		public void WritesTuple()
		{
			// Arrange
			var sut = CreateSUT();
			var term = Factory.Tuple(Factory.Int(0), Factory.Int(1));

			// Act
			var result = sut.ToString(term);

			// Assert
			Assert.Equal("(0,1)", result);
		}

		[Fact]
		public void WritesInt()
		{
			// Arrange
			var sut = CreateSUT();
			var term = Factory.Int(1);

			// Act
			var result = sut.ToString(term);

			// Assert
			Assert.Equal("1", result);
		}

		[Fact]
		public void WritesReal()
		{
			// Arrange
			var sut = CreateSUT();
			var term = Factory.Real(4.2f);

			// Act
			var result = sut.ToString(term);

			// Assert
			Assert.Equal("4.2", result);
		}

		[Fact]
		public void WritesString()
		{
			// Arrange
			var sut = CreateSUT();
			var term = Factory.String("abc");

			// Act
			var result = sut.ToString(term);

			// Assert
			Assert.Equal("\"abc\"", result);
		}

		[Fact]
		public void WritesList()
		{
			// Arrange
			var sut = CreateSUT();
			var term = Factory.List(Factory.Int(0), Factory.Int(1), Factory.Int(2));

			// Act
			var result = sut.ToString(term);

			// Assert
			Assert.Equal("[0,1,2]", result);
		}

		[Fact]
		public void WritesPlaceholder()
		{
			// Arrange
			var sut = CreateSUT();
			var term = Factory.Placeholder(Factory.Int(0));

			// Act
			var result = sut.ToString(term);

			// Assert
			Assert.Equal("<0>", result);
		}
	}
}
