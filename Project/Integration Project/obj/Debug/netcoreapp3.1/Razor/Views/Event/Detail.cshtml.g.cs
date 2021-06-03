#pragma checksum "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c465f1467ce35d078f0ee9e6dfcec7d6be7d3b91"
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
#line 2 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Detail.cshtml"
using Integration_Project.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Detail.cshtml"
using MlkPwgen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Detail.cshtml"
using Integration_Project.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c465f1467ce35d078f0ee9e6dfcec7d6be7d3b91", @"/Views/Event/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3442a4c80a9fe7e9899cb107005b137bcdf1133f", @"/Views/_ViewImports.cshtml")]
    public class Views_Event_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EventdetailViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Images/placeholder.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("profile picture"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("profile col-12"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 6 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Detail.cshtml"
  
    var user = HttpHelper.CheckLoggedUser();
    var str = PasswordGenerator.Generate(length: 4, allowed: Sets.Alphanumerics);
    var organisers = Model.Users.Where(u => u.Uuid == @Model.Event.OrganiserId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n<div class=\"container\">\r\n    <div class=\"row d-flex justify-content-center col-12\">\r\n");
            WriteLiteral("        <label class=\"col-12\" style=\"text-align: center\"><h1>");
#nullable restore
#line 18 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Detail.cshtml"
                                                        Write(Model.Event.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1></label>\r\n        <label class=\"col-12\" style=\"text-align: center\">");
#nullable restore
#line 19 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Detail.cshtml"
                                                    Write(Model.Event.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n    </div>\r\n    <div class=\"col-12\">\r\n");
            WriteLiteral("\r\n    </div>\r\n    <div class=\"row d-flex justify-content-center col-12\">\r\n");
            WriteLiteral("        <div class=\"col-4\">\r\n            <div class=\"row event-overview-detail-wrapper my-3 rounded\" onload=\"loadEmbeddedMap()\">\r\n                <input type=\"hidden\" class=\"uniqueEnum\"");
            BeginWriteAttribute("value", " value=\"", 994, "\"", 1006, 1);
#nullable restore
#line 29 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Detail.cshtml"
WriteAttributeValue("", 1002, str, 1002, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <input type=\"hidden\" id=\"queryLocation\"");
            BeginWriteAttribute("value", " value=\"", 1067, "\"", 1120, 1);
#nullable restore
#line 30 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Detail.cshtml"
WriteAttributeValue("", 1075, Model.Event.Location.ToStringForGoogleMaps(), 1075, 45, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <div class=\"localMap\"");
            BeginWriteAttribute("id", " id=\"", 1163, "\"", 1176, 2);
            WriteAttributeValue("", 1168, "map-", 1168, 4, true);
#nullable restore
#line 31 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Detail.cshtml"
WriteAttributeValue("", 1172, str, 1172, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></div>\r\n            </div>\r\n        </div>\r\n        <div class=\"col-8\">\r\n");
#nullable restore
#line 36 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Detail.cshtml"
             if (organisers.Count() > 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"form-group col-12\">\r\n                    <label for=\"description\">Organisator:</label><br>\r\n");
#nullable restore
#line 40 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Detail.cshtml"
                     foreach (InternalUser organiser in organisers)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <input type=\"text\" id=\"organiser\" name=\"organiser\"");
            BeginWriteAttribute("value", " value=\"", 1616, "\"", 1664, 2);
#nullable restore
#line 42 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Detail.cshtml"
WriteAttributeValue("", 1624, organiser.LastName, 1624, 19, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 42 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Detail.cshtml"
WriteAttributeValue(" ", 1643, organiser.FirstName, 1644, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"col-12\" style=\"height:40px\"><br>\r\n");
#nullable restore
#line 43 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Detail.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n");
#nullable restore
#line 45 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Detail.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"form-group col-12\">\r\n                <label for=\"start\">Begin:</label><br>\r\n                <input type=\"date\" id=\"start\" name=\"start\"");
            BeginWriteAttribute("value", " value=", 1927, "", 1975, 1);
#nullable restore
#line 48 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Detail.cshtml"
WriteAttributeValue("", 1934, Model.Event.Start.ToString("yyyy-MM-dd"), 1934, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"col-12\" style=\"height:40px\"><br>\r\n            </div>\r\n            <div class=\"form-group col-12\">\r\n                <label for=\"end\">Einde:</label><br>\r\n                <input type=\"date\" id=\"end\" name=\"end\"");
            BeginWriteAttribute("value", " value=", 2189, "", 2235, 1);
#nullable restore
#line 52 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Detail.cshtml"
WriteAttributeValue("", 2196, Model.Event.End.ToString("yyyy-MM-dd"), 2196, 39, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"col-12\" style=\"height:40px\"><br>\r\n            </div>\r\n");
#nullable restore
#line 54 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Detail.cshtml"
             if (Model.Event.OrganiserId == (user != null ? user.Uuid : Guid.NewGuid()))
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 56 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Detail.cshtml"
                 if (user.Uuid == Model.Event.OrganiserId)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a");
            BeginWriteAttribute("href", " href=\"", 2503, "\"", 2569, 1);
#nullable restore
#line 58 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Detail.cshtml"
WriteAttributeValue("", 2510, Url.Action("Edit", "Event", new { @Id = Model.Event.Id } ), 2510, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-edit\"></i></a>\r\n");
#nullable restore
#line 59 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Detail.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 59 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Detail.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n    <div>\r\n");
            WriteLiteral("        <label class=\"col-12\">Deelnemers: </label>\r\n");
#nullable restore
#line 66 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Detail.cshtml"
         if (Model.Users.Count == 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <label class=\"col-12\">Er zijn nog geen deelnemers.</label>\r\n");
#nullable restore
#line 69 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Detail.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Detail.cshtml"
         foreach (InternalUser attendee in @Model.Users)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"form-group col-3\">\r\n");
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c465f1467ce35d078f0ee9e6dfcec7d6be7d3b9113150", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                <label class=\"col-12\">");
#nullable restore
#line 76 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Detail.cshtml"
                                 Write(attendee.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label><br />\r\n                <label class=\"col-12\">");
#nullable restore
#line 77 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Detail.cshtml"
                                 Write(attendee.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n            </div>\r\n");
#nullable restore
#line 91 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Detail.cshtml"
              
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EventdetailViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
