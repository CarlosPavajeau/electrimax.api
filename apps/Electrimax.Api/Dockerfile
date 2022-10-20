FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["apps/Electrimax.Api/Electrimax.Api.csproj", "Electrimax.Api/"]
RUN dotnet restore "apps/Electrimax.Api/Electrimax.Api.csproj"
COPY . .
WORKDIR "/src/Electrimax.Api"
RUN dotnet build "Electrimax.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Electrimax.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Electrimax.Api.dll"]
