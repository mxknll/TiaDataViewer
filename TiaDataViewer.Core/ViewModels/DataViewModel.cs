using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using TiaDataViewer.Core.Models;

namespace TiaDataViewer.Core.ViewModels
{
    public class DataViewModel : ObservableRecipient, IBaseViewModel
    {
        // The selected TIA Selection Tool
        private readonly TiaSelectionToolModel _tool;

        public DataViewModel(TiaSelectionToolModel tool)
        {
            _tool = tool;

            // Group and count nodes by type
            _types = tool.Business.Graph.Nodes.GroupBy(node => node.Type)
                            .Select(group => new TypeModel()
                            {
                                Title = group.Key,
                                Count = group.Count()
                            });

            // Select first type (top bar)
            SelectedType = Types.FirstOrDefault();
        }

        // ----- Properties -----

        // Window title extension
        public string TitleExtention => $" - \"{_tool.FileName}\"";

        // List of all Types
        private readonly IEnumerable<TypeModel> _types;
        public IEnumerable<TypeModel> Types => _types;

        // Selected type (upper bar)
        private TypeModel _selectedType;
        public TypeModel SelectedType
        {
            get => _selectedType;
            set
            {
                SetProperty(ref _selectedType, value);
                OnPropertyChanged(nameof(NodesOfSelectedType));
            }
        }

        // List of nodes of the type selected
        public IEnumerable<NodeModel> NodesOfSelectedType => SelectedType is null ? null :
                                                                _tool.Business.Graph.Nodes.Where(node => node.Type == _selectedType.Title);

        // Selected node
        private NodeModel _selectedNode;
        public NodeModel SelectedNode
        {
            get => _selectedNode;
            set
            {
                SetProperty(ref _selectedNode, value);
            }
        }
    }
}
