﻿using System;
using System.Collections.Generic;
using Xunit;

namespace Yargon.ATerms
{
	public abstract class TermFactoryTests
	{
		/// <summary>
		/// Creates the Subject Under Test.
		/// </summary>
		/// <returns>The instance to test.</returns>
		public abstract ITermFactory CreateSUT();

		[Fact]
		public void CanBuildIntTerm()
		{
			// Arrange
			var sut = CreateSUT();
			const int value = 3;

			// Act
			var result = sut.Int(value);

			// Assert
			Assert.Equal(value, result.Value);
			Assert.Empty(result.Annotations);
			Assert.True(sut.Owns(result));
		}

		[Fact]
		public void CanBuildIntTermWithAnnotations()
		{
			// Arrange
			var sut = CreateSUT();
			var annos = BuildAnnos(sut);
			const int value = 3;

			// Act
			var result = sut.Int(value, annos);

			// Assert
			Assert.Equal(value, result.Value);
			Assert.Equal(annos, result.Annotations);
			Assert.True(sut.Owns(result));
		}

		[Fact]
		public void CanBuildRealTerm()
		{
			// Arrange
			var sut = CreateSUT();
			const float value = 4.2f;

			// Act
			var result = sut.Real(value);

			// Assert
			Assert.Equal(value, result.Value);
			Assert.Empty(result.Annotations);
			Assert.True(sut.Owns(result));
		}

		[Fact]
		public void CanBuildRealTermWithAnnotations()
		{
			// Arrange
			var sut = CreateSUT();
			var annos = BuildAnnos(sut);
			const float value = 4.2f;

			// Act
			var result = sut.Real(value, annos);

			// Assert
			Assert.Equal(value, result.Value);
			Assert.Equal(annos, result.Annotations);
			Assert.True(sut.Owns(result));
		}

		[Fact]
		public void CanBuildStringTerm()
		{
			// Arrange
			var sut = CreateSUT();
			const string value = "Test";

			// Act
			var result = sut.String(value);

			// Assert
			Assert.Equal(value, result.Value);
			Assert.Empty(result.Annotations);
			Assert.True(sut.Owns(result));
		}

		[Fact]
		public void CanBuildStringTermWithAnnotations()
		{
			// Arrange
			var sut = CreateSUT();
			var annos = BuildAnnos(sut);
			const string value = "Test";

			// Act
			var result = sut.String(value, annos);

			// Assert
			Assert.Equal(value, result.Value);
			Assert.Equal(annos, result.Annotations);
			Assert.True(sut.Owns(result));
		}

		[Fact]
		public void CanBuildListTerm()
		{
			// Arrange
			var sut = CreateSUT();
			var elem0 = sut.Int(0);
			var elem1 = sut.Int(1);
			var elem2 = sut.Int(2);

			// Act
			var result = sut.List(elem0, elem1, elem2);

			// Assert
			Assert.Equal((IEnumerable<ITerm>)new ITerm[] { elem0, elem1, elem2 }, result.SubTerms);
			Assert.Empty(result.Annotations);
			Assert.Equal(3, result.Count);
			Assert.False(result.IsEmpty);
			Assert.Equal(elem0, result.Head);
			Assert.True(sut.Owns(result));
		}

		[Fact]
		public void CanBuildListTermWithAnnotations()
		{
			// Arrange
			var sut = CreateSUT();
			var elem0 = sut.Int(0);
			var elem1 = sut.Int(1);
			var elem2 = sut.Int(2);
			var annos = BuildAnnos(sut);

			// Act
			var result = sut.List(new ITerm[]{elem0, elem1, elem2}, annos);

			// Assert
			Assert.Equal((IEnumerable<ITerm>)new ITerm[] { elem0, elem1, elem2 }, result.SubTerms);
			Assert.Equal(annos, result.Annotations);
			Assert.Equal(3, result.Count);
			Assert.False(result.IsEmpty);
			Assert.Equal(elem0, result.Head);
			Assert.True(sut.Owns(result));
		}

