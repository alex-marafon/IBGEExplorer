FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Interfaces/IBGEExplorer.IBGEExplorer.API/IBGEExplorer.csproj", "IBGEExplorerAPI/"]
RUN dotnet restore "WebAPI/WebAPI.csproj"
COPY . .
WORKDIR "/src/IBGEExplorer"
RUN dotnet build "IBGEExplorer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IBGEExplorer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IBGEExplorer.dll"]
