* [![Build Status](https://drone.seattleslow.com/api/badges/josmo/sample-dotnet-service-1/status.svg)](https://drone.seattleslow.com/josmo/sample-dotnet-service-1)

#C# Template for services - 

##Tech to know about

* Nancy FX
* .NET Core 2
* Entity Framework - might switch for speed
* Docker

##Tools needed

* Docker
* Drone CLI


##To get started

```sh
drone exec
docker build -t service .
docker run -e SQL_HOST=sqlhost -e SQL_USER=sa -e SQL_PASSWORD=mypassword service
```


