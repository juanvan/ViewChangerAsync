using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ViewChangerAsync.Models;

namespace ViewChangerAsync.ViewModels
{
    public class NavigationViewModel : PropertyChangedBase 
    {
        //BindableCollection<BikeManufacture> Manufactures { get; set; }
        private ObservableCollection<BikeManufacture> _manufactures { get; set; }
        public NavigationViewModel()
        {
            LoadManufactures();
        }
        public ObservableCollection<BikeManufacture> Manufactures
        {
            get { return _manufactures; }
            set { _manufactures = value;
                NotifyOfPropertyChange(() => Manufactures);
            }
        }


        private void LoadManufactures()
        {
            Manufactures = new ObservableCollection<BikeManufacture>();
            var bikeTypes = new BikeType() { DesignType = "Electric" };
            var listBikeTypes = new ObservableCollection<BikeType>();
            listBikeTypes.Add(bikeTypes);
            Manufactures.Add(new BikeManufacture() { BikeName = "A-Bike", Country = "EUROPE", BikeModels = listBikeTypes });
            Manufactures[0].BikeModels.Add(new BikeType() { DesignType = "Set2" });
            Manufactures.Add(new BikeManufacture() { BikeName = "Argon", Country = "USA" });
        }
    }
}
