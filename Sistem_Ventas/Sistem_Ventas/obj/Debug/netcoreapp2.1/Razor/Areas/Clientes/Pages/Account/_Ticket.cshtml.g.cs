#pragma checksum "C:\Users\Cristopher Solano\Downloads\Sistem-Ventas-video-71\Sistem_Ventas\Sistem_Ventas\Areas\Clientes\Pages\Account\_Ticket.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "982d7c94b75bef74d3926f65b09b0e01ab8cb221"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Sistem_Ventas.Areas.Clientes.Pages.Account.Areas_Clientes_Pages_Account__Ticket), @"mvc.1.0.view", @"/Areas/Clientes/Pages/Account/_Ticket.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Clientes/Pages/Account/_Ticket.cshtml", typeof(Sistem_Ventas.Areas.Clientes.Pages.Account.Areas_Clientes_Pages_Account__Ticket))]
namespace Sistem_Ventas.Areas.Clientes.Pages.Account
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Cristopher Solano\Downloads\Sistem-Ventas-video-71\Sistem_Ventas\Sistem_Ventas\Areas\Clientes\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\Cristopher Solano\Downloads\Sistem-Ventas-video-71\Sistem_Ventas\Sistem_Ventas\Areas\Clientes\Pages\_ViewImports.cshtml"
using Sistem_Ventas.Areas.Clientes;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"982d7c94b75bef74d3926f65b09b0e01ab8cb221", @"/Areas/Clientes/Pages/Account/_Ticket.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3fca9541fe682b79b856523a4f0bdef4ede9c72", @"/Areas/Clientes/Pages/_ViewImports.cshtml")]
    public class Areas_Clientes_Pages_Account__Ticket : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ReportesModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("responsive"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/iconos/Clientes2.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Cristopher Solano\Downloads\Sistem-Ventas-video-71\Sistem_Ventas\Sistem_Ventas\Areas\Clientes\Pages\Account\_Ticket.cshtml"
   
    var nombre = Model.Input.Nombre + " " + Model.Input.Apellido;

#line default
#line hidden
            BeginContext(97, 228, true);
            WriteLiteral("\r\n    <div id=\"ticket\">\r\n        <center>\r\n            <h5> Ticket de: CW </h5><br />\r\n        </center>\r\n        <ul class=\"collapsible\">\r\n            <li>\r\n                <div class=\"collapsible-header\">\r\n                    ");
            EndContext();
            BeginContext(325, 62, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5650066b55e340538e1eb969ecc87836", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(387, 9, true);
            WriteLiteral("Cliente: ");
            EndContext();
            BeginContext(397, 6, false);
#line 13 "C:\Users\Cristopher Solano\Downloads\Sistem-Ventas-video-71\Sistem_Ventas\Sistem_Ventas\Areas\Clientes\Pages\Account\_Ticket.cshtml"
                                                                                      Write(nombre);

#line default
#line hidden
            EndContext();
            BeginContext(403, 896, true);
            WriteLiteral(@"
                </div>
                <div class=""collapsible-bod"">
                    <table class=""table"">
                        <thead>
                            <tr>
                                <th>
                                    Deuda
                                </th>
                                <th>
                                    Fecha Deuda
                                </th>
                                <th>
                                    Pago
                                </th>
                                <th>
                                    Fecha Pago
                                </th>
                                <th>
                                    Ticket
                                </th>
                            </tr>
                        </thead>
                        <tbody>
");
            EndContext();
#line 37 "C:\Users\Cristopher Solano\Downloads\Sistem-Ventas-video-71\Sistem_Ventas\Sistem_Ventas\Areas\Clientes\Pages\Account\_Ticket.cshtml"
                             foreach (var item in Model.Input.ClienteReport)
                            {

#line default
#line hidden
            BeginContext(1408, 120, true);
            WriteLiteral("                                <tr>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(1529, 40, false);
#line 41 "C:\Users\Cristopher Solano\Downloads\Sistem-Ventas-video-71\Sistem_Ventas\Sistem_Ventas\Areas\Clientes\Pages\Account\_Ticket.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Deuda));

#line default
#line hidden
            EndContext();
            BeginContext(1569, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(1697, 45, false);
#line 44 "C:\Users\Cristopher Solano\Downloads\Sistem-Ventas-video-71\Sistem_Ventas\Sistem_Ventas\Areas\Clientes\Pages\Account\_Ticket.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.FechaDeuda));

#line default
#line hidden
            EndContext();
            BeginContext(1742, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(1870, 39, false);
#line 47 "C:\Users\Cristopher Solano\Downloads\Sistem-Ventas-video-71\Sistem_Ventas\Sistem_Ventas\Areas\Clientes\Pages\Account\_Ticket.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Pago));

#line default
#line hidden
            EndContext();
            BeginContext(1909, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(2037, 44, false);
#line 50 "C:\Users\Cristopher Solano\Downloads\Sistem-Ventas-video-71\Sistem_Ventas\Sistem_Ventas\Areas\Clientes\Pages\Account\_Ticket.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.FechaPago));

#line default
#line hidden
            EndContext();
            BeginContext(2081, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(2209, 41, false);
#line 53 "C:\Users\Cristopher Solano\Downloads\Sistem-Ventas-video-71\Sistem_Ventas\Sistem_Ventas\Areas\Clientes\Pages\Account\_Ticket.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Ticket));

#line default
#line hidden
            EndContext();
            BeginContext(2250, 84, true);
            WriteLiteral("\r\n                                    </td>\r\n                                </tr>\r\n");
            EndContext();
#line 56 "C:\Users\Cristopher Solano\Downloads\Sistem-Ventas-video-71\Sistem_Ventas\Sistem_Ventas\Areas\Clientes\Pages\Account\_Ticket.cshtml"
                            }

#line default
#line hidden
            BeginContext(2365, 151, true);
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n             \r\n                </div>\r\n            </li>\r\n        </ul>\r\n\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ReportesModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
