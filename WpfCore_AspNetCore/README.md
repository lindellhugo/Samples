# AspNetCore

This examples shows how one can use OpenRiaServices with a AspNetCore server and a Net 6.0 client.

To run/debug this project:
1. Compile all projects.
2. Setup AspNetCore.Client and AspNetCore.Hosting.AspNetCore as startup projects in Visual Studio.
3. Run

# With 5.4.0 rherer is no need to use .Net Framework project to get working code generation for AspNet.Core

Se the following in "CodeGen.csproj"

```
<LinkedOpenRiaServerProject>..\AspNetCore.Hosting.AspNetCore\AspNetCore.Hosting.AspNetCore.csproj</LinkedOpenRiaServerProject>
```

# Avoid build warning about duplicate includes

Remove the generated file once and then add it as "none" to still see it in solution view
```
  <ItemGroup>
    <Compile Remove="Generated_Code\AspNetCore.Hosting.AspNetCore.g.cs" />
    <None Include="Generated_Code\AspNetCore.Hosting.AspNetCore.g.cs" />
  </ItemGroup>
```
