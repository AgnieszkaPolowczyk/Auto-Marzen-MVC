using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Domain.Interfaces
{
    public interface ICarRepository
    {
        Task Create (Domain.Entities.Car car);
        Task <IEnumerable<Domain.Entities.Car>> GetAllCars ();

        Task <Domain.Entities.Car> GetCarByEncodedName(string encodedName);

        Task Commit();
        Task DeleteCarByEncodedName(string encodedName);
        Task <Domain.Entities.Car?> GetLastCar();
    }
}
