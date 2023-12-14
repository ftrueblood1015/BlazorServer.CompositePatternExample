using BlazorServer.CompositePatternExample.Services.Directories;
using BlazorServer.CompositePatternExample.Services.Files;
using BlazorServer.CompositePatternExample.Services.SizeCaluclators;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorServer.CompositePatternExample.Pages.Directories
{
    public partial class DirectoryDetail
    {
        [Inject]
        private IDirectoryService? DirectoryService { get; set; }

        [Inject]
        private IFileService? FileService { get; set; }

        [Inject]
        private NavigationManager? NavigationManager { get; set; }

        [Inject]
        private ISnackbar? SnackbarService { get; set; }

        [Inject]
        private IDirectorySizeCalculatorService? DirectorySizeCalculatorService { get; set; }

        [Parameter]
        public int DirectoryId { get; set; }

        private Domain.Models.Directory Directory { get; set; }

        private List<Domain.Models.Directory> DirectoryList { get; set; }

        public Color Color { get; set; } = Color.Success;

        string SelectedValue { get; set; }

        protected override async Task OnInitializedAsync()
        {
            DirectoryList = new List<Domain.Models.Directory>();
            GetDirectory();
        }

        private void GetDirectory()
        {
            if (DirectoryService == null)
            {
                ShowSnackbarMessage("Could Not Load Directory", Color.Error);
                throw new Exception($"{nameof(DirectoryService)}  is null!");
            }

            Directory = DirectoryService.GetById(DirectoryId) ?? new Domain.Models.Directory();
            ShowSnackbarMessage("Directory Has Been Loaded", Color.Success);
            BuildDirectoryTree(Directory);
            StateHasChanged();
        }

        public void ShowSnackbarMessage(string Message, MudBlazor.Color Color)
        {
            if (SnackbarService == null)
            {
                throw new ArgumentNullException(nameof(SnackbarService));
            }

            SnackbarService.Add<MudChip>(new Dictionary<string, object>() {
                { "Text", $"{Message}" },
                { "Color", Color }
            });
        }

        private void BuildDirectoryTree(Domain.Models.Directory directory)
        {
            if (DirectoryService == null)
            {
                ShowSnackbarMessage("Could Not Load Directories", Color.Error);
                throw new Exception($"{nameof(DirectoryService)}  is null!");
            }

            if (!DirectoryList.Any(item => item.Id == directory.Id))
            {
                DirectoryList.Add(directory);
            }

            var DirectoriesList = new List<Domain.Models.Directory>();
            DirectoriesList.Add(directory);

            foreach (var dir in DirectoriesList)
            {
                var directories = DirectoryService.Filter(x => x.DirectoryId == dir.Id && x.IsRoot == false && x.Id != dir.Id);

                foreach (var d in directories)
                {
                    BuildDirectoryTree(d);
                }
            }
        }

        public List<Domain.Models.File> GetFiles(int? DirectoryId)
        {
            if (FileService == null)
            {
                throw new Exception($"{nameof(FileService)}  is null!");
            }
            return FileService.Filter(x => x.DirectoryId == DirectoryId).ToList();
        }

        public void DisplayFileSize(Domain.Models.File file)
        {
            ShowSnackbarMessage($"{file.Name} has a size of {file.Size}", Color.Success);
        }

        public void DisplayDirectorySize(Domain.Models.Directory Directory)
        {
            if (DirectorySizeCalculatorService == null)
            {
                throw new Exception($"{nameof(DirectorySizeCalculatorService)}  is null!");
            }

            var Size = DirectorySizeCalculatorService.GetSize(Directory);
            ShowSnackbarMessage($"{Directory.Name} has a size of {Size}", Color.Success);
        }
    }
}
