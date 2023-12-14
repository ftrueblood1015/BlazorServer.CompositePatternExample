using BlazorServer.CompositePatternExample.Services.Directories;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.CompositePatternExample.Pages.Directories
{
    public partial class RootDirectories
    {
        [Inject]
        private IDirectoryService? DirectoryService { get; set; }

        [Inject]
        private NavigationManager? NavigationManager { get; set; }

        private List<Domain.Models.Directory> Directories { get; set; }

        private string? Title = "RootDirectories";

        private string? SearchString { get; set; }

        protected override async Task OnInitializedAsync()
        {
            GetData();
        }

        public void GetData()
        {
            if (DirectoryService == null)
            {
                throw new Exception($"{nameof(DirectoryService)}  is null!");
            }
            var Response = DirectoryService.Filter(x => x.IsRoot == true);
            Directories = Response != null ? Response.ToList() : new List<Domain.Models.Directory>();
            StateHasChanged();
        }

        private Func<Domain.Models.Directory, bool> QuickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(SearchString))
                return true;

            if (x.Name!.Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if ($"{x.Name!}".Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if ($"{x.IsRoot!}".Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        };

        private void View(Domain.Models.Directory item)
        {
            if (NavigationManager == null)
            {
                return;
            }

            NavigationManager.NavigateTo($"/directorydetail/{item.Id}");

        }
    }
}
