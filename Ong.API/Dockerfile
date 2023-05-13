FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Ong.API/Ong.API.csproj", "Ong.API/"]
COPY ["Ong.Infra.Data/Ong.Infra.Data.csproj", "Ong.Infra.Data/"]
COPY ["Ong.Domain/Ong.Domain.csproj", "Ong.Domain/"]
RUN dotnet restore "Ong.API/Ong.API.csproj"
COPY . .
WORKDIR "/src/Ong.API"
RUN dotnet build "Ong.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ong.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ong.API.dll"]