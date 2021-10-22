using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace TiaDataViewer.Core.ViewModels
{
    public class StartViewModel : ObservableRecipient, IBaseViewModel
    {
        // Window title extension
        public string TitleExtention { get; } = string.Empty;
    }
}
