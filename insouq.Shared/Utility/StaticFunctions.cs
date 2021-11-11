using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Shared.Utility
{
    public class StaticFunctions
    {
        public static string GetTypeImage(int typeId)
        {
            switch (typeId)
            {
                case StaticData.Motors_ID:
                    return "/assets/img/155.png";

                case StaticData.Properties_ID:
                    return "/assets/img/157.png";


                case StaticData.Jobs_ID:
                    return "/assets/img/159.png";


                case StaticData.Services_ID:
                    return "/assets/img/161.png";


                case StaticData.Business_ID:
                    return "/assets/img/163.png";


                case StaticData.Classifieds_ID:
                    return "/assets/img/165.png";


                case StaticData.Numbers_ID:
                    return "/assets/img/167.png";


                case StaticData.Electronics_ID:
                    return "/assets/img/169.png";

                default:
                    return "";
            }
        }

        public static string GetTypeName(int typeId)
        {
            switch (typeId)
            {
                case StaticData.Motors_ID:
                    return "Motors";

                case StaticData.Properties_ID:
                    return "Properties";


                case StaticData.Jobs_ID:
                    return "Jobs";


                case StaticData.Services_ID:
                    return "Services";


                case StaticData.Business_ID:
                    return "Business";


                case StaticData.Classifieds_ID:
                    return "Classifieds";


                case StaticData.Numbers_ID:
                    return "Numbers";


                case StaticData.Electronics_ID:
                    return "Electronics";

                default:
                    return "";
            }
        }

        public static int GetClassifiedGroup(int categoryId)
        {
            switch (categoryId)
            {
                // First Group
                case StaticData.FurnitureHomeAndGarden_ID:
                    return 1;

                case StaticData.HomeAppliances_ID:
                    return 1;

                case StaticData.JewelryAndWatches_ID:
                    return 1;

                case StaticData.SportsEquipment_ID:
                    return 1;

                case StaticData.MusicalInstruments_ID:
                    return 1;

                case StaticData.Gaming_ID:
                    return 1;

                case StaticData.CamerasAndImaging_ID:
                    return 1;

                // Second Group
                case StaticData.BabyItems_ID:
                    return 2;

                case StaticData.Toys_ID:
                    return 2;

                case StaticData.TicketsAndVouchers_ID:
                    return 2;

                case StaticData.Collectibles_ID:
                    return 2;

                case StaticData.Music_ID:
                    return 2;

                case StaticData.FreeStuff_ID:
                    return 2;

                // Third Group
                case StaticData.Pets_ID:
                    return 3;

                case StaticData.PetAccessories_ID:
                    return 3;

                default:
                    return 0;
            }
        }

        public static string GetColorByTypeId(int typeId)
        {
            switch (typeId)
            {
                case StaticData.Motors_ID:
                    return "#FF0073";

                case StaticData.Properties_ID:
                    return "#FFC456";


                case StaticData.Jobs_ID:
                    return "#FF665B";


                case StaticData.Services_ID:
                    return "#00D4F9";


                case StaticData.Business_ID:
                    return "#6DD400";


                case StaticData.Classifieds_ID:
                    return "#0091FF";


                case StaticData.Numbers_ID:
                    return "#7255F1";


                case StaticData.Electronics_ID:
                    return "#FFD300";

                default:
                    return "";
            }
        }
    }
}
