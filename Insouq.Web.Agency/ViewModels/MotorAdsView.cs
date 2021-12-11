using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insouq.Web.Agency.ViewModels
{
    public class MotorAdsView
    {

        public int Id { get; set; }
        public string AgentName { get; set; }

        public string sortOrder { get; set; }

        public string Date { get; set; }
        public DateTime dateTime { get; set; }
        public string agentName { get; set; }
        public string Title { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }
        public string MainImageUrl { get; set; }

        public string Maker { get; set; }

        public string Model { get; set; }

        public string Trim { get; set; }

        public string Color { get; set; }

        public Double Kilometers { get; set; }

        public int Year { get; set; }

        public int Doors { get; set; }

        public string Transmission { get; set; }

        public string RegionalSpecs { get; set; }

        public string BodyType { get; set; }

        public string FuelType { get; set; }

        public string NoOfCylinders { get; set; }

        public string Horsepower { get; set; }

        public string CarCondition { get; set; }

        public string MechanicalCondition { get; set; }

        public Double Price { get; set; } // min 1000

        public int status { get; set; }

      //  public MotorAdsListingFilter motorAdsListingFilter { get; set; }


        public MotorAdsView(string Maker = "Maker", string Model = "Model", string Trim = "Trim", string Color = "Color", double Kilometers = 0, int Year = 1999, int Doors = 4, string Transmission = "Tramsmission",
            string RegionalSpecs = "Regional Specs", string BodyType = "Body Type", string FuelType = "Fuel Type", string NoOfCylinders = "Cylinders", string Horsepower = "Hoorse Power",
            string CarCondition = "Car Condition", string MechanicalCondition = "Mechanical Condition", double price = 0)
        {
            this.Maker = Maker;
            this.Model = Model;
            this.Trim = Trim;
            this.Color = Color;
            this.Kilometers = Kilometers;
            this.Year = Year;
            this.Doors = Doors;
            this.Transmission = Transmission;
            this.RegionalSpecs = RegionalSpecs;
            this.BodyType = BodyType;

            this.FuelType = FuelType;
            this.NoOfCylinders = NoOfCylinders;
            this.Horsepower = Horsepower;
            this.CarCondition = CarCondition;
            this.RegionalSpecs = RegionalSpecs;
            this.MechanicalCondition = MechanicalCondition;
            this.Price = price;
        }
    }
}
