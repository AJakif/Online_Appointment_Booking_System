#pragma checksum "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Home\AccessDenied.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2757fbfc85ab479d48f3c4d7611fdd9d55c9bd27"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AppoinmentManagment.Pages.Home.Views_Home_AccessDenied), @"mvc.1.0.view", @"/Views/Home/AccessDenied.cshtml")]
namespace AppoinmentManagment.Pages.Home
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2757fbfc85ab479d48f3c4d7611fdd9d55c9bd27", @"/Views/Home/AccessDenied.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab6442c0e4490c61560fc742add77483583ac211", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_AccessDenied : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\Projects\Online Appointment Booking System\API\AppoinmentManagment\Views\Home\AccessDenied.cshtml"
  
    ViewData["Title"] = "AccessDenied";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <h1 class=\"align-middle text-center text-danger\">You do not have access to this resource</h1>\r\n    <p class=\"align-middle text-center\">Access Forbiden <b class=\"text-danger\">403</b></p>\r\n\r\n");
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
