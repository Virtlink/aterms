using System.IO;
using System.Text;

namespace Yargon.ATerms
{
	/// <summary>
	/// Base class for test classes.
	/// </summary>
	public abstract class TestBase
	{
	    /// <summary>
	    /// Gets a term factory to use.
	    /// </summary>
	    /// <value>A term factory.</value>
	    protected TermFactory Factory { get; } = new TrivialTermFactory();

	    /// <summary>
        /// Returns a <see cref="MemoryStream"/> with the specified string encoded in it.
        /// </summary>
        /// <param name="str">The string to write.</param>
        /// <returns>The <see cref="MemoryStream"/>.</returns>
        protected static MemoryStream StringToStream(string str)
		{
			var input = new MemoryStream();
			using (var writer = new StreamWriter(input, Encoding.UTF8, 4096, true))
			{
				writer.Write(str);
			}
			input.Position = 0;
			return input;
		}
	}
}
