using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Creational.Builder
{
    /*
     	Separates object construction from its representation

        In this example, Shop defines how to assembly the parts of vehicles, but builders tell us what exaclty those parts are. 
     */
    class Vehicle
    {
        private string _vehicleType;
        private Dictionary<string, string> _parts = new Dictionary<string, string>();

        public Vehicle(string vehicleType)
        {
            this._vehicleType = vehicleType;
        }

        public string this[string key]
        {
            get { return _parts[key];  }
            set { _parts[key] = value; }
        }

        public void Show()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("Vehicle Type: {0}", _vehicleType);
            Console.WriteLine(" Frame : {0}", _parts["frame"]);
            Console.WriteLine(" Engine : {0}", _parts["engine"]);
            Console.WriteLine(" #Wheels: {0}", _parts["wheels"]);
            Console.WriteLine(" #Doors : {0}", _parts["doors"]);
        }
    }
    abstract class VehicleBuilder
    {
        protected Vehicle _vehicle;

        public Vehicle Vehicle { get { return _vehicle;  } }

        //all build methods
        public abstract void BuildFrame();
        public abstract void BuildEngine();
        public abstract void BuildWheels();
        public abstract void BuildDoors();
    }

    class MotorCycleBuilder : VehicleBuilder
    {
        MotorCycleBuilder()
        {
            _vehicle = new Vehicle("Motorcycle");
        }
        public override void BuildFrame()
        {
            _vehicle["frame"] = "MotorCycle Frame";
        }

        public override void BuildEngine()
        {
            _vehicle["engine"] = "500 cc";
        }

        public override void BuildWheels()
        {
            _vehicle["wheels"] = "2";
        }

        public override void BuildDoors()
        {
            _vehicle["doors"] = "0";
        }
    }

    //WHAT to construct
    class CarBuilder : VehicleBuilder

    {
        public CarBuilder()
        {
            _vehicle = new Vehicle("Car");
        }

        public override void BuildFrame()
        {
            _vehicle["frame"] = "Car Frame";
        }

        public override void BuildEngine()
        {
            _vehicle["engine"] = "2500 cc";
        }

        public override void BuildWheels()
        {
            _vehicle["wheels"] = "4";
        }

        public override void BuildDoors()
        {
            _vehicle["doors"] = "4";
        }
    }


    class Shop
    {
        //tell exactly HOW to construct
        public void Construct(VehicleBuilder builder)
        {
            builder.BuildFrame();
            builder.BuildEngine();
            builder.BuildWheels();
            builder.BuildWheels();
        }
    }
}
