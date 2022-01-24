#pragma checksum "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e1561d73ce768624c937450aafca36eef497db19"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AppoinmentManagment.Pages.Doctor.Views_Doctor_Index), @"mvc.1.0.view", @"/Views/Doctor/Index.cshtml")]
namespace AppoinmentManagment.Pages.Doctor
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
#line 1 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\_ViewImports.cshtml"
using AppoinmentManagment;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1561d73ce768624c937450aafca36eef497db19", @"/Views/Doctor/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab6442c0e4490c61560fc742add77483583ac211", @"/Views/_ViewImports.cshtml")]
    public class Views_Doctor_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AppoinmentManagment.BusinessLayer.ListAppoinmentBO>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_prescription.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/doctor.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml"
  
    ViewData["Title"] = "Dashboard";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 class=\"text-center text-primary\">Doctor Dashboard</h1>\r\n<hr />\r\n<div>\r\n");
#nullable restore
#line 10 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml"
     if (ViewBag.Success != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span class=\"text-end alert alert-success\" role=\"alert\">");
#nullable restore
#line 12 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml"
                                                           Write(ViewBag.Success);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 13 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml"
     if (ViewBag.Error != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span class=\"text-end alert alert-danger\" role=\"alert\">");
#nullable restore
#line 16 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml"
                                                          Write(ViewBag.Error);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 17 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
</div>
<div class=""row"">
    <div class=""border backgroundWhite col-12"">
        <br />
        <table id=""dtBasicExample"" class=""table table-striped table-bordered table-sm"" cellspacing=""0"" width=""100%"">
            <thead>
                <tr>
                    <th class=""th-sm text-center"">Appoinment Id</th>
                    <th class=""th-sm text-center"">Patient Name</th>
                    <th class=""th-sm text-center"">Appointment Date</th>
                    <th class=""th-sm text-center"">Appointment Time</th>
                    <th class=""th-sm text-center"">Appointment Status</th>
                    <th class=""th-sm text-center"">Action</th>
                </tr>
            </thead>
            <tbody id=""tableData"">
");
#nullable restore
#line 35 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml"
                 if (Model.AppointmentList.Count == 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td colspan=\"6\" style=\"text-align:center\">No data</td>\r\n                    </tr>\r\n");
#nullable restore
#line 40 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml"
                }
                else
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml"
                     foreach (var appoint in Model.AppointmentList)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td class=\"text-center\">");
#nullable restore
#line 46 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml"
                                               Write(appoint.AppointmentId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"text-center\">");
#nullable restore
#line 47 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml"
                                               Write(appoint.PatientName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"text-center\">");
#nullable restore
#line 48 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml"
                                               Write(appoint.AppointmentDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"text-center\">");
#nullable restore
#line 49 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml"
                                               Write(appoint.AppointmentTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"text-center text-success\">");
#nullable restore
#line 50 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml"
                                                            Write(appoint.AppointmentStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 51 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml"
                             if (@appoint.IsVisited == 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <td class="" text-center"">
                                    <div class=""text-center"">
                                        <a class=""btn btn-primary text-white"" style=""cursor:pointer; width:50px;"" onclick=Patient(""/appointment/patient/");
#nullable restore
#line 55 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml"
                                                                                                                                                   Write(appoint.AppointmentId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""") >
                                            <i data-toggle=""tooltip"" data-placement=""top"" title=""Patient Details"" class=""fas fa-notes-medical""></i>
                                        </a>
                                        <a class=""btn btn-success text-white"" style=""cursor:pointer; width:50px;"" onclick=Visit(""/appointment/visit/");
#nullable restore
#line 58 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml"
                                                                                                                                               Write(appoint.AppointmentId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""")>
                                            <i data-toggle=""tooltip"" data-placement=""top"" title=""Visited"" class=""far fa-check-circle""></i>
                                        </a>
                                    </div>
                                </td>
");
#nullable restore
#line 63 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml"
                             if (appoint.IsVisited == 1)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 66 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml"
                                 if (appoint.IsPrescribed == 0)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <td class="" text-center"">
                                        <div class=""text-center"">
                                            <a class=""btn btn-primary text-white prescription"" style=""cursor:pointer; width:60px;"" data-toggle=""modal"" data-target=""#Record"" data-id=""");
#nullable restore
#line 70 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml"
                                                                                                                                                                                 Write(appoint.AppointmentId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""">
                                                <i data-toggle=""tooltip"" data-placement=""top"" title=""Prescription"" class=""fas fa-prescription-bottle-alt""></i>
                                            </a>
                                        </div>
                                    </td>
");
#nullable restore
#line 75 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 76 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml"
                                 if (appoint.IsPrescribed == 1)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <td class="" text-center"">
                                        <div class=""text-center"">
                                            <a class=""btn btn-primary text-white appdetails"" style=""cursor:pointer; width:50px;"" onclick=Details(""/appointment/patient/");
#nullable restore
#line 80 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml"
                                                                                                                                                                  Write(appoint.AppointmentId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""") >
                                                <i data-toggle=""tooltip"" data-placement=""top"" title=""Appoinment Details"" class=""fas fa-notes-medical""></i>
                                            </a>
                                        </div>
                                    </td>
");
#nullable restore
#line 85 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 85 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml"
                                 

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tr>\r\n");
#nullable restore
#line 89 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 89 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e1561d73ce768624c937450aafca36eef497db1915856", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e1561d73ce768624c937450aafca36eef497db1917075", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 101 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Doctor\Index.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AppoinmentManagment.BusinessLayer.ListAppoinmentBO> Html { get; private set; }
    }
}
#pragma warning restore 1591
