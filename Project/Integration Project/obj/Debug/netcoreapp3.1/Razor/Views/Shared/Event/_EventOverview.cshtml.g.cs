#pragma checksum "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2492e0f5b2bff5b6e7701794805fe25de11f5c3c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Event__EventOverview), @"mvc.1.0.view", @"/Views/Shared/Event/_EventOverview.cshtml")]
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
#line 1 "D:\GitHub\Frontend\Project\Integration Project\Views\_ViewImports.cshtml"
using Integration_Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\GitHub\Frontend\Project\Integration Project\Views\_ViewImports.cshtml"
using Integration_Project.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml"
using Integration_Project.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml"
using MlkPwgen;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2492e0f5b2bff5b6e7701794805fe25de11f5c3c", @"/Views/Shared/Event/_EventOverview.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3442a4c80a9fe7e9899cb107005b137bcdf1133f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Event__EventOverview : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Event>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 8 "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml"
  
    var user = HttpHelper.CheckLoggedUser();
    var str = "";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n\r\n\r\n");
#nullable restore
#line 18 "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml"
 foreach (var ev in Model) {

    str = PasswordGenerator.Generate(length: 4, allowed: Sets.Alphanumerics);

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row event-overview-detail-wrapper my-3 rounded\" onload=\"loadEmbeddedMap()\"");
            BeginWriteAttribute("onclick", " onclick=\"", 487, "\"", 572, 3);
            WriteAttributeValue("", 497, "window.location.href=\'", 497, 22, true);
#nullable restore
#line 21 "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml"
WriteAttributeValue("", 519, Url.Action("Detail", "Event", new { @Id = ev.Id } ), 519, 52, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 571, "\'", 571, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n        <input type=\"hidden\" class=\"uniqueEnum\"");
            BeginWriteAttribute("value", " value=\"", 623, "\"", 635, 1);
#nullable restore
#line 22 "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml"
WriteAttributeValue("", 631, str, 631, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n        <input type=\"hidden\" id=\"queryLocation\"");
            BeginWriteAttribute("value", " value=\"", 688, "\"", 732, 1);
#nullable restore
#line 23 "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml"
WriteAttributeValue("", 696, ev.Location.ToStringForGoogleMaps(), 696, 36, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n        <div class=\"col-md-2 text-center bg-custom text-white date-info\">\r\n            <p> ");
#nullable restore
#line 26 "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml"
           Write(ev.Start.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n            <p> ");
#nullable restore
#line 27 "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml"
           Write(ev.Start.ToString("MMM"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n            <p> ");
#nullable restore
#line 28 "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml"
           Write(ev.Start.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n            <span>\r\n                <i class=\"fas fa-clock\"></i>\r\n                ");
#nullable restore
#line 31 "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml"
           Write(ev.Start.ToString("MMM"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 31 "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml"
                                     Write(ev.Start.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 31 "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml"
                                                     Write(ev.End.ToString("MMM"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 31 "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml"
                                                                             Write(ev.End.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </span>\r\n        </div>\r\n        <div class=\"col-md-3 p-0\">\r\n            <div class=\"localMap\"");
            BeginWriteAttribute("id", " id=\"", 1203, "\"", 1216, 2);
            WriteAttributeValue("", 1208, "map-", 1208, 4, true);
#nullable restore
#line 35 "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml"
WriteAttributeValue("", 1212, str, 1212, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></div>\r\n        </div>\r\n        <div class=\"col-md-5 bg-white ev-tit-desc pt-4\">\r\n            <h2>");
#nullable restore
#line 38 "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml"
           Write(ev.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n            <p>");
#nullable restore
#line 39 "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml"
          Write(ev.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n        <div class=\"col-md-2 text-center pt-4 right-side\">\r\n            <i class=\"fas fa-map-marker-alt\"></i>\r\n            <p>");
#nullable restore
#line 43 "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml"
          Write(ev.Location.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 44 "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml"
             if (Model.Any(p => p.OrganiserId == (user != null ? user.Uuid : Guid.NewGuid()))) {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml"
                 if (user.Uuid == ev.OrganiserId) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a");
            BeginWriteAttribute("href", " href=\"", 1706, "\"", 1763, 1);
#nullable restore
#line 46 "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml"
WriteAttributeValue("", 1713, Url.Action("Edit", "Event", new { @Id = ev.Id } ), 1713, 50, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-edit\"></i></a>\r\n");
#nullable restore
#line 47 "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml"
             if (user != null) {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml"
                 if (ev.Attendees.Any(p => p.UserId == user.Uuid)) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <i class=\"fas fa-check\"></i>\r\n");
#nullable restore
#line 52 "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml"
                } else {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a");
            BeginWriteAttribute("href", " href=\"", 2033, "\"", 2109, 1);
#nullable restore
#line 53 "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml"
WriteAttributeValue("", 2040, Url.Action("SubscribeToEvent", "Event", new { @eventId = ev.Uuid } ), 2040, 69, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fas fa-user-plus\"></i></a>\r\n");
#nullable restore
#line 54 "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml"

                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml"
                 ;
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 60 "D:\GitHub\Frontend\Project\Integration Project\Views\Shared\Event\_EventOverview.cshtml"
}

#line default
#line hidden
#nullable disable
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
