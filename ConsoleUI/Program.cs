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

            var result = carManager.GetCarDetails();

            Console.WriteLine("Car Name" + "/" + "Color Name" + "/" + "Brand Name" + "/" + "Daily Price");

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + "/" + car.ColorName + "/" + car.BrandName + "/" + car.DailyPrice);

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void TestCarListGet()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
