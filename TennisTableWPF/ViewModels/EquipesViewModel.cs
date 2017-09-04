using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using TennisTable.Classes;
using TennisTable.Gestion;
using TennisTableWPF.Services;

namespace TennisTableWPF.ViewModels
{
    public class EquipesViewModel : ViewModelBase
    {
        #region Propriétés
        private List<CJoueurs> _joueurslistSelected;
        public List<CJoueurs> JoueurlistSelected
        {
            get => _joueurslistSelected;
            set
            {
                _joueurslistSelected = value;
                OnPropertyChanged("JoueurlistSelected");
            }
        }
        private CEquipes _equipeSelected;
        public CEquipes EquipeSelected
        {
            get => _equipeSelected;
            set
            {
                _equipeSelected = value;
                OnPropertyChanged("EquipeSelected");
            }
        }
        private CJoueurs _capitaineSelected;
        public CJoueurs CapitaineSelected
        {
            get => _capitaineSelected;
            set
            {
                _capitaineSelected = value;
                OnPropertyChanged("CapitaineSelected");
            }
        }
        private CClubs _clubSelected;
        public CClubs ClubSelected
        {
            get => _clubSelected;
            set
            {
                _clubSelected = value;
                OnPropertyChanged("ClubSelected");
            }
        }
        public ICollectionView JoueursFiltre => CollectionViewSource.GetDefaultView(Joueurs);
        #endregion
        #region Constructeur
        public EquipesViewModel()
        {
            JoueurlistSelected = new List<CJoueurs>();
            JoueursFiltre.Filter = o =>
            {
                var item = (CJoueurs)o;
                return item.Club == ClubSelected?.ClubId;
            };
        }
        #endregion
        #region Méthodes - Commandes
        public override void ClubsSelectedCommand_Execute()
        {
            if (ClubSelected != null)
            {
                TextBoxStatus = false;
                ListBoxStatus = true;
                SauverButtonStatus = false;
                EditerButtonStatus = true;
                JoueursFiltre.Refresh();
            }
            else
            {
                TextBoxStatus = false;
                ListBoxStatus = false;
                SauverButtonStatus = false;
                EditerButtonStatus = false;
                JoueursFiltre.Refresh();
            }
        }
        public override bool CreerCommand_CanExecute()
        {
            CreerMessage = "Ajouter une nouvelle équipe";
            return true;
        }
        public override void CreerCommand_Execute()
        {
            Equipes.Add(new CEquipes());
            EquipeSelected = Equipes[Equipes.Count - 1];
        }
        public override bool SauverCommand_CanExecute()
        {
            if (EquipeSelected == null)
            {
                SauverMessage = "Sauver les données de l'équipe sélectionnée - Aucune équipe sélectionnée";
            }
            else if (EditerButtonStatus)
            {
                SauverMessage = "Sauver les données de l'équipe sélectionnée - L'édition n'a pas été activée";
            }
            else if (EquipeSelected.NomEquipe == null && EquipeSelected.Joueur1 == 0 && EquipeSelected.Joueur2 == 0 && EquipeSelected.Joueur3 == 0 && EquipeSelected.Joueur4 == 0 && EquipeSelected.Capitaine == 0 && EquipeSelected.Club == 0)
            {
                SauverMessage = "Sauver les données de l'équipe sélectionnée - Certains champs obligatoires sont vides";
            }
            else
            {
                SauverMessage = "Sauver les données de l'équipe sélectionnée";
                return true;
            }
            return false;
        }
        public override void SauverCommand_Execute()
        {
            base.SauverCommand_Execute();
            if (EquipeSelected.EquipeId == 0)
            {
                GEquipes.Ajouter(EquipeSelected.NomEquipe, EquipeSelected.Joueur1, EquipeSelected.Joueur2, EquipeSelected.Joueur3, EquipeSelected.Joueur4, EquipeSelected.Capitaine, EquipeSelected.Club);
                ReloadEquipes();
            }
            else
            {
                GEquipes.Modifier(EquipeSelected.EquipeId, EquipeSelected.NomEquipe, EquipeSelected.Joueur1, EquipeSelected.Joueur2, EquipeSelected.Joueur3, EquipeSelected.Joueur4, EquipeSelected.Capitaine, EquipeSelected.Club);
            }
        }
        public override bool ModifierCommand_CanExecute()
        {
            if (EquipeSelected == null)
            {
                EditerMessage = "Éditer les données de l'équipe sélectionnée - Aucune équipe sélectionnée";
            }
            else
            {
                EditerMessage = "Éditer les données de l'équipe sélectionnée";
                return true;
            }
            return false;
        }
        public override void SelectedCommand_Execute()
        {
            JoueursFiltre.Filter = o =>
            {
                var item = (CJoueurs)o;
                return item.Club == ClubSelected?.ClubId;
            };
            if (EquipeSelected != null)
            {
                TextBoxStatus = false;
                SauverButtonStatus = false;
                EditerButtonStatus = true;
            }
            else
            {
                TextBoxStatus = false;
                SauverButtonStatus = false;
                EditerButtonStatus = false;
            }
        }
        public override bool SupprimerCommand_CanExecute()
        {
            if (EquipeSelected == null)
            {
                SupprimerMessage = "Supprimer l'équipe sélectionnée - Aucune équipe sélectionnée";
            }
            else
            {
                SupprimerMessage = "Supprimer l'équipe sélectionnée";
                return true;
            }
            return false;
        }
        public override void SupprimerCommand_Execute()
        {
            if (DialogService.ShowMessageBox("Êtes-vous sur de vouloir supprimer cette équipe ?",
                    "Confirmation de suppresion", MessageBoxButton.YesNo, MessageBoxIcon.Exclamation) !=
                MessageBoxResult.Yes) return;
            GEquipes.Supprimer(EquipeSelected.EquipeId);
            ReloadEquipes();
        }
        public override void RefreshCommand_Execute()
        {
            ReloadEquipes();
        }
        #endregion
    }
}
