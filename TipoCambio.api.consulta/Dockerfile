#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TipoCambio.api.consulta/TipoCambio.api.consulta.csproj", "TipoCambio.api.consulta/"]
COPY ["Modelo/Modelo.csproj", "Modelo/"]
COPY ["Aplicacion/Aplicacion.csproj", "Aplicacion/"]
COPY ["Persistencia/Persistencia.csproj", "Persistencia/"]
RUN dotnet restore "TipoCambio.api.consulta/TipoCambio.api.consulta.csproj"
COPY . .
WORKDIR "/src/TipoCambio.api.consulta"
RUN dotnet build "TipoCambio.api.consulta.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TipoCambio.api.consulta.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TipoCambio.api.consulta.dll"]