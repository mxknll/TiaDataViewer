using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using TiaDataViewer.Core.Exceptions;
using TiaDataViewer.Core.Models;
using TiaDataViewer.Core.Services;

namespace TiaDataViewer.Core.ViewModels
{
    public class MainViewModel : ObservableRecipient
    {
        // Injected services to open and deserialize files
        private readonly IFileService _fileService = Ioc.Default.GetRequiredService<IFileService>();
        private readonly IXmlService _xmlService = Ioc.Default.GetRequiredService<IXmlService>();

        // Start page
        private readonly IBaseViewModel _startPageViewModel = new StartViewModel();

        public MainViewModel()
        {
            _selectedPageViewModel = _startPageViewModel;
            LoadFileCommand = new AsyncRelayCommand(LoadFileAsync);
        }

        // ----- Properties -----

        // Selected Page
        private IBaseViewModel _selectedPageViewModel;
        public IBaseViewModel SelectedPageViewModel
        {
            get => _selectedPageViewModel;
            set => SetProperty(ref _selectedPageViewModel, value);
        }

        // Window title
        public string Title => "TIA Selection Tool - Datei-Viewer" + SelectedPageViewModel?.TitleExtention;

        // ----- Commands -----

        // Load file command
        public IAsyncRelayCommand LoadFileCommand { get; }
        private async Task LoadFileAsync()
        {
            try
            {
                // Open file
                string filePath = _fileService.OpenFile();

                if (string.IsNullOrEmpty(filePath) == false)
                {
                    // Deserialize XML
                    TiaSelectionToolModel tool = await _xmlService.DeserializeXmlAsync<TiaSelectionToolModel>(filePath);
                    tool.FullFilePath = filePath;

                    // Throw error if crucial parts are missing or number of nodes is zero
                    var temp = tool?.Business?.Graph?.Nodes?.Count;
                    if (temp is null)
                    {
                        throw new InvalidXmlStructureException();
                    }
                    if (temp == 0)
                    {
                        throw new InvalidXmlStructureException("Die ausgewählte Datei enthält keine Nodes.");
                    }

                    SelectedPageViewModel = new DataViewModel(tool);
                }
            }
            catch (Exception)
            {
                // Clear UI to make clear that tool has not been loaded
                if (SelectedPageViewModel != _startPageViewModel)
                {
                    SelectedPageViewModel = _startPageViewModel;
                }                
            }
            OnPropertyChanged(nameof(Title));
        }
    }


}
