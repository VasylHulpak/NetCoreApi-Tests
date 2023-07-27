## Testing

_**Unit tests**_ are used to test isolated software components, such as individual class methods. 
_**Integration tests**_ confirm that two or more app components work together to produce an expected result, possibly including every component required to fully process a request.

Unit tests use fabricated components, known as fakes or mock objects, in place of infrastructure components.

In contrast to unit tests, integration tests:
* Use the actual components that the app uses in production.
* Require more code and data processing.
* Take longer to run.
