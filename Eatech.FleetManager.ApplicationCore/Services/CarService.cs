using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Eatech.FleetManager.ApplicationCore.Entities;
using Eatech.FleetManager.ApplicationCore.Interfaces;
using System.Data.SQLite;

namespace Eatech.FleetManager.ApplicationCore.Services
{
    public class CarService : ICarService
    {
        SQLiteConnection database_connection;
        public CarService()
        {
            database_connection = new SQLiteConnection("Data Source=C:/Users/martt/OneDrive/Harrasteprojektit/fleetmanager-csharp/Eatech.FleetManager.ApplicationCore/database.db;" +
                                                       "Version=3;");
            database_connection.Open();
        }

        List<Car> UnfoldReader(SQLiteDataReader reader)
        {
            List<Car> cars = new List<Car>();
            while (reader.Read())
            {
                cars.Add(new Car
                {
                    Id = Guid.Parse(reader["Id"].ToString()),
                    Brand = reader["Brand"]?.ToString(),
                    Model = reader["Model"]?.ToString(),
                    RegistrationNumber = reader["RegistrationNumber"]?.ToString(),
                    ModelYear = int.TryParse(reader["ModelYear"].ToString(), 
                        out int year) ? (int?)year : null,
                    InspectionDate = DateTime.TryParse(reader["InspectionDate"].ToString(), 
                        out DateTime inspectionDate) ? (DateTime?)inspectionDate : null,
                    EngineDisplacement = int.TryParse(reader["EngineDisplacement"].ToString(), 
                        out int engineDisplacement) ? (int?)engineDisplacement : null,
                    EnginePower = int.TryParse(reader["EnginePower"].ToString(), 
                        out int enginePower) ? (int?)enginePower : null
                });
            }
            return cars;
        }
 


        /// <summary>
        ///     Remove this. Temporary car storage before proper data storage is implemented.
        /// </summary>
        private static readonly ImmutableList<Car> TempCars = new List<Car>
        {
            new Car
            {
                Id = Guid.Parse("d9417f10-5c79-44a0-9137-4eba914a82a9"),
                ModelYear = 1998
            },
            new Car
            {
                Id = Guid.NewGuid(),
                ModelYear = 2007
            }
        }.ToImmutableList();

        public async Task<IEnumerable<Car>> GetAll()
        {
            string query = "select * from Cars";
            SQLiteCommand command = new SQLiteCommand(query, database_connection);
            // Unfortunately the ExecuteReaderAsync() for SQLite is not implemented
            // properly and thats why I have to use ExecuteReader... :(
            SQLiteDataReader reader = command.ExecuteReader();
            List<Car> result = UnfoldReader(reader);
            return result;
        }

        public async Task<Car> Get(Guid id)
        {
            return await Task.FromResult(TempCars.FirstOrDefault(c => c.Id == id));
        }
    }
}