#pragma checksum "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Event\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "487ce94c6bf8c5b166ccb835d94fbab0269ababc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Event_Detail), @"mvc.1.0.view", @"/Views/Event/Detail.cshtml")]
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
#nullable restore
#line 2 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Event\Detail.cshtml"
using Integration_Project.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"487ce94c6bf8c5b166ccb835d94fbab0269ababc", @"/Views/Event/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3442a4c80a9fe7e9899cb107005b137bcdf1133f", @"/Views/_ViewImports.cshtml")]
    public class Views_Event_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Event>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Event\Detail.cshtml"
  
    var user = HttpHelper.CheckLoggedUser();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n<div class=\"container\">\r\n    <div class=\"row d-flex justify-content-center\">\r\n        <div class=\"form-group\">\r\n            <label for=\"title\">Naam:</label><br>\r\n            <input type=\"text\" id=\"title\" name=\"title\"");
            BeginWriteAttribute("value", " value=", 332, "", 351, 1);
#nullable restore
#line 15 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Event\Detail.cshtml"
WriteAttributeValue("", 339, Model.Title, 339, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><br>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            <label for=\"description\">Beschrijving:</label><br>\r\n            <input type=\"text\" id=\"description\" name=\"description\"");
            BeginWriteAttribute("value", " value=", 538, "", 563, 1);
#nullable restore
#line 19 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Event\Detail.cshtml"
WriteAttributeValue("", 545, Model.Description, 545, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><br>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            <label for=\"start\">Begin:</label><br>\r\n            <input type=\"date\" id=\"start\" name=\"start\"");
            BeginWriteAttribute("value", " value=", 725, "", 744, 1);
#nullable restore
#line 23 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Event\Detail.cshtml"
WriteAttributeValue("", 732, Model.Start, 732, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><br>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            <label for=\"end\">Einde:</label><br>\r\n            <input type=\"date\" id=\"end\" name=\"end\"");
            BeginWriteAttribute("value", " value=", 900, "", 917, 1);
#nullable restore
#line 27 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Event\Detail.cshtml"
WriteAttributeValue("", 907, Model.End, 907, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><br>\r\n        </div>\r\n");
#nullable restore
#line 29 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Event\Detail.cshtml"
         if (Model.OrganiserId == (user != null ? user.Uuid : Guid.NewGuid())) {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Event\Detail.cshtml"
         if (user.Uuid == Model.OrganiserId) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a");
            BeginWriteAttribute("href", " href=\"", 1088, "\"", 1148, 1);
#nullable restore
#line 31 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Event\Detail.cshtml"
WriteAttributeValue("", 1095, Url.Action("Edit", "Event", new { @Id = Model.Id } ), 1095, 53, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-edit\"></i></a>\r\n");
#nullable restore
#line 32 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Event\Detail.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Event\Detail.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Event> Html { get; private set; }
    }
}
#pragma warning restore 1591
