using System;

namespace Eatech.FleetManager.ApplicationCore.Entities
{
    public class Car
    {
        public Guid Id { get; set; }
        public String Brand { get; set; }
        public String Model { get; set; }
        public String RegistrationNumber { get; set; }
        public int ModelYear { get; set; }
        public DateTime InspectionDate { get; set; }
        public int EngineDisplacement { get; set; }
        public int EnginePower { get; set; }
    }
}