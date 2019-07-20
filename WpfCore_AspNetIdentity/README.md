# WpfCore

This examples shows how one can use OpenRiaServices with a netcoreapp3.0/netstandard2 client.
Currently this requires some "ugly" workaround for the codegen since it does not work correcly for netstandard2.0 assemblies.
The workaround here is to use a net framework as target library for codegen.

The output dll can then be referenced directly (not a project reference) or the generated files can be included (sulution used here)

It also shows how it can be used togheter with AspNetIdentity