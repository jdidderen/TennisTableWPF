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
            }
            return null;
        }
        public DataTemplate JoueursTemplate { get; set; }
        public DataTemplate ClubsTemplate { get; set; }
    }
}
