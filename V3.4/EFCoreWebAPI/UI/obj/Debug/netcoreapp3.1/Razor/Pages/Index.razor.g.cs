#pragma checksum "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cf2b64aa00168bef1f2133907a1210f6326b8d46"
// <auto-generated/>
#pragma warning disable 1591
namespace UI.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\_Imports.razor"
using UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\_Imports.razor"
using UI.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\_Imports.razor"
using Microsoft.Extensions.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\_Imports.razor"
using BlazorInputFile;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\_Imports.razor"
using MatBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\_Imports.razor"
using UI.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Index.razor"
using UI.Pages.News;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 4 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Index.razor"
 if (main != null)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(0, "    ");
            __builder.OpenComponent<UI.Pages.News.NewsCard>(1);
            __builder.AddAttribute(2, "New", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<UI.ViewModels.NewViewModel>(
#nullable restore
#line 6 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Index.razor"
                   main

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(3, "Delete", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 6 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Index.razor"
                                 false

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(4, "\r\n");
#nullable restore
#line 7 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Index.razor"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Index.razor"
 for(int i = news.Count - 1; i >= 0; i--)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(5, "    ");
            __builder.OpenComponent<UI.Pages.News.NewsCard>(6);
            __builder.AddAttribute(7, "New", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<UI.ViewModels.NewViewModel>(
#nullable restore
#line 10 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Index.razor"
                   news[i]

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(8, "\r\n");
#nullable restore
#line 11 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Index.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 16 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Index.razor"
      
    public NewViewModel main { get; set; } = new NewViewModel
    {
        date = DateTime.Now,
        name = "Welcome",
        description =
        "Welcome to our car hire website! You can hire the car here from our car list. Be sure to register and login before doing anything! And don't try to do something bad. WE ARE WATCHING YOU! Just kidding, but don't mess anything up."
    };
    public List<NewViewModel> news { get; set; } = new List<NewViewModel>();
    protected override async Task OnInitializedAsync()
    {
        news = await newsService.GetNewsAsync();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private UI.Services.NewsService newsService { get; set; }
    }
}
#pragma warning restore 1591
