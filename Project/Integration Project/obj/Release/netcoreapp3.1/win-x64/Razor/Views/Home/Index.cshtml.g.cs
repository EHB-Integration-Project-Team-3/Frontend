#pragma checksum "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4a52bf56a54fd9e5d81db43a2b0dff278fe67b33"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\_ViewImports.cshtml"
using Integration_Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\_ViewImports.cshtml"
using Integration_Project.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a52bf56a54fd9e5d81db43a2b0dff278fe67b33", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3442a4c80a9fe7e9899cb107005b137bcdf1133f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"container-fluid\">\r\n    <div class=\"row d-flex justify-content-center\">\r\n        <button class=\"btn btn-outline-secondary mx-2\"");
            BeginWriteAttribute("onclick", " onclick=\"", 187, "\"", 245, 3);
            WriteAttributeValue("", 197, "location.href=\'", 197, 15, true);
#nullable restore
#line 8 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Home\Index.cshtml"
WriteAttributeValue("", 212, Url.Action("Overview", "Event"), 212, 32, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 244, "\'", 244, 1, true);
            EndWriteAttribute();
            WriteLiteral("><h1 class=\"display-4\">Events</h1></button>\r\n        <button class=\"btn btn-outline-secondary mx-2\"");
            BeginWriteAttribute("onclick", " onclick=\"", 345, "\"", 401, 3);
            WriteAttributeValue("", 355, "location.href=\'", 355, 15, true);
#nullable restore
#line 9 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Home\Index.cshtml"
WriteAttributeValue("", 370, Url.Action("Create", "Event"), 370, 30, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 400, "\'", 400, 1, true);
            EndWriteAttribute();
            WriteLiteral("><h1 class=\"display-4\">Event Toevoegen</h1></button>\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
