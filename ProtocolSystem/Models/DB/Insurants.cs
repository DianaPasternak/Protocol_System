using System;
using System.Collections.Generic;

namespace ProtocolSystem.Models.DB
{
    public partial class Insurants
    {
        public Insurants()
        {
            ProtocolsInsurantId1Navigation = new HashSet<Protocols>();
            ProtocolsInsurantId2Navigation = new HashSet<Protocols>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }

        public ICollection<Protocols> ProtocolsInsurantId1Navigation { get; set; }
        public ICollection<Protocols> ProtocolsInsurantId2Navigation { get; set; }
    }
}
