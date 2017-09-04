using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TennisTable.Classes;
using TennisTableWPF.Services;

namespace TennisTableWPF.ViewModels
{
    public class TableauBordViewModel : ViewModelBase
    {
        #region Propriétés

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
        private bool _toggleResultChecked;
        public bool ToggleResultChecked
        {
            get => _toggleResultChecked;
            set
            {
                _toggleResultChecked = value;
                OnPropertyChanged("ToggleResultChecked");
            }
        }
        private bool _toggleProgrChecked;
        public bool ToggleProgrChecked
        {
            get => _toggleProgrChecked;
            set
            {
                _toggleProgrChecked = value;
                OnPropertyChanged("ToggleProgrChecked");
            }
        }
        public ICollectionView EquipesFiltre => CollectionViewSource.GetDefaultView(Equipes);
        public ICollectionView MatchViewFiltre => CollectionViewSource.GetDefaultView(MatchsView);
        #endregion
        #region Constructeur
        public TableauBordViewModel()
        {
            MatchViewFiltre.Filter = o =>
            {
                var item = (CMatchsView)o;
                return true;
            };
            EquipesFiltre.Filter = o => false;
        }
        #endregion
        #region Méthodes - Commandes
        public override bool ClubsSelectedCommand_CanExecute()
        {
            return true;
        }
        public override void ClubsSelectedCommand_Execute()
        {
            EquipesFiltre.Filter = o =>
            {
                var item = (CEquipes)o;
                return item.Club == ClubSelected?.ClubId;
            };
            FilterGrid();
        }

        public override bool EquipesSelectedCommand_CanExecute()
        {
            return true;
        }
        public override void EquipesSelectedCommand_Execute()
        {
            FilterGrid();
        }

        public override void RefreshCommand_Execute()
        {
            EquipeSelected = null;
            ClubSelected = null;
            MatchViewFiltre.Filter = o =>
            {
                var item = (CMatchsView)o;
                return true;
            };
        }

        public override void ToggleChangedCommand_Execute()
        {
            FilterGrid();
        }

        public void FilterGrid()
        {
            MatchViewFiltre.Filter = o =>
            {
                var item = (CMatchsView)o;
                if (ToggleResultChecked && item.Date < DateTime.Today)
                {
                    if (ClubSelected != null)
                    {
                        if (item.ClubVisiteId == ClubSelected?.ClubId || item.ClubVisiteurId == ClubSelected?.ClubId)
                        {
                            if (EquipeSelected != null)
                            {
                                return item.EquipeVisiteId == EquipeSelected.EquipeId ||
                                       item.EquipeVisiteurId == EquipeSelected.EquipeId;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return true;
                    }      
                }
                else if (ToggleProgrChecked && item.Date > DateTime.Today)
                {
                    if (ClubSelected != null)
                    {
                        if (item.ClubVisiteId == ClubSelected?.ClubId || item.ClubVisiteurId == ClubSelected?.ClubId)
                        {
                            if (EquipeSelected != null)
                            {
                                return item.EquipeVisiteId == EquipeSelected.EquipeId ||
                                       item.EquipeVisiteurId == EquipeSelected.EquipeId;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    if (ClubSelected != null)
                    {
                        if (item.ClubVisiteId == ClubSelected?.ClubId || item.ClubVisiteurId == ClubSelected?.ClubId)
                        {
                            if (EquipeSelected != null)
                            {
                                return item.EquipeVisiteId == EquipeSelected.EquipeId ||
                                       item.EquipeVisiteurId == EquipeSelected.EquipeId;
                            }
                            else
                            {
                                return true;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
                return false;
            };
        }

        #endregion
    }
}
