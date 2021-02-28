using Core.Utilities.ResultManagement;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetListByBrandId(int brandid);
        IDataResult<List<Car>> GetListByColorId(int colorid);
       // IDataResult<List<Car>> GetBy(Car car);
        IResult  Add(Car car);
        IResult  Delete(Car car);
        IResult  Update(Car car);

    }
}
