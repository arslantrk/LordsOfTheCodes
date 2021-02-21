using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        Car GetById(int id);
        List<Car> GetListByBrandId(int brandid);
        List<Car> GetListByColorId(int colorid);
        List<Car> GetBy(Car car);
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);

    }
}
