using System.Collections.Generic;

namespace Virtlink.ATerms
{
	/// <summary>
	/// A string term.
	/// </summary>
	public interface IStringTerm : ITerm
	{
		/// <summary>
		/// Gets the string value of the term.
		/// </summary>
		/// <value>The value.</value>
		string Value { get; }
	}
}
