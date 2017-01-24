﻿using System;
using System.Collections.Generic;

namespace Yargon.ATerms
{
	// TODO: Make terms serializable.

	/// <summary>
	/// An immutable term.
	/// </summary>
	public abstract class Term
	{
		/// <summary>
		/// Gets the sub terms of the term.
		/// </summary>
		/// <value>A list of sub terms of the term.</value>
		public abstract IReadOnlyList<ITerm> SubTerms { get; }

		/// <summary>
		/// Gets a set of annotations of the term.
		/// </summary>
		/// <value>A set of annotations of the term.</value>
		public abstract IReadOnlyCollection<ITerm> Annotations { get; }

		/// <summary>
		/// Accepts the term visitor.
		/// </summary>
		/// <param name="visitor">The visitor.</param>
		public abstract void Accept(ITermVisitor visitor);

		/// <summary>
		/// Gets a sub term by index.
		/// </summary>
		/// <param name="index">The zero-based index of the subterm.</param>
		/// <returns>The subterm.</returns>
		public ITerm this[int index] => this.SubTerms[index];
	}
}