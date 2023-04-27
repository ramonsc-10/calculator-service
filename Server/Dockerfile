#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src

COPY ["CodingChallengeCalculatorService.Api/CodingChallengeCalculatorService.Api.csproj", "CodingChallengeCalculatorService.Api/"]
COPY ["CodingChallengeCalculatorService.Infrastucture/CodingChallengeCalculatorService.Infrastructure.csproj", "CodingChallengeCalculatorService.Infrastucture/"]
COPY ["CodingChallengeCalculatorService.Domain/CodingChallengeCalculatorService.Domain.csproj", "CodingChallengeCalculatorService.Domain/"]
COPY ["CodingChallengeCalculatorService.Application/CodingChallengeCalculatorService.Application.csproj", "CodingChallengeCalculatorService.Application/"]
RUN dotnet restore "CodingChallengeCalculatorService.Api/CodingChallengeCalculatorService.Api.csproj"

COPY . .
WORKDIR "/src/CodingChallengeCalculatorService.Api"
RUN dotnet publish "CodingChallengeCalculatorService.Api.csproj" -c Release -o /app


FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine
WORKDIR /app

COPY --from=build /app/ ./

CMD [[ ! -z $PORT ]] && export ASPNETCORE_URLS="http://*:$PORT" ; dotnet CodingChallengeCalculatorService.Api.dll
