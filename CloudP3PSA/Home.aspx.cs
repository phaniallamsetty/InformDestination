using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CloudP3PSA
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string SourceCoordinates = GetCoordinates(txtSource.Text);
            string DestinationCoordinates = GetCoordinates(txtDestination.Text);
            DistanceRoot droot = GetDistance(SourceCoordinates, DestinationCoordinates, ddlTravelMode.SelectedValue);
            int TempInF = GetTemperatureInFahrenheit(txtDestination.Text);
            TimeZone SourceTimeZone = GetTimeZone(SourceCoordinates);
            TimeZone DestinationTimeZone = GetTimeZone(DestinationCoordinates);

            lblDistance.Text = "<b>Distance";
            lblDistanceValue.Text = droot.routes[0].legs[0].distance.text;

            lblTimeTaken.Text = "<b>Estimated Time";
            lblTimeTakenValue.Text = droot.routes[0].legs[0].duration.text;

            lblDestinationTemperature.Text = "<b>Temperature at " + txtDestination.Text;
            lblDestinationTemperatureValue.Text = TempInF.ToString() + " F";

            if (SourceTimeZone.timeZoneName != DestinationTimeZone.timeZoneName)
            {
                lblTimeZoneChange.Text = "<b>"+"There will be a change of time zone"+"</b>"+"<br>"+ txtSource.Text +": <i>"+SourceTimeZone.timeZoneName+"  </i><br>"+ txtDestination.Text+": <i>"+DestinationTimeZone.timeZoneName ;
            }
            else
            {
                lblTimeZoneChange.Text = "<b>There will be no change of time zone";
            }
        }

        protected static string GetCoordinates(string Loc)
        {
            //Google API being called to retrieve the coordinates of the location
            string Coordinates = String.Empty;
            using (var client = new HttpClient())
            {
                string url = "http://maps.googleapis.com/maps/api/geocode/json?address=" + Loc + "&sensor=false";
                var json1 = new WebClient().DownloadString(url);

                //Mapping the JSON data to a class to store data
                RootObject c1 = new JavaScriptSerializer().Deserialize<RootObject>(json1);
                Coordinates = c1.results[0].geometry.location.lat.ToString()
                    + ","
                    + c1.results[0].geometry.location.lng.ToString();
            }

            return Coordinates;
        }

        protected static DistanceRoot GetDistance(string Source, string Destination, string Mode)
        {
            DistanceRoot c1;
            using (var client = new HttpClient())
            {
                string DistanceURL = "http://maps.googleapis.com/maps/api/directions/json?origin=" + Source + "&destination=" + Destination + "&mode=" + Mode;
                var json1 = new WebClient().DownloadString(DistanceURL);
                c1 = new JavaScriptSerializer().Deserialize<DistanceRoot>(json1);
            }
            return c1;
        }

        protected static int GetTemperatureInFahrenheit(string Loc)
        {
            int temp = 0;

            using (var client = new HttpClient())
            {
                string url = "https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22" + Loc + "%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";
                var json1 = new WebClient().DownloadString(url);
                WeatherRoot c1 = new JavaScriptSerializer().Deserialize<WeatherRoot>(json1);

                temp = Convert.ToInt32(c1.query.results.channel.item.condition.temp);
            }

            return temp;
        }

        protected static TimeZone GetTimeZone(string Coordinates)
        {
            TimeZone tz;
            string TZone = String.Empty;
            using (var client = new HttpClient())
            {
                string url = "https://maps.googleapis.com/maps/api/timezone/json?location=" + Coordinates + "&timestamp=500";
                var json1 = new WebClient().DownloadString(url);
                tz = new JavaScriptSerializer().Deserialize<TimeZone>(json1);
               // TZone = tz.timeZoneName;
            }

            return tz;
        }
    }
}