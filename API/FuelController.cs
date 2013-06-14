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
        //
        // GET /api/fuel
        public HttpResponseMessage Get(string metrics="EU", string sDistance="100km", double used=8.2)
        {
            //Not really constants, but they are constants in the sense of
            //that they are used when converting from Kilometers to Miles.
            double distanceConst = 0; 
            double fuelConst = 0;
            double calculatedAverage = 0;
            double distance = 0;
            string parseDistance = "";
            
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

            //Else-conditions if converting from Liters / KM.
            if (metrics.Equals("US"))
            {
                distanceConst = 1.6093472186944; //1 KM is about 1.6 miles
                fuelConst = 3.78541178; //1 Liter is about 3.78 Gallons.
                calculatedAverage = (distance / distanceConst) / (used / fuelConst);
            }
            else if (metrics.Equals("UK"))
            {
                distanceConst = 1.6093472186944; //1 KM is about 1.6 miles
                fuelConst = 4.54609188; //1 Liter is about 3.78 Gallons.
                calculatedAverage = (distance / distanceConst) / (used / fuelConst);
            }
            else if (metrics.Equals("EU"))
            {
                distanceConst = 1;
                fuelConst = 1;
                calculatedAverage = (used / (distance / 100));
            }

            //Using own HttpResponseMessage for future additions that might be added - so we can push multiply results to API requester.
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