#pragma checksum "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarsAdd.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a86f9dc40f01a507265c1a0a14129648e108da06"
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
#line 1 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarsAdd.razor"
using ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarsAdd.razor"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarsAdd.razor"
using System.IO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarsAdd.razor"
using Microsoft.AspNetCore.Hosting;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/cars/add")]
    public partial class CarsAdd : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "h3");
            __builder.AddContent(1, 
#nullable restore
#line 11 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarsAdd.razor"
     L["Cars add"]

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(2, "\r\n");
            __builder.OpenElement(3, "a");
            __builder.AddAttribute(4, "class", "btn btn-sm btn-primary");
            __builder.AddAttribute(5, "href", "cars/hub");
            __builder.AddContent(6, 
#nullable restore
#line 12 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarsAdd.razor"
                                                   L["Back"]

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(7, "\r\n<br>\r\n<br>\r\n\r\n");
            __builder.OpenElement(8, "p");
            __builder.AddMarkupContent(9, "\r\n    ");
            __Blazor.UI.Pages.Car.CarsAdd.TypeInference.CreateMatTextField_0(__builder, 10, 11, 
#nullable restore
#line 45 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarsAdd.razor"
                                              L["Brand"]

#line default
#line hidden
#nullable disable
            , 12, 
#nullable restore
#line 45 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarsAdd.razor"
                                Brand

#line default
#line hidden
#nullable disable
            , 13, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Brand = __value, Brand)), 14, () => Brand);
            __builder.AddMarkupContent(15, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(16, "\r\n");
            __builder.OpenElement(17, "p");
            __builder.AddMarkupContent(18, "\r\n    ");
            __Blazor.UI.Pages.Car.CarsAdd.TypeInference.CreateMatTextField_1(__builder, 19, 20, 
#nullable restore
#line 48 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarsAdd.razor"
                                              L["Price"]

#line default
#line hidden
#nullable disable
            , 21, 
#nullable restore
#line 48 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarsAdd.razor"
                                Price

#line default
#line hidden
#nullable disable
            , 22, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Price = __value, Price)), 23, () => Price);
            __builder.AddMarkupContent(24, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n");
            __builder.OpenElement(26, "p");
            __builder.AddMarkupContent(27, "\r\n    ");
            __Blazor.UI.Pages.Car.CarsAdd.TypeInference.CreateMatTextField_2(__builder, 28, 29, 
#nullable restore
#line 51 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarsAdd.razor"
                                                     L["Price per hour"]

#line default
#line hidden
#nullable disable
            , 30, 
#nullable restore
#line 51 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarsAdd.razor"
                                PricePerHour

#line default
#line hidden
#nullable disable
            , 31, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => PricePerHour = __value, PricePerHour)), 32, () => PricePerHour);
            __builder.AddMarkupContent(33, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(34, "\r\n\r\n");
            __builder.OpenElement(35, "p");
            __builder.AddMarkupContent(36, "\r\n    ");
            __Blazor.UI.Pages.Car.CarsAdd.TypeInference.CreateMatSelectItem_3(__builder, 37, 38, 
#nullable restore
#line 55 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarsAdd.razor"
                                                  CarTypeNames

#line default
#line hidden
#nullable disable
            , 39, 
#nullable restore
#line 55 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarsAdd.razor"
                                 CarType

#line default
#line hidden
#nullable disable
            , 40, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => CarType = __value, CarType)), 41, () => CarType);
            __builder.AddMarkupContent(42, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(43, "\r\n\r\n");
            __builder.OpenElement(44, "p");
            __builder.AddMarkupContent(45, "\r\n    ");
            __Blazor.UI.Pages.Car.CarsAdd.TypeInference.CreateMatTextField_4(__builder, 46, 47, 
#nullable restore
#line 59 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarsAdd.razor"
                                             L["Year"]

#line default
#line hidden
#nullable disable
            , 48, 
#nullable restore
#line 59 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarsAdd.razor"
                                Year

#line default
#line hidden
#nullable disable
            , 49, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Year = __value, Year)), 50, () => Year);
            __builder.AddMarkupContent(51, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(52, "\r\n");
            __builder.OpenElement(53, "p");
            __builder.AddMarkupContent(54, "\r\n    ");
            __Blazor.UI.Pages.Car.CarsAdd.TypeInference.CreateMatTextField_5(__builder, 55, 56, "Description", 57, 
#nullable restore
#line 62 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarsAdd.razor"
                                                                           true

#line default
#line hidden
#nullable disable
            , 58, 
#nullable restore
#line 62 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarsAdd.razor"
                                                                                           true

#line default
#line hidden
#nullable disable
            , 59, 
#nullable restore
#line 62 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarsAdd.razor"
                                Description

#line default
#line hidden
#nullable disable
            , 60, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Description = __value, Description)), 61, () => Description);
            __builder.AddMarkupContent(62, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(63, "\r\n\r\n\r\n");
            __builder.OpenComponent<BlazorInputFile.InputFile>(64);
            __builder.AddAttribute(65, "OnChange", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<BlazorInputFile.IFileListEntry[]>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<BlazorInputFile.IFileListEntry[]>(this, 
#nullable restore
#line 66 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarsAdd.razor"
                     HandleFileSelected

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(66, "\r\n");
#nullable restore
#line 67 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarsAdd.razor"
 if (file != null)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(67, "    ");
            __builder.OpenElement(68, "p");
            __builder.AddMarkupContent(69, "Загружен файл : ");
            __builder.AddContent(70, 
#nullable restore
#line 69 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarsAdd.razor"
                        file.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(71, "\r\n");
#nullable restore
#line 70 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarsAdd.razor"
}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(72, "<br>\r\n<br>\r\n\r\n");
            __builder.OpenElement(73, "button");
            __builder.AddAttribute(74, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 74 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarsAdd.razor"
                  Insert

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(75, "class", "btn btn-sm btn-primary");
            __builder.AddContent(76, 
#nullable restore
#line 74 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarsAdd.razor"
                                                          L["Insert"]

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(77, "\r\n\r\n");
            __builder.OpenElement(78, "p");
            __builder.AddContent(79, 
#nullable restore
#line 76 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarsAdd.razor"
    Error

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 79 "D:\Programms\C#\MyWebApi\MyWebApi\V3.4\EFCoreWebAPI\UI\Pages\Car\CarsAdd.razor"
       
    public string Brand { get; set; }
    public decimal Price { get; set; }
    public decimal PricePerHour { get; set; }
    public int? Year { get; set; }
    public string Description { get; set; }

    public List<CarTypeViewModel> CarTypes;
    public List<string> CarTypeNames=new List<string>();
    public string CarType { get; set; }

    public string Error { get; set; }

    IFileListEntry file;

    void HandleFileSelected(IFileListEntry[] files)
    {
        file = files.FirstOrDefault();
    }

    protected override async Task OnInitializedAsync()
    {
        CarTypes = await carTypeService.GetCarTypesAsync();
        foreach(var carType in CarTypes)
        {
            CarTypeNames.Add(carType.type);
        }
        //CarType = CarTypeNames.First();
    }

    protected async Task Insert()
    {
        try
        {
            int CarTypeId = CarTypes.First(x => x.type == CarType).id;

            string Path;
            if (file == null)
                throw new Exception("File not found");
            if (file.Type != "image/jpeg")
                throw new Exception("File in the wrong format! Please use .jpeg");
            CarViewModel car = new CarViewModel()
            {
                brand = Brand,
                price = Price,
                pricePerHour = PricePerHour,
                carTypeId = CarTypeId,
                year = Year,
                description = Description
            };
            //провалидировать модель тут

            Path = await AddFile(file);
            car.imagePath = Path;

            await carService.InsertCarAsync(car);
            ClearFields();
        }
        catch (Exception e)
        {
            Error = e.Message;
        }


    }
    protected void ClearFields()
    {
        Brand = "";
        Price = 0;
        PricePerHour = 0;
        //CarType = CarTypeNames.First();
        Description = "";
        Year = null;
        file = null;
    }
    protected async Task<string> AddFile(IFileListEntry uploadedFile)
    {
        if (uploadedFile != null)
        {
            var newFile = await uploadedFile.ToImageFileAsync("image/jpeg", 1280, 720);//resizing

            var date = DateTime.Now;
            string path = "/car_images/"
                + $"{date.Year}_{date.Month}_{date.Day}_{date.Hour}_{date.Minute}_{date.Second}_"
                + newFile.Name;//generating unique filename

            using (var filestream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await newFile.Data.CopyToAsync(filestream);//сохранение файла по пути
            }

            return path;
        }
        else
            return null;

    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IStringLocalizer<CarsAdd> L { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Services.CarTypeService carTypeService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Services.CarService carService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IWebHostEnvironment _appEnvironment { get; set; }
    }
}
namespace __Blazor.UI.Pages.Car.CarsAdd
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
        public static void CreateMatTextField_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.String __arg0, int __seq1, TValue __arg1, int __seq2, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg2, int __seq3, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg3)
        {
        __builder.OpenComponent<global::MatBlazor.MatTextField<TValue>>(seq);
        __builder.AddAttribute(__seq0, "Label", __arg0);
        __builder.AddAttribute(__seq1, "Value", __arg1);
        __builder.AddAttribute(__seq2, "ValueChanged", __arg2);
        __builder.AddAttribute(__seq3, "ValueExpression", __arg3);
        __builder.CloseComponent();
        }
        public static void CreateMatTextField_2<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.String __arg0, int __seq1, TValue __arg1, int __seq2, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg2, int __seq3, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg3)
        {
        __builder.OpenComponent<global::MatBlazor.MatTextField<TValue>>(seq);
        __builder.AddAttribute(__seq0, "Label", __arg0);
        __builder.AddAttribute(__seq1, "Value", __arg1);
        __builder.AddAttribute(__seq2, "ValueChanged", __arg2);
        __builder.AddAttribute(__seq3, "ValueExpression", __arg3);
        __builder.CloseComponent();
        }
        public static void CreateMatSelectItem_3<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Collections.Generic.IReadOnlyList<TValue> __arg0, int __seq1, TValue __arg1, int __seq2, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg2, int __seq3, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg3)
        {
        __builder.OpenComponent<global::MatBlazor.MatSelectItem<TValue>>(seq);
        __builder.AddAttribute(__seq0, "Items", __arg0);
        __builder.AddAttribute(__seq1, "Value", __arg1);
        __builder.AddAttribute(__seq2, "ValueChanged", __arg2);
        __builder.AddAttribute(__seq3, "ValueExpression", __arg3);
        __builder.CloseComponent();
        }
        public static void CreateMatTextField_4<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.String __arg0, int __seq1, TValue __arg1, int __seq2, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg2, int __seq3, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg3)
        {
        __builder.OpenComponent<global::MatBlazor.MatTextField<TValue>>(seq);
        __builder.AddAttribute(__seq0, "Label", __arg0);
        __builder.AddAttribute(__seq1, "Value", __arg1);
        __builder.AddAttribute(__seq2, "ValueChanged", __arg2);
        __builder.AddAttribute(__seq3, "ValueExpression", __arg3);
        __builder.CloseComponent();
        }
        public static void CreateMatTextField_5<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.String __arg0, int __seq1, global::System.Boolean __arg1, int __seq2, global::System.Boolean __arg2, int __seq3, TValue __arg3, int __seq4, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg4, int __seq5, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg5)
        {
        __builder.OpenComponent<global::MatBlazor.MatTextField<TValue>>(seq);
        __builder.AddAttribute(__seq0, "Label", __arg0);
        __builder.AddAttribute(__seq1, "TextArea", __arg1);
        __builder.AddAttribute(__seq2, "Outlined", __arg2);
        __builder.AddAttribute(__seq3, "Value", __arg3);
        __builder.AddAttribute(__seq4, "ValueChanged", __arg4);
        __builder.AddAttribute(__seq5, "ValueExpression", __arg5);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
