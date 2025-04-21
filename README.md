# MyWeatherApp

MyWeatherApp is a simple REST API built with ASP.NET Core that provides weather forecasts and country information based on city names. It uses the [REST Countries API](https://restcountries.com/) to fetch country details for capital cities.

---

## Features

- **Weather Forecast**: Get a 5-day weather forecast with random temperature and summary.
- **City to Country Mapping**: Fetch the country name for a given city (supports capital cities).
- **OpenAPI Support**: Includes OpenAPI documentation for easy API exploration.

---

## Prerequisites

Before running the application, ensure you have the following installed:

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Azure CLI](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli) (if deploying to Azure)

---

## Getting Started

### 1. Clone the Repository
```bash
git clone <repository-url>
cd MyWeatherApp

**### 2. Build the application**
dotnet build

### 3. Run the application locally
dotnet run

API Endpoints
Weather Forecast
Endpoint: /weatherforecast
Method: GET
Description: Returns a 5-day weather forecast with random temperatures and summaries.

City to Country
Endpoint: /city/{cityName}
Method: GET
Description: Returns the country name for a given city (supports capital cities).
