using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace TennisTableWPF.Services.Tabs
{
    public class ViewSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            switch (((TabsModel)(item))?.CurrentMyTabContentViewModel)
            {
                case ClubsTabContentViewModel _:
                    return ClubsTemplate;
                case JoueursTabContentViewModel _:
                    return JoueursTemplate;
                case MatchsTabContentViewModel _:
                    return MatchsTemplate;
                case EquipesTabContentViewModel _:
                    return EquipesTemplate;
                case StaticDatasTabContentViewModel _:
                    return StaticDatasTemplate;
                case TableauTabContentViewModel _:
                    return TableauTemplate;
            }
            return null;
        }
        public DataTemplate JoueursTemplate { get; set; }
        public DataTemplate ClubsTemplate { get; set; }
        public DataTemplate EquipesTemplate { get; set; }
        public DataTemplate MatchsTemplate { get; set; }
        public DataTemplate StaticDatasTemplate { get; set; }
        public DataTemplate TableauTemplate { get; set; }
    }
}
