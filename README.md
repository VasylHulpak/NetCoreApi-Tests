# .NET Core API + UnitTests
Simple project with one controller and enpoinds(GET/POST). Added middleware for logging and service for retrive data(fake). Create project for testing.

The solusion contains 2 projects: api and tests. So api porject has only one controller called 'TestController'. This controller has only for methods(HttpPost/HttpGet) with simple functionalities for extrating text or logging. There is a simple middleware which purpose is to logged info only for api calls, simple model, and context which return fake data. The 'Tests' project is provided example how to test 'Api' project functionalities
## Recommended Setup
- dotnet watch run (only use http protocol. Otherwise you need to have ssl)

