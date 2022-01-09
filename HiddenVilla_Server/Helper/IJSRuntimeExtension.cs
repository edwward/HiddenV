using Microsoft.JSInterop;

namespace HiddenVilla_Server.Helper
{
    //extension metody pro JS Runtime
    public static class IJSRuntimeExtension
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime jsRuntime, string message) 
        {
            //showtoastr je nazev js metody ke spusteni toastr (viz common.js), success je parametr k toastru
            await jsRuntime.InvokeVoidAsync("ShowToastr", "success", message);
        }
        
        public static async ValueTask ToastrError(this IJSRuntime jsRuntime, string message) 
        {
            await jsRuntime.InvokeVoidAsync("ShowToastr", "error", message);
        }
    }
}
