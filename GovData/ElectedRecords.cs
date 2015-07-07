using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

namespace GovData
{
    public class ElectedRecords : IListElectedCongress
    {
       
        public List<Representative> GetRepresentativesByAddress(string address, string city, string state, string zip)
        {
            return getRepRecords("Declare @geography geography; set @geography = Assignment2.dbo.GeographyToGeography(Assignment2.dbo.Geocode('" + address + "', '" + city + "', '" + state + "', '" + zip + "', 'USA'), 4269) SELECT People.person__bioguideid, People.person__firstname, People.person__lastname, People.person__middlename, People.person__namemod, People.state, People.party, ZIP.ZCTA5CE10, People.district, CD.geom FROM Assignment2.dbo.CD, Assignment2.dbo.STATE, Assignment2.dbo.People, Assignment2.dbo.ZIP WHERE CD.geom.STIntersects(@geography) = 1 and @geography.STWithin(CD.geom) =1 and @geography.STIntersects(ZIP.geom) = 1 and CD.STATEFP = STATE.STATEFP and  People.state = state.STUSPS and People.district = TRY_CONVERT(int, CD.CD113FP) and People.role_type = 'representative';");
        }

        public List<Representative> GetRepresentativesByZip(string zip)
        {
            //get Records, passing zip
            return getRepRecords("SELECT People.person__bioguideid, People.person__firstname, People.person__lastname, People.person__middlename, People.person__namemod, ZIP.ZCTA5CE10, People.state, People.party, People.district FROM Assignment2.dbo.CD, Assignment2.dbo.ZIP, Assignment2.dbo.STATE, Assignment2.dbo.People WHERE CD.geom.STIntersects(ZIP.geom) =1 and STATE.STATEFP = CD.STATEFP and ZIP.ZCTA5CE10 = '" +
                zip + "' and CD.geom.STIntersects(STATE.geom)=1 and STATE.STUSPS = People.state and People.district = TRY_CONVERT(int, CD.CD113FP) and STATE.geom.STIntersects(ZIP.geom)=1 and ZIP.geom.STWithin(STATE.geom) = 1");
        }

        public List<Senator> GetSenator(string state)
        {
            //get Records, passing zip
            return getSenRecords("SELECT People.leadership_title, People.senator_rank, People.phone, People.person__firstname, People.person__lastname, People.person__middlename, People.person__bioguideid, People.state, People.party FROM Assignment2.dbo.People WHERE People.state = '" + state + "' and People.role_type = 'senator'");
        }

        public void SetApiCode(string BingMapAPICode)
        {
            //API key is entered into the Bing library from the book which is compiled into a DLL and was used to create an assembly of the functions in SQL...
            //So I just set it here for sake of testing I guess....
            String apiKey = BingMapAPICode;
        }

        private List<Representative> getRepRecords(string query)
        {
            List<Representative> repList = new List<Representative>();

            //formulate connection string, sql query, data adapter/table
            //SqlConnection conn = new SqlConnection(@"Data Source=localhost\CGBPCD; Database=Assignment2; Integrated Security=True");
            SqlConnection conn = new SqlConnection("Data Source=CGBPCD;Initial Catalog=Assignment2;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            //iterate through each record to create list of reps within passed in zipcode
            foreach (DataRow dr in dt.Rows)
            {
                //create our new rep object, and push into list
                Representative rep = new Representative();

                //Set rep properties
                rep.Prefix = ""; //Do not have this data
                rep.FirstName = dr["person__firstname"].ToString();
                rep.MiddleName = dr["person__middlename"].ToString();
                rep.LastName = dr["person__lastname"].ToString();
                rep.Suffix = dr["person__namemod"].ToString();
                rep.Address = ""; //Do not have this data
                rep.City = ""; //Do not have this data
                rep.AddrState = ""; //Do not have this data
                rep.Zip4 = dr["ZCTA5CE10"].ToString(); //Do not have this data, using generic zip instead
                rep.StateDistrict = dr["state"].ToString() + dr["district"].ToString();
                rep.BioguideID = dr["person__bioguideid"].ToString();
                rep.Party = dr["party"].ToString();
                rep.State = dr["state"].ToString();
                rep.District = dr["district"].ToString();

                repList.Add(rep);       
            }

            return repList;
        }

        private List<Senator> getSenRecords(string query)
        {
            List<Senator> senList = new List<Senator>();

            //formulate connection string, sql query, data adapter/table
            //SqlConnection conn = new SqlConnection(@"Data Source=localhost\CGBPCD; Database=Assignment2; Integrated Security=True");
            SqlConnection conn = new SqlConnection("Data Source=CGBPCD;Initial Catalog=Assignment2;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            //iterate through each record to create list of reps within passed in zipcode
            foreach (DataRow dr in dt.Rows)
            {
                //create our new rep object, and push into list
                Senator sen = new Senator();

                //Set sen properties
                sen.ShortInfo = ""; //Do not have this data
                sen.LastName = dr["person__lastname"].ToString();
                sen.FirstName = dr["person__firstname"].ToString();
                sen.Party = dr["party"].ToString();
                sen.StateAbrev = dr["state"].ToString();
                sen.FullAddress = ""; //Do not have this data
                sen.Phone = dr["phone"].ToString();
                sen.Email = ""; //Do not have this data
                sen.Website = ""; //Do not have this data
                sen.Class = dr["senator_rank"].ToString(); //Do not have this data
                sen.bioguide_id = dr["person__bioguideid"].ToString();
                sen.LeadershipPosition = dr["leadership_title"].ToString();

                senList.Add(sen);
            }

            return senList;
        }

    }
}
