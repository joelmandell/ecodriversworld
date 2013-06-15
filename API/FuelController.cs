using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataNissen.API
{
    public class FuelController : ApiController
    {
        //Constants of distances and volume, converted to ther respective value in kilometers and liters.
        public const double ENGLISH_MILE = 1.6093472186944;
        public const double ENGLISH_GALLON = 4.54609188;
        public const double AMERICAN_GALLON = 3.78541178;

        //
        // GET /api/fuel?metrics=EU&sDistance=200km&used=8.2
        public HttpResponseMessage Get(string metrics="EU", string sDistance="200km", double used=8.2)
        {
            double calculatedAverage = 0;
            double distance = 0;
            string parseDistance = "";

            //List with errors when inputed data from user is faulty.
            //ERROR==0 Incorrect metrics value.
            List<string> errors = new List<string>();
            
            //Because the user might write the distance and end it with unit km or something else - we step by char and see if is digit.
            for (int i = 0; i < sDistance.Length; i++)
            {
                //If the selected character is a digit and a dot(meaning it contains decimals
                //then add it to string parseDistance.
                if (Char.IsDigit(sDistance.ToCharArray()[i]) || sDistance[i].Equals('.'))
                {
                    parseDistance += sDistance[i];
                }
            }

            //Convert founded number value in sDistance to double (because it might be with decimals).
            distance = Convert.ToDouble(parseDistance, System.Globalization.CultureInfo.InvariantCulture);

            //Else-conditions if converting from Liters / KM to US MPG(Miles per Gallon) or UK MPG.
            if (metrics.Equals("US"))
            {
                calculatedAverage = (distance / ENGLISH_MILE) / (used / AMERICAN_GALLON);
            }
            else if (metrics.Equals("UK"))
            {
                calculatedAverage = (distance / ENGLISH_MILE) / (used / ENGLISH_GALLON);
            }
            else if (metrics.Equals("EU"))
            {
                calculatedAverage = (used / (distance / 100));
            }
            else
            {
                //Not known metrics then give them error 0 
                errors.Add("Error: 0");
            }

            //Is there errors?
            if (errors.Count > 0)
            {
                string concatedErrors = "";

                //Build xml with the errors.
                for (int i = 0; i < errors.Count; i++)
                {
                    concatedErrors += "<string>" + errors + "</string>";
                }

                //Show them for user.
                return new HttpResponseMessage()
                {
                    Content = new StringContent(
                        concatedErrors,
                        System.Text.Encoding.UTF8,
                        "text/xml"
                    )
                };
                
            }

            //Using own HttpResponseMessage for future additions that might be added 
            //- so we can push multiply results to API requester.
            return new HttpResponseMessage()
            {
                Content = new StringContent(
                    "<string>"+calculatedAverage.ToString()+"</string>",
                    System.Text.Encoding.UTF8,
                    "text/xml"
                )
            };
        }
    }
}