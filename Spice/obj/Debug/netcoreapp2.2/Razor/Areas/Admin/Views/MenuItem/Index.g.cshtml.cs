#pragma checksum "D:\Users\Carlos M\Source\repos\Spice\Spice\Areas\Admin\Views\MenuItem\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8504b459d043813a49dea8ba3071b15a5017982b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_MenuItem_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/MenuItem/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/MenuItem/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_MenuItem_Index))]
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
#line 1 "D:\Users\Carlos M\Source\repos\Spice\Spice\Areas\Admin\Views\_ViewImports.cshtml"
using Spice;

#line default
#line hidden
#line 2 "D:\Users\Carlos M\Source\repos\Spice\Spice\Areas\Admin\Views\_ViewImports.cshtml"
using Spice.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8504b459d043813a49dea8ba3071b15a5017982b", @"/Areas/Admin/Views/MenuItem/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6c1390ba8093fb4c2e21d25b459146d9962f6bcb", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_MenuItem_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MenuItem>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_CreateButtonPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_TableButtonPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(30, 4, true);
            WriteLiteral("    ");
            EndContext();
#line 2 "D:\Users\Carlos M\Source\repos\Spice\Spice\Areas\Admin\Views\MenuItem\Index.cshtml"
      
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";
    

#line default
#line hidden
            BeginContext(126, 263, true);
            WriteLiteral(@"
    <br /><br />

    <div class=""border backgroundWhite"">
        <div class=""row"">
            <div class=""col-6"">
                <h2 class=""text-info"">Menu Item List</h2>
            </div>
            <div class=""col-6 text-right"">
                ");
            EndContext();
            BeginContext(389, 39, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8504b459d043813a49dea8ba3071b15a5017982b4500", async() => {
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
            EndContext();
            BeginContext(428, 73, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <br />\r\n    <div>\r\n");
            EndContext();
#line 21 "D:\Users\Carlos M\Source\repos\Spice\Spice\Areas\Admin\Views\MenuItem\Index.cshtml"
         if (Model.Any())
    {

#line default
#line hidden
            BeginContext(535, 136, true);
            WriteLiteral("        <table class=\"table table-striped border\">\r\n            <tr class=\"table-secondary\">\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(672, 32, false);
#line 26 "D:\Users\Carlos M\Source\repos\Spice\Spice\Areas\Admin\Views\MenuItem\Index.cshtml"
               Write(Html.DisplayNameFor(c => c.Name));

#line default
#line hidden
            EndContext();
            BeginContext(704, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(772, 33, false);
#line 29 "D:\Users\Carlos M\Source\repos\Spice\Spice\Areas\Admin\Views\MenuItem\Index.cshtml"
               Write(Html.DisplayNameFor(c => c.Price));

#line default
#line hidden
            EndContext();
            BeginContext(805, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(873, 38, false);
#line 32 "D:\Users\Carlos M\Source\repos\Spice\Spice\Areas\Admin\Views\MenuItem\Index.cshtml"
               Write(Html.DisplayNameFor(c => c.CategoryId));

#line default
#line hidden
            EndContext();
            BeginContext(911, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(979, 41, false);
#line 35 "D:\Users\Carlos M\Source\repos\Spice\Spice\Areas\Admin\Views\MenuItem\Index.cshtml"
               Write(Html.DisplayNameFor(c => c.SubCategoryId));

#line default
#line hidden
            EndContext();
            BeginContext(1020, 98, true);
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n                <th></th>\r\n            </tr>\r\n");
            EndContext();
#line 40 "D:\Users\Carlos M\Source\repos\Spice\Spice\Areas\Admin\Views\MenuItem\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(1175, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1224, 31, false);
#line 44 "D:\Users\Carlos M\Source\repos\Spice\Spice\Areas\Admin\Views\MenuItem\Index.cshtml"
           Write(Html.DisplayFor(c => item.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1255, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1311, 32, false);
#line 47 "D:\Users\Carlos M\Source\repos\Spice\Spice\Areas\Admin\Views\MenuItem\Index.cshtml"
           Write(Html.DisplayFor(c => item.Price));

#line default
#line hidden
            EndContext();
            BeginContext(1343, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1399, 40, false);
#line 50 "D:\Users\Carlos M\Source\repos\Spice\Spice\Areas\Admin\Views\MenuItem\Index.cshtml"
           Write(Html.DisplayFor(c => item.Category.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1439, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1495, 43, false);
#line 53 "D:\Users\Carlos M\Source\repos\Spice\Spice\Areas\Admin\Views\MenuItem\Index.cshtml"
           Write(Html.DisplayFor(c => item.SubCategory.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1538, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1593, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8504b459d043813a49dea8ba3071b15a5017982b10002", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#line 56 "D:\Users\Carlos M\Source\repos\Spice\Spice\Areas\Admin\Views\MenuItem\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = item.Id;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1647, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 59 "D:\Users\Carlos M\Source\repos\Spice\Spice\Areas\Admin\Views\MenuItem\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(1698, 18, true);
            WriteLiteral("        </table>\r\n");
            EndContext();
#line 61 "D:\Users\Carlos M\Source\repos\Spice\Spice\Areas\Admin\Views\MenuItem\Index.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(1740, 54, true);
            WriteLiteral("        <p>There are no Menu Items at this time.</p>\r\n");
            EndContext();
#line 65 "D:\Users\Carlos M\Source\repos\Spice\Spice\Areas\Admin\Views\MenuItem\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(1801, 12, true);
            WriteLiteral("    </div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MenuItem>> Html { get; private set; }
    }
}
#pragma warning restore 1591
