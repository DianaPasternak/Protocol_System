using System;
using System.Collections.Generic;

namespace ProtocolSystem.Models.DB
{
    public partial class Protocols
    {
        public int Id { get; set; }
        public string Series { get; set; }
        public DateTime ProtocolDate { get; set; }
        public string Country { get; set; }
        public int User1Id { get; set; }
        public int? User2Id { get; set; }
        public string ProtocolPlace { get; set; }
        public string VehicleId2 { get; set; }
        public string VehicleId1 { get; set; }
        public string VehicleBrand1 { get; set; }
        public string VehicleBrand2 { get; set; }
        public string RegistrationCountry1 { get; set; }
        public string RegistrationCountry2 { get; set; }
        public string Damage1 { get; set; }
        public string Damage2 { get; set; }
        public string IncidentDescription { get; set; }
        public string WitnessData { get; set; }
        public DateTime IncidentDate { get; set; }
        public string IncidentPlace { get; set; }
        public double? RuleId { get; set; }
        public string LawArticle { get; set; }
        public DateTime? ConsiderationDate { get; set; }
        public string ConsiderationPlace { get; set; }
        public int? InsurantId1 { get; set; }
        public int? InsurantId2 { get; set; }

        public Insurants InsurantId1Navigation { get; set; }
        public Insurants InsurantId2Navigation { get; set; }
        public Users User1 { get; set; }
        public Users User2 { get; set; }
    }
}
