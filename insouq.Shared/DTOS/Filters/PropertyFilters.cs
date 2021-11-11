using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Shared.DTOS.Filters
{
    public class PropertyFilters
    {
        public double FromPrice { get; set; }

        public double ToPrice { get; set; }

        public double FromAnnualRent { get; set; }

        public double ToAnnualRent { get; set; }

        public double FromSize { get; set; }

        public double ToSize { get; set; }

        public string Furnishing { get; set; }

        public string ListedBy { get; set; }

        public bool Balcony { get; set; }

        public bool BuiltInKitchenAppliances { get; set; }

        public bool BuildInWardrobes { get; set; }

        public bool WalkInCloset { get; set; }

        public bool CentralACAndHeating { get; set; }

        public bool ConceirgeService { get; set; }

        public bool CoveredParking { get; set; }

        public bool MaidService { get; set; }

        public bool MaidsRoom { get; set; }

        public bool PetsAllowed { get; set; }

        public bool PrivateGarden { get; set; }

        public bool PrivateGym { get; set; }

        public bool PrivateJacuzzi { get; set; }

        public bool PrivatePool { get; set; }

        public bool Security { get; set; }

        public bool SharedGym { get; set; }

        public bool SharedPool { get; set; }

        public bool SharedSpa { get; set; }

        public bool StudyRoom { get; set; }

        public bool ViewOfLandmark { get; set; }

        public bool ViewOfWater { get; set; }

        public bool AvailableNetworked { get; set; }

        public bool ConferenceRoom { get; set; }

        public bool DiningInBuilding { get; set; }

        public bool RetailInBuilding { get; set; }

        public string Location { get; set; }

        public string Keyword { get; set; }

        public int CategoryId { get; set; }

        public int SortBy { get; set; }
    }
}
