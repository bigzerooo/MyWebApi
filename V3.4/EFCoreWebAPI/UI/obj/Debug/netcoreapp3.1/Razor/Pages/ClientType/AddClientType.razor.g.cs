#pragma checksum "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\ClientType\AddClientType.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5cd13c70e6a88a87a8d0467a82d1f03021f9ac97"
// <auto-generated/>
#pragma warning disable 1591
namespace UI.Pages.ClientType
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
#line 4 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\ClientType\AddClientType.razor"
           [Authorize(Roles = "admin")]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/clienttypes/add")]
    public partial class AddClientType : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "h3");
            __builder.AddContent(1, 
#nullable restore
#line 6 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\ClientType\AddClientType.razor"
     L["Add client type"]

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(2, "\r\n<hr>\r\n");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(3);
            __builder.AddAttribute(4, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 8 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\ClientType\AddClientType.razor"
                  clientType

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(5, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 8 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\ClientType\AddClientType.razor"
                                              Add

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(6, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(7, "\r\n    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.FluentValidator>(8);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(9, "\r\n    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(10);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(11, "\r\n    ");
                __builder2.OpenElement(12, "p");
                __builder2.AddContent(13, 
#nullable restore
#line 11 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\ClientType\AddClientType.razor"
        Error

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(14, "\r\n    ");
                __builder2.OpenElement(15, "p");
                __builder2.AddMarkupContent(16, "\r\n        ");
                __Blazor.UI.Pages.ClientType.AddClientType.TypeInference.CreateMatTextField_0(__builder2, 17, 18, 
#nullable restore
#line 13 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\ClientType\AddClientType.razor"
                                                             L["Client type"]

#line default
#line hidden
#nullable disable
                , 19, 
#nullable restore
#line 13 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\ClientType\AddClientType.razor"
                                    clientType.type

#line default
#line hidden
#nullable disable
                , 20, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => clientType.type = __value, clientType.type)), 21, () => clientType.type);
                __builder2.AddMarkupContent(22, "\r\n    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(23, "\r\n    ");
                __builder2.OpenElement(24, "button");
                __builder2.AddAttribute(25, "type", "submit");
                __builder2.AddAttribute(26, "class", "btn btn-sm btn-primary");
                __builder2.AddContent(27, 
#nullable restore
#line 15 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\ClientType\AddClientType.razor"
                                                          L["Add"]

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(28, "\r\n");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 17 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\ClientType\AddClientType.razor"
       
    ClientTypeViewModel clientType { get; set; } = new ClientTypeViewModel();
    string Error { get; set; } = "";
    protected async Task Add()
    {
        Error = "";
        var result = await clientTypeService.AddClientTypeAsync(clientType);
        if (result.IsSuccessStatusCode)
            navigationManager.NavigateTo("/clienttypes");
        else
            Error = result.StatusCode.ToString();
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IStringLocalizer<AddClientType> L { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager navigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private UI.Services.ClientTypeService clientTypeService { get; set; }
    }
}
namespace __Blazor.UI.Pages.ClientType.AddClientType
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateMatTextField_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.String __arg0, int __seq1, TValue __arg1, int __seq2, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg2, int __seq3, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg3)
        {
        __builder.OpenComponent<global::MatBlazor.MatTextField<TValue>>(seq);
        __builder.AddAttribute(__seq0, "Label", __arg0);
        __builder.AddAttribute(__seq1, "Value", __arg1);
        __builder.AddAttribute(__seq2, "ValueChanged", __arg2);
        __builder.AddAttribute(__seq3, "ValueExpression", __arg3);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591