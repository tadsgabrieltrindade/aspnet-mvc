#pragma checksum "C:\Users\icand\Documents\Projetos\ASPNET MVC\FirstAPPInMVC\FirstAPPInMVC\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "30ccab439e7c7fb0dad7d242f1ef8adfbb05246b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\icand\Documents\Projetos\ASPNET MVC\FirstAPPInMVC\FirstAPPInMVC\Views\_ViewImports.cshtml"
using FirstAPPInMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\icand\Documents\Projetos\ASPNET MVC\FirstAPPInMVC\FirstAPPInMVC\Views\_ViewImports.cshtml"
using FirstAPPInMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30ccab439e7c7fb0dad7d242f1ef8adfbb05246b", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"21852f04b4f0f882894e16691635bda12dc96cef", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HomeModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\icand\Documents\Projetos\ASPNET MVC\FirstAPPInMVC\FirstAPPInMVC\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Página principal";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">");
#nullable restore
#line 8 "C:\Users\icand\Documents\Projetos\ASPNET MVC\FirstAPPInMVC\FirstAPPInMVC\Views\Home\Index.cshtml"
                     Write(Model.nome);

#line default
#line hidden
#nullable disable
            WriteLiteral(", Bem vindo ao Site!</h1>\r\n    <p>Aprendendo e desenvolvendo juntos, pois assim somos mais fortes.</p>\r\n    <p>Mandaremos mais detalhes em seu e-mail cadastrado: ");
#nullable restore
#line 10 "C:\Users\icand\Documents\Projetos\ASPNET MVC\FirstAPPInMVC\FirstAPPInMVC\Views\Home\Index.cshtml"
                                                     Write(Model.email);

#line default
#line hidden
#nullable disable
            WriteLiteral(".</p>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HomeModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
