using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TennisTable.Classes;
using TennisTableWPF.ViewModels;

namespace TennisTableWPF.Views.Equipes
{
    /// <summary>
    /// Logique d'interaction pour EquipesDetailsView.xaml
    /// </summary>
    public partial class EquipesDetailsView : UserControl
    {
        public EquipesDetailsView()
        {
            InitializeComponent();
        }

        private void ListeJoueurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(EquipeDetails.DataContext is EquipesViewModel dataContext)) return;
            dataContext.JoueurSelected.Clear();
            foreach (var item in ListeJoueurs.SelectedItems)
            {
                dataContext.JoueurSelected.Add((CJoueurs)item);
            }
        }
    }
}
