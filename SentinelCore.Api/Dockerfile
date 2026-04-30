FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["SentinelCore.Api/SentinelCore.Api.csproj", "SentinelCore.Api/"]
RUN dotnet restore "SentinelCore.Api/SentinelCore.Api.csproj"

COPY SentinelCore.Api/ SentinelCore.Api/
WORKDIR "/src/SentinelCore.Api"

RUN dotnet build "SentinelCore.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build as publish

RUN dotnet publish "SentinelCore.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SentinelCore.Api.dll"]