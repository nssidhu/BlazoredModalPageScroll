using BlazorApp3.Shared;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorApp3.Pages
{
    public partial  class Index
    {
        [CascadingParameter] 
        public IModalService Modal { get; set; }
        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                for (int i = 0; i < 50; i++)
                {
                    list.Add("This is item " + i.ToString());
                }
            }
          
            await  base.OnAfterRenderAsync(firstRender);
            return;
        }

        List<string> list = new List<string>();
        string message = "";
        ModalOptions options = new ModalOptions
        {
            HideCloseButton = true,
            DisableBackgroundCancel = true,
            HideHeader = true

        };

        private async Task Calculate()
        {
           
            var modalRef = Modal?.Show<LoadingSpinner>(string.Empty, options);
            try
            {
                          
                message = "";
              
               await Task.Delay(2000);
                message = "completed";
                StateHasChanged();
             
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if(modalRef != null)
                    modalRef.Close();
            }
        }
    }
}
