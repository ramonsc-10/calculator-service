#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src

COPY ["CodingChallengeCalculatorService.ConsoleApp/CodingChallengeCalculatorService.ConsoleApp.csproj", "CodingChallengeCalculatorService.ConsoleApp/"]
COPY ["CodingChallengeCalculatorService.RestApi/CodingChallengeCalculatorService.RestApi.csproj", "CodingChallengeCalculatorService.RestApi/"]
RUN dotnet restore "CodingChallengeCalculatorService.ConsoleApp/CodingChallengeCalculatorService.ConsoleApp.csproj"

COPY . .
WORKDIR "/src/CodingChallengeCalculatorService.ConsoleApp"
RUN dotnet publish "CodingChallengeCalculatorService.ConsoleApp.csproj" -c Release -o /app


FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine
WORKDIR /app

COPY --from=build /app/ ./

CMD dotnet CodingChallengeCalculatorService.ConsoleApp.dll
