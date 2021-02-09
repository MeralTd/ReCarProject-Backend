using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestCarListGet();

            TestGetCarDetails();
        }

        private static void TestGetCarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("Car Name" + "/" + "Color Name" + "/" + "Brand Name" + "/" + "Daily Price");

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + "/" + car.ColorName + "/" + car.BrandName + "/" + car.DailyPrice);
            }
        }

        private static void TestCarListGet()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
