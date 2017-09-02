using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisTable.Classes
{
    public class CEquipes : PropertiesChanges, IDataErrorInfo
    {
        private int _equipeId;
        private string _nomEquipe;
        private int _joueur1;
        private int _joueur2;
        private int _joueur3;
        private int _joueur4;
        private int _capitaine;
        private int _club;
        public string Error => null;
        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                switch (columnName)
                {
                    default:
                        break;
                }

                return result;
            }
        }
        public CEquipes()
        {
        }
        public CEquipes(string nomEquipe,int joueur1,int joueur2,int joueur3,int joueur4,int capitaine,int club)
        {
            _nomEquipe = nomEquipe;
            _joueur1 = joueur1;
            _joueur2 = joueur2;
            _joueur3 = joueur3;
            _joueur4 = joueur4;
            _capitaine = capitaine;
            _club = club;
        }
        public CEquipes(int equipeId, string nomEquipe, int joueur1, int joueur2, int joueur3, int joueur4, int capitaine,int club)
            : this(nomEquipe, joueur1, joueur2, joueur3, joueur4, capitaine,club)
        {
            _equipeId = equipeId;
        }

        public int EquipeId
        {
            get => _equipeId;
            set { _equipeId = value; OnPropertyChanged("EquipeId"); }
        }

        public string NomEquipe
        {
            get => _nomEquipe;
            set { _nomEquipe = value; OnPropertyChanged("NomEquipe"); }
        }

        public int Joueur1
        {
            get => _joueur1;
            set { _joueur1 = value; OnPropertyChanged("Joueur1"); }
        }

        public int Joueur2
        {
            get => _joueur2;
            set { _joueur2 = value; OnPropertyChanged("Joueur2"); }
        }

        public int Joueur3
        {
            get => _joueur3;
            set { _joueur3 = value; OnPropertyChanged("Joueur3"); }
        }

        public int Joueur4
        {
            get => _joueur4;
            set { _joueur4 = value; OnPropertyChanged("Joueur4"); }
        }

        public int Capitaine
        {
            get => _capitaine;
            set { _capitaine = value; OnPropertyChanged("Capitaine"); }
        }

        public int Club
        {
            get => _club;
            set { _club = value; OnPropertyChanged("Club"); }
        }
    }
}
