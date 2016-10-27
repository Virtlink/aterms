using System.Collections.Generic;

namespace Virtlink.ATerms
{
	/// <summary>
	/// The trivial term factory has a trivial implementation for the terms
	/// and the factory that doesn't do any optimizations such as term sharing.
	/// </summary>
	public sealed partial class TrivialTermFactory : TermFactory
	{
		/// <inheritdoc />
		public override bool IsBuiltByThisFactory(ITerm term)
		{
			// CONTRACT: Inherited from TermFactory
			return term is Term;
		}

		/// <inheritdoc />
		public override IIntTerm Int(int value, IReadOnlyCollection<ITerm> annotations)
		{
			// CONTRACT: Inherited from TermFactory
			return new IntTerm(value, annotations);
		}

		/// <inheritdoc />
		public override IRealTerm Real(float value, IReadOnlyCollection<ITerm> annotations)
		{
			// CONTRACT: Inherited from TermFactory
			return new RealTerm(value, annotations);
		}

		/// <inheritdoc />
		public override IStringTerm String(string value, IReadOnlyCollection<ITerm> annotations)
		{
			// CONTRACT: Inherited from TermFactory
			return new StringTerm(value, annotations);
		}

		/// <inheritdoc />
		public override IListTerm ListConsNil(ITerm head, IListTerm tail, IReadOnlyCollection<ITerm> annotations)
		{
			// CONTRACT: Inherited from TermFactory
			return new ListTerm(head, tail, annotations);
		}

		/// <inheritdoc />
		public override IListTerm EmptyList(IReadOnlyCollection<ITerm> annotations)
		{
			// CONTRACT: Inherited from TermFactory
			return new ListTerm(annotations);
		}

		/// <inheritdoc />
		public override IConsTerm Cons(string name, IReadOnlyList<ITerm> terms, IReadOnlyCollection<ITerm> annotations)
		{
			// CONTRACT: Inherited from TermFactory
			return new ConsTerm(name, terms, annotations);
		}

		/// <inheritdoc />
		public override IPlaceholderTerm Placeholder(ITerm template, IReadOnlyCollection<ITerm> annotations)
		{
			// CONTRACT: Inherited from TermFactory
			return new PlaceholderTerm(template, annotations);
		}
	}
}
