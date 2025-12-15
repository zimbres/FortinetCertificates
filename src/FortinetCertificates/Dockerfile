FROM mcr.microsoft.com/dotnet/aspnet:10.0-noble-chiseled AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/FortinetCertificates/FortinetCertificates.csproj", "src/FortinetCertificates/"]
RUN dotnet restore "./src/FortinetCertificates/FortinetCertificates.csproj"
COPY . .
WORKDIR "/src/src/FortinetCertificates"
RUN dotnet build "./FortinetCertificates.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FortinetCertificates.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FortinetCertificates.dll"]