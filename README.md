# Samples

This repos (https://github.com/OpenRIAServices/Samples) is intended for samples using OpenRiaServices.
Submissions are welcome


# WCF Ria Services Samples

Below are some links to samples targeting WCF RIA Services (and silverlight).
They should be fairly easy to have them target OpenRiaServices instead.

* Microsoft code samples
 https://code.msdn.microsoft.com/site/search?f%5B0%5D.Type=Technology&f%5B0%5D.Value=WCF%20RIA%20Services&f%5B1%5D.Type=Affiliation&f%5B1%5D.Value=Microsoft
* Microsoft MSDN blog posts from Kyle
https://blogs.msdn.microsoft.com/kylemc/tag/wcf-ria-services/page/3/

other old blogs with resources
* https://blogs.msdn.microsoft.com/brada/tag/riaservices/

# Publish
for publishing blazor webassembly, Copy wwwroot folder to root of RIA host webapp. this is the same as SelfHosting method of blazor. then change web.config 
and add UrlReWriting section and httpCompression from web-blazor-publish.config file.

# Authentication
blazro webassembly does not support working with cookies directly. if you want to use internal authentication system, you must use Microsoft Indentity.
if you want to use FormsAuthentication, cookies is not working and you must use Tokens.
