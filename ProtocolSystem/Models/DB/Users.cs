using System;
using System.Collections.Generic;

namespace ProtocolSystem.Models.DB
{
    public partial class Users
    {
        public Users()
        {
            ProtocolsUser1 = new HashSet<Protocols>();
            ProtocolsUser2 = new HashSet<Protocols>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DrivingLicenceId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public string DrivingLicenceData { get; set; }
        public string Citizenship { get; set; }
        public string PlaceOfWork { get; set; }
        public string PassportData { get; set; }
        public string Post { get; set; }

        public Roles Role { get; set; }
        public ICollection<Protocols> ProtocolsUser1 { get; set; }
        public ICollection<Protocols> ProtocolsUser2 { get; set; }
    }
}
