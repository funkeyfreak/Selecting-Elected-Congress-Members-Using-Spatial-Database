using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovData
{
    class DummyClass : IListElectedCongress
    {
        public List<Representative> GetRepresentativesByAddress(string address, string city, string state, string zip)
        {
            throw new NotImplementedException();


        }

        public List<Representative> GetRepresentativesByZip(string zip)
        {
            return null;
        }

        public List<Senator> GetSenator(string state)
        {
            throw new NotImplementedException();
        }

        public void SetApiCode(string BingMapAPICode)
        {
            throw new NotImplementedException();
        }
    }
}
