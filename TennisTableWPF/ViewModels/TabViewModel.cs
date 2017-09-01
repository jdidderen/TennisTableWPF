using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TennisTableWPF.Models;
using TennisTableWPF.Services;
using TennisTableWPF.Views;

namespace TennisTableWPF.ViewModels
{
    public class TabViewModel
    {
        public ObservableCollection<TabsModel> Tabs { get; set; }
        public TabsModel TabsSelected { get; set; }
        private readonly IDialogService _dialogservice;
        public TabViewModel(IDialogService dialogservice)
        {
            _dialogservice = dialogservice;
            Tabs = new ObservableCollection<TabsModel>();
        }
        private ICommand _addToTabJoueursViewCommand;
        public ICommand AddToTabJoueursViewCommand
        {
            get
            {
                return _addToTabJoueursViewCommand ?? (_addToTabJoueursViewCommand =
                           new RelayCommands(param => AddToTabJoueursViewCommand_Execute(),
                               param => AddToTabJoueursViewCommand_CanExecute()));
            }
        }
        private ICommand _closeTabViewCommand;
        public ICommand CloseTabViewCommand
        {
            get
            {
                return _closeTabViewCommand ?? (_closeTabViewCommand =
                           new RelayCommands(param => CloseTabViewCommand_Execute(),
                               param => CloseTabViewCommand_CanExecute()));
            }
        }
        private bool CloseTabViewCommand_CanExecute()
        {
            throw new NotImplementedException();
        }

        private void CloseTabViewCommand_Execute()
        {
            throw new NotImplementedException();
        }
        private bool AddToTabJoueursViewCommand_CanExecute()
        {
            return true;
        }
        private void AddToTabJoueursViewCommand_Execute()
        {
            Tabs.Add(new TabsModel {Content = new JoueursView(),Header = "Liste des joueurs"});
        }
    }
}
