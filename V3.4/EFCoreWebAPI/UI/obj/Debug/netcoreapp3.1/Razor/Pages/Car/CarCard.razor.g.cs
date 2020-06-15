#pragma checksum "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarCard.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bd611defea4b0f41da124e508147bfd5c1773bec"
// <auto-generated/>
#pragma warning disable 1591
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
#line 13 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\_Imports.razor"
using UI.ViewModels;

#line default
#line hidden
#nullable disable
    public partial class CarCard : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "product-item");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "product-img");
            __builder.AddMarkupContent(5, "\r\n        ");
            __builder.OpenElement(6, "a");
            __builder.AddAttribute(7, "href", "cars/" + (
#nullable restore
#line 4 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarCard.razor"
                       Id

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(8, "\r\n");
#nullable restore
#line 5 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarCard.razor"
             if (String.IsNullOrWhiteSpace(ImageSource))
            {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(9, "                <img src=\"/default_images/unknown.jpg\">\r\n");
#nullable restore
#line 8 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarCard.razor"
            }
            else
            {

#line default
#line hidden
#nullable disable
            __builder.AddContent(10, "                ");
            __builder.OpenElement(11, "img");
            __builder.AddAttribute(12, "src", 
#nullable restore
#line 11 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarCard.razor"
                           ImageSource

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n");
#nullable restore
#line 12 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarCard.razor"

            }

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(14, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(16, "\r\n    ");
            __builder.OpenElement(17, "div");
            __builder.AddAttribute(18, "class", "product-list");
            __builder.AddMarkupContent(19, "\r\n        ");
            __builder.OpenElement(20, "h3");
            __builder.AddContent(21, 
#nullable restore
#line 18 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarCard.razor"
             CarName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(22, "        \r\n        ");
            __builder.OpenElement(23, "span");
            __builder.AddAttribute(24, "class", "price");
            __builder.AddContent(25, 
#nullable restore
#line 19 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarCard.razor"
                             L["Price"]

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(26, ": $");
            __builder.AddContent(27, 
#nullable restore
#line 19 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarCard.razor"
                                           Price

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(28, "\r\n        ");
            __builder.OpenElement(29, "span");
            __builder.AddAttribute(30, "class", "price");
            __builder.AddContent(31, 
#nullable restore
#line 20 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarCard.razor"
                             L["Price per hour"]

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(32, ": $");
            __builder.AddContent(33, 
#nullable restore
#line 20 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarCard.razor"
                                                    PricePerHour

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(34, "        \r\n        ");
            __builder.OpenElement(35, "div");
            __builder.AddAttribute(36, "class", "actions");
            __builder.AddMarkupContent(37, "\r\n            ");
            __builder.OpenElement(38, "div");
            __builder.AddAttribute(39, "class", "add-to-cart");
            __builder.AddMarkupContent(40, "\r\n                ");
            __builder.OpenElement(41, "a");
            __builder.AddAttribute(42, "href", "cars/" + (
#nullable restore
#line 23 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarCard.razor"
                               Id

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(43, "class", "cart-button");
            __builder.AddContent(44, 
#nullable restore
#line 23 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarCard.razor"
                                                        L["View"]

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(45, "\r\n                ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(46);
            __builder.AddAttribute(47, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(48, "\r\n                        ");
                __builder2.OpenElement(49, "a");
                __builder2.AddAttribute(50, "href", "/HireTheCar/" + (
#nullable restore
#line 26 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarCard.razor"
                                              Id

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(51, "class", "cart-button");
                __builder2.AddContent(52, 
#nullable restore
#line 26 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarCard.razor"
                                                                       L["Hire the car"]

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(53, "\r\n                    ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(54, "\r\n                \r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(55, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(56, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(57, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(58, "\r\n");
            __builder.AddMarkupContent(59, @"<style>
    * {box-sizing: border-box;}
.product-item {
  width: 300px;
  margin: 0 auto;
  padding: 10px 10px 5px 10px;
  border: 1px solid #eee;
  background: white;
  font-family: ""Open Sans"";
  overflow: hidden;
  transition: .4s linear;
  
  margin: 5px;
}
.product-item:hover {transform: scale(1.1);}
.product-img {transition: 1s ease-in-out;}
.product-img img {
  display: block;
  width: 100%;
}
.product-list {margin-top: 15px;}
.product-list h3 {
  font-weight: 700;
  color: #39404B;
  margin: 0;
  text-transform: uppercase;
  font-size: 14px;
  line-height: 2;
}
.price {
  color: #000000;
  display: block;
  margin-bottom: 12px;
}
.actions {
  border-top: 1px solid #eee;
  padding-top: 4px;
  font-size: 13px;
  height: 30px;
  line-height: 30px;
}
    .actions:after {
        content: """";
        display: table;
        clear: both;
    }
.add-to-cart {float: left;}
.cart-button {
  text-decoration: none;
  color: #8C877C;
  padding-right: 20px;
  border-right: 1px solid #ddd;
  transition: .4s linear;
}
.cart-button:before {
  content: ""\f07a"";
  font-family: FontAwesome;
  margin-right: 10px;
}
.add-to-cart:hover .cart-button {color: #E34D38;}
</style>");
        }
        #pragma warning restore 1998
#nullable restore
#line 95 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarCard.razor"
       

    [Parameter]
    public string Id { get; set; }
    [Parameter]
    public string ImageSource { get; set; }
    [Parameter]
    public string CarName { get; set; }
    [Parameter]
    public string Price { get; set; }
    [Parameter]
    public string PricePerHour { get; set; }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IStringLocalizer<CarCard> L { get; set; }
    }
}
#pragma warning restore 1591