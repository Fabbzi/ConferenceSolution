FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
# Environment variables for the connection string
ENV SQL_CONNECTION_STRING="Server=host.docker.internal,1400;Database=Conference;Trusted_Connection=False;MultipleActiveResultSets=true;User ID=sa;Password=Linuspenis69;TrustServerCertificate=True;"

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ConferenceAPI/ConferenceAPI.csproj", "ConferenceAPI/"]
RUN dotnet restore "ConferenceAPI/ConferenceAPI.csproj"
COPY . .
WORKDIR "/src/ConferenceAPI"
RUN dotnet build "ConferenceAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ConferenceAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConferenceAPI.dll"]
