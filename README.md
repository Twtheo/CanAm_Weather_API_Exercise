This is the Can/Am Technologies Weather API Exercise for the interview process.

I made a Swagger application to route to the National Weather Service's API and retrieve the requested data.

There are three endpoints:
  1. Get station information via State code
  2. Get basic weather forecast for the week and hourly (set information provided as a base example)
  3. Get basic weather forecast for the week and hourly via x,y coordinates.

Endpoint 3 usage explained: To get x,y coordinates of a location you desire you should use the station information endpoint first, from here you can scroll through the data given and find a
station from which you want forecast information from. Here you will find two coordinate points, these are the points you can enter into endpoint 3, this will retrieve the hourly and 
weekly forecast for that location.
