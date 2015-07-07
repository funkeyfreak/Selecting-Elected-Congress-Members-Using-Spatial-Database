using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovData
{
    public interface IListElectedCongress
    {
        /// <summary>
        /// Returns null if no districts or multiple districts are found
        /// </summary>
        /// <param name="address">Street address, we don't care about apartment numbers etc.</param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zip">5 digit zip</param>
        /// <returns></returns>
        List<Representative> GetRepresentativesByAddress(string address, string city, string state, string zip);
        /// <summary>
        /// Returns null if no districts or multiple districts found
        /// </summary>
        /// <param name="zip">5 digit zip</param>
        /// <returns>List of house representatives for your district - usually one.</returns>
        List<Representative> GetRepresentativesByZip(string zip);

        List<Senator> GetSenator(string state);

        /// <summary>
        /// I would suggest putting this in your constructor. It will allow me to set my API code
        /// </summary>
        /// <param name="BingMapAPICode"></param>
        void SetApiCode(string BingMapAPICode);
    }
}
