using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>{
            new Car{ BrandId=1,CarId=1,ColorId=1,DailyPrice=500,ModelYear=2020,Description="Kullanılmamış."},
            new Car{ BrandId=2,CarId=2,ColorId=2,DailyPrice=250,ModelYear=2018,Description="Hasar Kaydı Yok."},
            new Car{ BrandId=2,CarId=3,ColorId=3,DailyPrice=150,ModelYear=2010,Description="Değişiklikler Yapılmış."},
            };
        }


        public void Add(Car car)
        {
            _cars.Add(car);
            Console.WriteLine("Araç eklendi.");
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(carToDelete);
            Console.WriteLine("Araç silindi.");
        }
        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            Console.WriteLine("Araç güncellendi.");
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(p => p.CarId == carId).ToList();
        }


    }
}