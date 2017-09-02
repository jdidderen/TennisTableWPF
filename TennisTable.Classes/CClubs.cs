using System.ComponentModel;
using System.Text.RegularExpressions;

namespace TennisTable.Classes
{
    /// <summary>
    /// Classe de définition des données
    /// </summary>
    public class CClubs : PropertiesChanges, IDataErrorInfo
    {
        private int _clubId;
        private string _indice;
        private string _nom;
        private string _nomCourt;
        private string _adresse;
        public string Error => null;
        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                switch (columnName)
                {
                    case "Nom":
                        if (Nom == "" && Nom == null)
                            result = "Le nom ne peut pas être vide";
                        else if (Nom == null || !Regex.IsMatch(Nom, @"^(\p{L}\p{M}*\p{Z}*)+$"))
                            result = "Un nom ne peut contenir que des lettres";
                        break;
                    case "NomCourt":
                        if (NomCourt == "" && NomCourt == null)
                            result = "Le nom court ne peut pas être vide";
                        else if (NomCourt == null || !Regex.IsMatch(NomCourt, @"^(\p{L}\p{M}*\p{Z}*)+$"))
                            result = "Un nom court ne peut contenir que des lettres";
                        break;
                    case "Indice":
                        if (Indice == "" && Indice == null)
                            result = "L'indice du club ne peut pas être vide";
                        break;
                    case "Adresse":
                        if (Adresse == "" && Adresse == null)
                            result = "Le nom court ne peut pas être vide";
                        break;
                }

                return result;
            }
        }
        public CClubs()
        { }
        public CClubs(string indice, string nom, string nomCourt, string adresse)
        {
            _indice = indice;
            _nom = nom;
            _nomCourt = nomCourt;
            _adresse = adresse;
        }
        public CClubs(int clubId, string indice, string nom, string nomCourt, string adresse)
         : this(indice, nom, nomCourt, adresse)
        {
            _clubId = clubId;
        }
        public int ClubId
        {
            get => _clubId;
            set { _clubId = value; OnPropertyChanged("ClubId"); }
        }
        public string Indice
        {
            get => _indice;
            set { _indice = value; OnPropertyChanged("Indice"); }
        }
        public string Nom
        {
            get => _nom;
            set { _nom = value; OnPropertyChanged("Nom"); }
        }
        public string NomCourt
        {
            get => _nomCourt;
            set { _nomCourt = value; OnPropertyChanged("NomCourt"); }
        }
        public string Adresse
        {
            get => _adresse;
            set { _adresse = value; OnPropertyChanged("Adresse"); }
        }
    }
}
