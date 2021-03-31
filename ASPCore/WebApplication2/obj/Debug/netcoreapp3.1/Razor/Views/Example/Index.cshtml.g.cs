#pragma checksum "C:\Users\Adil\Source\Repos\DI_in_NetCore\ASPCore\WebApplication2\Views\Example\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c5523d550e40d1585b3eeb0b6659badb2c1bef70"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Example_Index), @"mvc.1.0.view", @"/Views/Example/Index.cshtml")]
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
#line 1 "C:\Users\Adil\Source\Repos\DI_in_NetCore\ASPCore\WebApplication2\Views\_ViewImports.cshtml"
using WebApplication2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Adil\Source\Repos\DI_in_NetCore\ASPCore\WebApplication2\Views\_ViewImports.cshtml"
using WebApplication2.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Adil\Source\Repos\DI_in_NetCore\ASPCore\WebApplication2\Views\Example\Index.cshtml"
using WebApplication2.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Adil\Source\Repos\DI_in_NetCore\ASPCore\WebApplication2\Views\Example\Index.cshtml"
using WebApplication2.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5523d550e40d1585b3eeb0b6659badb2c1bef70", @"/Views/Example/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b36aee4455a440795f240a74431c307640c545e", @"/Views/_ViewImports.cshtml")]
    public class Views_Example_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\Adil\Source\Repos\DI_in_NetCore\ASPCore\WebApplication2\Views\Example\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\Users\Adil\Source\Repos\DI_in_NetCore\ASPCore\WebApplication2\Views\Example\Index.cshtml"
  
    IExampleTransient transient = (IExampleTransient)ViewData["Transient"];
    IExampleTransient scoped = (IExampleTransient)ViewData["Scoped"];
    IExampleTransient singleton = (IExampleTransient)ViewData["Singleton"];
    IExampleTransient singletonInstance = (IExampleTransient)ViewData["SingletonInstance"];

    ExampleService service = (ExampleService)ViewBag.Service;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Lifetimes</h2>\r\n<h3>ExampleController Dependencies</h3>\r\n<table>\r\n    <tr>\r\n        <th>Lifestyle</th>\r\n        <th>Guid Value</th>\r\n    </tr>\r\n    <tr>\r\n        <td>Transient</td>\r\n        <td>");
#nullable restore
#line 26 "C:\Users\Adil\Source\Repos\DI_in_NetCore\ASPCore\WebApplication2\Views\Example\Index.cshtml"
       Write(transient.ExampleId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n    <tr>\r\n        <td>Scoped</td>\r\n        <td>");
#nullable restore
#line 30 "C:\Users\Adil\Source\Repos\DI_in_NetCore\ASPCore\WebApplication2\Views\Example\Index.cshtml"
       Write(scoped.ExampleId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n    <tr>\r\n        <td>Singleton</td>\r\n        <td>");
#nullable restore
#line 34 "C:\Users\Adil\Source\Repos\DI_in_NetCore\ASPCore\WebApplication2\Views\Example\Index.cshtml"
       Write(singleton.ExampleId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n    <tr>\r\n        <td>Instance</td>\r\n        <td>");
#nullable restore
#line 38 "C:\Users\Adil\Source\Repos\DI_in_NetCore\ASPCore\WebApplication2\Views\Example\Index.cshtml"
       Write(singletonInstance.ExampleId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n</table>\r\n\r\n<h3>ExampleService Dependencies</h3>\r\n<table>\r\n    <tr>\r\n        <th>Lifestyle</th>\r\n        <th>Guid Value</th>\r\n    </tr>\r\n    <tr>\r\n        <td>Transient</td>\r\n        <td>");
#nullable restore
#line 50 "C:\Users\Adil\Source\Repos\DI_in_NetCore\ASPCore\WebApplication2\Views\Example\Index.cshtml"
       Write(service.TransientExample.ExampleId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n    <tr>\r\n        <td>Scoped</td>\r\n        <td>");
#nullable restore
#line 54 "C:\Users\Adil\Source\Repos\DI_in_NetCore\ASPCore\WebApplication2\Views\Example\Index.cshtml"
       Write(service.ScopedExample.ExampleId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n    <tr>\r\n        <td>Singleton</td>\r\n        <td>");
#nullable restore
#line 58 "C:\Users\Adil\Source\Repos\DI_in_NetCore\ASPCore\WebApplication2\Views\Example\Index.cshtml"
       Write(service.SingletonExample.ExampleId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n    <tr>\r\n        <td>Instance</td>\r\n        <td>");
#nullable restore
#line 62 "C:\Users\Adil\Source\Repos\DI_in_NetCore\ASPCore\WebApplication2\Views\Example\Index.cshtml"
       Write(service.SingletonInstanceExample.ExampleId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n</table>");
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
