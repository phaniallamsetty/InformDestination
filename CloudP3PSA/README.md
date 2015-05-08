The purpose of the website is to get information between two locations given by the user (eg: Distance, time taken to travel, Temperature, TimeZone). 
The URL of the website is http://cloudp3psa.azurewebsites.net/Home.aspx. The user needs to enter the source and destination location which could be a city or any specific address. Then from a list of drop down menu the user needs to choose the preferred mode of transportation and hit submit.  The website will return the user the following things:
a) The distance between the source and destination location based on the mode of transportation selected.
b) The duration of travel again based on the mode of transportation selected.
c) The temperature of the destination in Fahrenheit.
d) If there is any change in Time zone between the origin and destination.
Note: These features work best when the source and destination locations are in the same country or are connected by landmass and have a legitimate road connection (eg: USA and Mexico).

Below are the following four APIs used in the website and their brief description:
1. http://maps.googleapis.com/maps/api/geocode/json?address=<Location>&sensor=false
Replace <Location> with a valid location and this API would return the name, county, country , geographical coordinates of that location in json format. 
2. http://maps.googleapis.com/maps/api/directions/json?origin=<Source_Coordinates>&destination=<Destination_Coordinates>&mode=<Travel_Mode>
On providing correct source and destination geographical coordinates and a valid mode of travel (eg: Driving, Walking , Bicycling, Transit), it returns information regarding distance, duration, directions to travel etc in json format. 
3. https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22<Location>%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys
This API fetches the current temperature of  a location. 

4.  https://maps.googleapis.com/maps/api/timezone/json?location=<Location_Coordinates>&timestamp=500
The above API gives the respective Time zone names of the locations provided. 


