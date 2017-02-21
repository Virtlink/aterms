using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Yargon.ATerms.IO
{
    /// <summary>
    /// Tests the <see cref="ITermWriter"/> interface.
    /// </summary>
	public abstract class ITermWriterTests : TestBase
	{
		/// <summary>
		/// Creates the Subject Under Test.
		/// </summary>
		/// <returns>The instance to test.</returns>
		public abstract ITermWriter CreateSUT();

		/// <summary>
		/// Creates a reader, used in the test.
		/// </summary>
		/// <returns>The reader.</returns>
		public abstract ITermReader CreateReader();

		[Fact]
		public void CanWriteToStream()
		{
			// Arrange
			var sut = CreateSUT();
			var term = Factory.Int(1);
			var output = new MemoryStream();

			// Act
			sut.Write(term, output);

			// Assert
			Assert.True(output.Length >= 1);
			Assert.True(output.CanWrite);
		}
	}
}
