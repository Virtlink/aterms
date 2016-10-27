using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Virtlink.ATerms.IO
{
	public abstract class ITermReaderTests : TestBase
	{
		/// <summary>
		/// Creates the Subject Under Test.
		/// </summary>
		/// <returns>The instance to test.</returns>
		public abstract ITermReader CreateSUT();

		/// <summary>
		/// Creates a writer, used in the test.
		/// </summary>
		/// <returns>The writer.</returns>
		public abstract ITermWriter CreateWriter();

		[Test]
		public void CanReadFromStream()
		{
			// Arrange
			var sut = CreateSUT();
			var term = Factory.Int(1);
			var input = new MemoryStream();
			this.CreateWriter().Write(term, input);
			input.Position = 0;

			// Act
			var result = sut.Read(input);

			// Assert
			Assert.IsTrue(input.CanRead);
			Assert.AreEqual(term, result);
		}
	}
}
