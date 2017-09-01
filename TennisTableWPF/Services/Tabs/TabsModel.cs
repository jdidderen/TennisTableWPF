using System.ComponentModel;

namespace TennisTableWPF.Services.Tabs
{
    public class TabsModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _header;
        public string Header
        {
            get => _header;
            set
            {
                _header = value;
                OnPropertyChanged("Header");
            }
        }
        private ITabsModel _currentMyTabContentViewModel;
        public ITabsModel CurrentMyTabContentViewModel
        {
            get => _currentMyTabContentViewModel;
            set
            {
                _currentMyTabContentViewModel = value;
                OnPropertyChanged("CurrentMyTabContentViewModel");
            }
        }
    }
}
