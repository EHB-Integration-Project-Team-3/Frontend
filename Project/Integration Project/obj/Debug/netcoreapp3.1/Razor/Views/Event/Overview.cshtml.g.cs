#pragma checksum "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Event\Overview.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "018d92a890d771a40bf02c0de36ff8a476c251e1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Event_Overview), @"mvc.1.0.view", @"/Views/Event/Overview.cshtml")]
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
#line 5 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Event\Overview.cshtml"
using Integration_Project.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"018d92a890d771a40bf02c0de36ff8a476c251e1", @"/Views/Event/Overview.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3442a4c80a9fe7e9899cb107005b137bcdf1133f", @"/Views/_ViewImports.cshtml")]
    public class Views_Event_Overview : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Event>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Event\Overview.cshtml"
   var user = HttpHelper.CheckLoggedUser(); 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row card-title d-flex justify-content-center"">
    <h2 class=""p-3 rounded bg-light"">Events</h2>
</div>
<div class=""row d-flex justify-content-center"">
    <table class=""table table-bordered table-hover col-9"">
        <tr>
            <th>Event </th>
            <th>Beschrijving</th>
            <th>Locatie </th>
            <th>Start datum</th>
");
#nullable restore
#line 19 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Event\Overview.cshtml"
             if (Model.Any(p => p.OrganiserId == (user != null ? user.Uuid : Guid.NewGuid()))) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <th>Bewerken</th>\r\n");
#nullable restore
#line 21 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Event\Overview.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tr>\r\n");
#nullable restore
#line 23 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Event\Overview.cshtml"
         foreach (var ev in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 25 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Event\Overview.cshtml"
               Write(ev.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 26 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Event\Overview.cshtml"
               Write(ev.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 27 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Event\Overview.cshtml"
               Write(ev.Location.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 28 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Event\Overview.cshtml"
               Write(ev.Start);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 29 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Event\Overview.cshtml"
                 if (Model.Any(p => p.OrganiserId == (user != null ? user.Uuid : Guid.NewGuid()))) {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Event\Overview.cshtml"
                     if (user.Uuid == ev.OrganiserId) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td><a");
            BeginWriteAttribute("href", " href=\"", 1169, "\"", 1226, 1);
#nullable restore
#line 31 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Event\Overview.cshtml"
WriteAttributeValue("", 1176, Url.Action("Edit", "Event", new { @Id = ev.Id } ), 1176, 50, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-edit\"></i></a></td>\r\n");
#nullable restore
#line 32 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Event\Overview.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Event\Overview.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tr>\r\n");
#nullable restore
#line 35 "C:\GitHub\FRONTEND_INTEGRATION\Project\Integration Project\Views\Event\Overview.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Event>> Html { get; private set; }
    }
}
#pragma warning restore 1591
