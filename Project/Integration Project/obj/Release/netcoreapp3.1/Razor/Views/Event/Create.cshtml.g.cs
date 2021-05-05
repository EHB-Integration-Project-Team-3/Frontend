#pragma checksum "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e00f84faafbcdffb086b6d4204333631f57516e1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Event_Create), @"mvc.1.0.view", @"/Views/Event/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e00f84faafbcdffb086b6d4204333631f57516e1", @"/Views/Event/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3442a4c80a9fe7e9899cb107005b137bcdf1133f", @"/Views/_ViewImports.cshtml")]
    public class Views_Event_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Event>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Create.cshtml"
  
    ViewData["Title"] = "Create Event";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row card-title d-flex justify-content-center\">\r\n    <h2 class=\"p-3 rounded bg-light\">Maak een nieuw event aan</h2>\r\n</div>\r\n<div class=\"row d-flex justify-content-center\">\r\n    <!-- list item image picker -->\r\n");
#nullable restore
#line 11 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Create.cshtml"
     using (Html.BeginForm("CreateEvent", "Event", null, FormMethod.Post, null, new { @class="col-8 mt-4" })) {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Create.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Create.cshtml"
                                ;

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 14 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Create.cshtml"
       Write(Html.LabelFor(m => Model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 15 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Create.cshtml"
       Write(Html.TextBoxFor(m => Model.Title, "", new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 18 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Create.cshtml"
       Write(Html.LabelFor(m => Model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 19 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Create.cshtml"
       Write(Html.TextAreaFor(m => Model.Description, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 22 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Create.cshtml"
       Write(Html.LabelFor(m => Model.Location.City));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 23 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Create.cshtml"
       Write(Html.TextBoxFor(m => Model.Location.City, "", new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 26 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Create.cshtml"
       Write(Html.LabelFor(m => Model.Location.PostalCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 27 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Create.cshtml"
       Write(Html.TextBoxFor(m => Model.Location.PostalCode, "", new { @type = "number", @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 30 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Create.cshtml"
       Write(Html.LabelFor(m => Model.Location.StreetName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 31 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Create.cshtml"
       Write(Html.TextBoxFor(m => Model.Location.StreetName, "", new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 34 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Create.cshtml"
       Write(Html.LabelFor(m => Model.Location.Number));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 35 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Create.cshtml"
       Write(Html.TextBoxFor(m => Model.Location.Number, "", new { @type="number", @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 38 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Create.cshtml"
       Write(Html.EditorFor(model => model.Start, new { htmlAttributes = new { @Value = DateTime.Now, @class = "form-control datepicker" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 39 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Create.cshtml"
       Write(Html.ValidationMessageFor(model => model.Start, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            <!-- Date Picker Input -->
            <!--<div class=""form-group mb-4"">
                <div class=""datepicker date input-group p-0 shadow-sm"">
                    Html.TextBoxFor(m => Model.Start, """", new { class = ""form-control py-4 px-4"", id = ""EventStart"",placeholder = ""Choose an event date"" })
                    <div class=""input-group-append""><span class=""input-group-text px-4""><i class=""fa fa-clock-o""></i></span></div>
                </div>
            </div>-->
            <!-- DEnd ate Picker Input -->
        </div>
");
            WriteLiteral("        <button class=\"btn btn-outline-secondary\">Toevoegen</button>\r\n");
#nullable restore
#line 51 "D:\GitHub\Frontend\Project\Integration Project\Views\Event\Create.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>");
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