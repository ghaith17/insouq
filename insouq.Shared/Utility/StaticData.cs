using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Shared.Utility
{
    public static class StaticData
    {
        public const string Admin_Role = "Admin";
        public const string User_Role = "User";
        public const string AgentManager_Role = "AgentManager";
        public const string Agent_Role = "Agent";

        public const string Unauthorized_Message = "Un Authorized";

        public const string ServerError_Message = "Internal Server Error";

        public const string DefaultUser_Image = @"\images\userImage.png";

        public const string SERVER_DOMAIN = "";

        //public const string SERVER_DOMAIN = "http://hasanjaser-001-site1.dtempurl.com";

        //public const string SERVER_DOMAIN = "https://localhost:44356";

        //public const string SERVER_DOMAIN = "https://localhost:5001";


        public const int Motors_ID = 1; // Ok
        public const int Properties_ID = 2;
        public const int Jobs_ID = 3; // Ok
        public const int Services_ID = 4; // Ok
        public const int Business_ID = 5;
        public const int Classifieds_ID = 6;
        public const int Numbers_ID = 7;
        public const int Electronics_ID = 8;


        // Motors

        public const int UsedCars_ID = 2;
        public const int Boats_ID = 5;
        public const int Machinery_ID = 6;
        public const int Parts_ID = 7;
        public const int ExportCar_ID = 8;
        public const int Bike_ID = 9;

        ///////////////////////////////

        // Jobs

        public const int JobOpening_ID = 3;
        public const int JobWanted_ID = 4;

        ///////////////////////////////
        
        // Properities

        public const int CommercialForSale_ID = 10;
        public const int CommercialForRent_ID = 14;
        public const int ResidentialForSale_ID = 15;
        public const int ResidentialForRent_ID = 16;

        ///////////////////////////////
        ///

        // Numbers

        public const int PlateNumbers_ID = 17;
        public const int MobileNumbers_ID = 18;

        ///////////////////////////////
        /// 
        // Services

        public const int CarLift_ID = 31;

        ///////////////////////////////
        /// Classifieds
        /// 

        public const int FurnitureHomeAndGarden_ID = 39;
        public const int HomeAppliances_ID = 40;
        public const int JewelryAndWatches_ID = 41;
        public const int SportsEquipment_ID = 42;
        public const int MusicalInstruments_ID = 43;
        public const int Gaming_ID = 44;
        public const int CamerasAndImaging_ID = 45;
        public const int BabyItems_ID = 46;
        public const int Toys_ID = 47;
        public const int TicketsAndVouchers_ID = 48;
        public const int Collectibles_ID = 49;
        public const int Music_ID = 51;
        public const int FreeStuff_ID = 52;
        public const int Pets_ID = 53;
        public const int PetAccessories_ID = 54;



        public const int OthersCategory_Status = 2;


        // sorted by
        public const int Newest_To_Oldest = 1;
        public const int Oldest_To_Newest = 2;
        public const int Price_Heighest_To_Lowest = 3;
        public const int Price_Lowest_To_Heighest = 4;

        public const int Status_Deleted = 5;

        // posted in

        public const int Posted_Today = 1;
        public const int Posted_ThisWeek = 2;
        public const int Posted_ThisMonth = 3;
        public const int Posted_ThisYear = 4;

        // agency 
        public const int Confirmed = 1;
        public const int Waiting = 0;

        // agent
        public const bool Active = true;
        public const bool disable = false;



    }
}
