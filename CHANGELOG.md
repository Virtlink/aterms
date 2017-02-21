# Change Log

## [1.2.0] - 2017-02-21
- Add `ITermVisitor.VisitTerm()` method that is called when none other applies.
- Add `ITermVisitor<TResult>` that returns a result.
- Add missing contracts for Accept() method of term implementations.
- Add Unicode support to ATerm parser.
- Remove unused `Term` class.
- Rewrote tests using Xunit.
- Remove support for vertical tab and backspace escape sequences.
- Fix local build issues.

## [1.1.1] - 2017-01-24
- Renamed to `Yargon.ATerms`.

## [1.1.0] - 2016-10-27
- Initial release.