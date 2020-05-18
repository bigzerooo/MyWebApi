#pragma checksum "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\Car.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "55bee7e980c0b337e8f94aea7cd4504aa9310585"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace UI.Pages.Car
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
#line 2 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\Car.razor"
using UI.ViewModels;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/cars/{id}")]
    public partial class Car : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 24 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\Car.razor"
       
    CarViewModel car;
    string carType { get; set; }
    string imagePath;
    [Parameter]
    public string Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
        car = await carService.GetCarsByIdAsync(Int32.Parse(Id));
        if (string.IsNullOrWhiteSpace(car.imagePath))
            imagePath = "/car_images/unknown.jpg";
        else
            imagePath = car.imagePath;
        carType = await carTypeService.GetCarTypeByIdAsync(car.carTypeId);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private UI.Services.CarTypeService carTypeService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private UI.Services.CarService carService { get; set; }
    }
}
#pragma warning restore 1591
