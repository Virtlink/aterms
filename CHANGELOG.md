# Change Log

## [Unreleased]
- Add `ITermVisitor.VisitTerm()` method that is called when none other applies.
- Add `ITermVisitor<TResult>` that returns a result.
- Add missing contracts for Accept() method of term implementations.
- Remove unused `Term` class.
- Rewrote tests using Xunit.
- Fix local build issues.

## [1.1.1] - 2017-01-24
- Renamed to `Yargon.ATerms`.

## [1.1.0] - 2016-10-27
- Initial release.