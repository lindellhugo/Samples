# AspNetCore

This examples shows how one can use OpenRiaServices with a AspNetCore server and a Net 6.0 client.

To run/debug this project:
1. Compile all projects.
2. Setup AspNetCore.Client and AspNetCore.Hosting.AspNetCore as startup projects in Visual Studio.
3. Run

# Use .Net Framework project to get working code generation for AspNet.Core

The trick here is to have an "old style" .NET Framework web application (Hosting.Wcf) which is used by the code generator 
Se the following in "CodeGen.csproj"

```    <LinkedOpenRiaServerProject>..\AspNetCore.Hosting\AspNetCore.Hosting.Wcf.csproj</LinkedOpenRiaServerProject>
```

The .Net framework projekt is only needed to get the code generation to run, but for the code generation to be correct 
it needs to contain (or referece projects with) all DomainServices.
