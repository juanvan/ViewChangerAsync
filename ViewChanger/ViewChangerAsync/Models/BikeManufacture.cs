using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ViewChangerAsync.Models
{

    public class BikeMenu
    {
        public ObservableCollection<BikeManufacture> ManufactureList { get; set; }
    }
   public class BikeManufacture
    {
        public BikeManufacture()
        {
            BikeModels = new ObservableCollection<BikeType>();
        }
        public int Id { get; set; }
        public string BikeName { get; set; }
        public string Country { get; set; }
        public ObservableCollection<BikeType> BikeModels { get; set; }
    }
    public class BikeType
    {
        public BikeType()
        {
            BikeUnits = new ObservableCollection<BikeUnit>();
        }
        public string DesignType { get; set; }
        public ObservableCollection<BikeUnit> BikeUnits { get; set; }
    }

    public class BikeUnit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Height { get; set; }
    }
}
