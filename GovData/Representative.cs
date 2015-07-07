using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovData
{
    public class Representative
    {
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string AddrState { get; set; }
        public string Zip4 { get; set; }
        public string StateDistrict { get; set; }
        public string BioguideID { get; set; }
        public string Party { get; set; }
        public string State { get; set; }
        public string District { get; set; }

        public override bool Equals(object obj)
        {
            var rep = (Representative)obj;
            return rep.BioguideID.Equals(BioguideID);
        }

        public override int GetHashCode()
        {
            return BioguideID.GetHashCode();
        }
    }
}
