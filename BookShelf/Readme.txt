The sample is downloaded from http://www.riaservicesblog.net/Blog/post/MEFing-up-RIA-Services-Part-2-Kyles-Turn.aspx

The silverlight version is  Colain Blairs take on the MVVM example app from 2011 

Last week Kyle McClellan from the WCF RIA Services team at Microsoft posted his own version of the Book Club sample. Not wanting Kyle to be left out, I decided to MEF up his code as well.

Here is the result:

MEFedUpRIAServicesMVVM_V2.zip (3.27 mb)

Colins blog post  

I think Kyle is doing some really interesting things with this code,
 but I think I prefer how John's original code used ObservableCollections 
(which were really EntityLists) instead of how Kyle is casting everything to IEnumerable or ICollection. 

What I will be creating next is my version of the Book Club which will be a mix of John's code, 
Kyle's code, and some completely different concepts that I am working on.