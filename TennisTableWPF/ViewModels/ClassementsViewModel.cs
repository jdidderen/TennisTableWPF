using TennisTable.Classes;
using TennisTable.Gestion;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TennisTableWPF.ViewModels
{
    public class ClassementsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ObservableCollection<CClassements> _classements;
        public ObservableCollection<CClassements> Classements
        {
            get
            {
                if (_classements == null)
                {
                    ListeClassements();
                }
                return _classements;
            }
        }
        public void ListeClassements()
        {
            _classements = new ObservableCollection<CClassements>(new GClassements().Lire("Classement"));
        }
    }
}