		[Fact]
		public void CanBuildEmptyListTerm()
		{
			// Arrange
			var sut = CreateSUT();

			// Act
			var result = sut.List();

			// Assert
			Assert.Empty(result.Annotations);
			Assert.Equal(0, result.Count);
			Assert.True(result.IsEmpty);
			Assert.Null(result.Head);
			Assert.Null(result.Tail);
			Assert.True(sut.Owns(result));
		}

		[Fact]
		public void CanBuildEmptyListTermWithAnnotations()
		{
			// Arrange
			var sut = CreateSUT();
			var annos = BuildAnnos(sut);

			// Act
			var result = sut.List(Terms.Empty, annos);

			// Assert
			Assert.Equal(annos, result.Annotations);
			Assert.Equal(0, result.Count);
			Assert.True(result.IsEmpty);
			Assert.Null(result.Head);
			Assert.Null(result.Tail);
			Assert.True(sut.Owns(result));
		}

		[Fact]
		public void CanBuildConsTerm()
		{
			// Arrange
			var sut = CreateSUT();
			string consName = "Cons";
			var arg0 = sut.Int(0);

			// Act
			var result = sut.Cons(consName, new ITerm[] { arg0 });

			// Assert
			Assert.Equal(consName, result.Name);
			Assert.Equal(new ITerm[] { arg0 }, result.SubTerms);
			Assert.Empty(result.Annotations);
			Assert.True(sut.Owns(result));
		}

		[Fact]
		public void CanBuildConsTermWithAnnotations()
		{
			// Arrange
			var sut = CreateSUT();
			var annos = BuildAnnos(sut);
			string consName = "Cons";
			var arg0 = sut.Int(0);

			// Act
			var result = sut.Cons(consName, new ITerm[] { arg0 }, annos);

			// Assert
			Assert.Equal(consName, result.Name);
			Assert.Equal(new ITerm[] { arg0 }, result.SubTerms);
			Assert.Equal(annos, result.Annotations);
			Assert.True(sut.Owns(result));
		}

		[Fact]
		public void CanBuildTupleTerm()
		{
			// Arrange
			var sut = CreateSUT();
			var arg0 = sut.Int(0);

			// Act
			var result = sut.Tuple(new ITerm[] { arg0 });

			// Assert
			Assert.Equal(String.Empty, result.Name);
			Assert.Equal(new ITerm[] { arg0 }, result.SubTerms);
			Assert.Empty(result.Annotations);
			Assert.True(sut.Owns(result));
		}

		[Fact]
		public void CanBuildTupleTermWithAnnotations()
		{
			// Arrange
			var sut = CreateSUT();
			var annos = BuildAnnos(sut);
			var arg0 = sut.Int(0);

			// Act
			var result = sut.Tuple(new ITerm[] { arg0 }, annos);

			// Assert
			Assert.Equal(String.Empty, result.Name);
			Assert.Equal(new ITerm[] { arg0 }, result.SubTerms);
			Assert.Equal(annos, result.Annotations);
			Assert.True(sut.Owns(result));
		}

		[Fact]
		public void CanBuildPlaceholderTerm()
		{
			// Arrange
			var sut = CreateSUT();
			var template = sut.Int(0);

			// Act
			var result = sut.Placeholder(template);

			// Assert
			Assert.Equal(new ITerm[] { template }, result.SubTerms);
			Assert.Empty(result.Annotations);
			Assert.True(sut.Owns(result));
		}

		[Fact]
		public void CanBuildPlaceholderTermWithAnnotations()
		{
			// Arrange
			var sut = CreateSUT();
			var annos = BuildAnnos(sut);
			var template = sut.Int(0);

			// Act
			var result = sut.Placeholder(template, annos);

			// Assert
			Assert.Equal(new ITerm[] { template }, result.SubTerms);
			Assert.Equal(annos, result.Annotations);
			Assert.True(sut.Owns(result));
		}

		/// <summary>
		/// Builds a collection of annotations.
		/// </summary>
		/// <param name="sut">The Subject Under Test.</param>
		/// <returns>The collection of annotations.</returns>
		private IReadOnlyCollection<ITerm> BuildAnnos(ITermFactory sut)
		{
			var annos = new ITerm[]
			{
				sut.String("Annotation")
			};
			return annos;
		}
	}
}
