#pragma checksum "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\CarHire\UnreturnedCarHires.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d77f721e1a1eab6d0beeeba6596825864b5cac79"
// <auto-generated/>
#pragma warning disable 1591
namespace UI.Pages.CarHire
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
#line 5 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\CarHire\UnreturnedCarHires.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/unreturnedcarhires")]
    public partial class UnreturnedCarHires : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "h3");
            __builder.AddContent(1, 
#nullable restore
#line 6 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\CarHire\UnreturnedCarHires.razor"
     L["Unreturned car"]

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(2, "\r\n");
            __builder.OpenElement(3, "table");
            __builder.AddAttribute(4, "class", "table table-condensed table-striped table-bordered");
            __builder.AddMarkupContent(5, "\r\n    ");
            __builder.OpenElement(6, "tr");
            __builder.AddMarkupContent(7, "\r\n        ");
            __builder.OpenElement(8, "th");
            __builder.AddContent(9, 
#nullable restore
#line 9 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\CarHire\UnreturnedCarHires.razor"
             L["Car"]

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n        ");
            __builder.OpenElement(11, "th");
            __builder.AddContent(12, 
#nullable restore
#line 10 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\CarHire\UnreturnedCarHires.razor"
             L["Begin date"]

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n        ");
            __builder.OpenElement(14, "th");
            __builder.AddContent(15, 
#nullable restore
#line 11 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\CarHire\UnreturnedCarHires.razor"
             L["Expected end date"]

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(16, "\r\n        ");
            __builder.OpenElement(17, "th");
            __builder.AddContent(18, 
#nullable restore
#line 12 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\CarHire\UnreturnedCarHires.razor"
             L["Expected price"]

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\r\n    <th></th>\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n");
#nullable restore
#line 15 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\CarHire\UnreturnedCarHires.razor"
     foreach (var carHire in carHires)
    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(21, "        ");
            __builder.OpenElement(22, "tr");
            __builder.AddMarkupContent(23, "\r\n            ");
            __builder.OpenElement(24, "td");
            __builder.OpenElement(25, "a");
            __builder.AddAttribute(26, "class", "btn btn-primary");
            __builder.AddAttribute(27, "href", "/cars/" + (
#nullable restore
#line 18 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\CarHire\UnreturnedCarHires.razor"
                                                        carHire.carId

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(28, 
#nullable restore
#line 18 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\CarHire\UnreturnedCarHires.razor"
                                                                        L["Car"]

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(29, "\r\n            ");
            __builder.OpenElement(30, "td");
            __builder.AddContent(31, 
#nullable restore
#line 19 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\CarHire\UnreturnedCarHires.razor"
                 carHire.beginDate

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\r\n            ");
            __builder.OpenElement(33, "td");
            __builder.AddContent(34, 
#nullable restore
#line 20 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\CarHire\UnreturnedCarHires.razor"
                 carHire.expectedEndDate

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(35, "\r\n            ");
            __builder.OpenElement(36, "td");
            __builder.AddContent(37, 
#nullable restore
#line 21 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\CarHire\UnreturnedCarHires.razor"
                 carHire.expectedPrice

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(38, "\r\n            ");
            __builder.OpenElement(39, "td");
            __builder.OpenElement(40, "a");
            __builder.AddAttribute(41, "class", "btn btn-primary");
            __builder.AddAttribute(42, "href", "/carreturn/" + (
#nullable restore
#line 22 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\CarHire\UnreturnedCarHires.razor"
                                                             carHire.id

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(43, 
#nullable restore
#line 22 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\CarHire\UnreturnedCarHires.razor"
                                                                          L["Return"]

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(44, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(45, "\r\n");
#nullable restore
#line 24 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\CarHire\UnreturnedCarHires.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 26 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\CarHire\UnreturnedCarHires.razor"
       
    List<CarHireViewModel> carHires { get; set; } = new List<CarHireViewModel>();
    protected override async Task OnInitializedAsync()
    {
        var authState = await authentificationStateProvider.GetAuthenticationStateAsync();
        var clientId = authState.User.Claims.First(x => x.Type == "clientId").Value;

        carHires = await carHireService.GetUnreturnedCarHiresByClientIdAsync(clientId);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IStringLocalizer<UnreturnedCarHires> L { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider authentificationStateProvider { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private UI.Services.CarHiresService carHireService { get; set; }
    }
}
#pragma warning restore 1591
