FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/ApiGateway/ApiGateway.csproj", "Service/ApiGateway/"]
COPY ["Services/ApiGateway/Program.cs", "Service/ApiGateway/"]
RUN dotnet restore "Service/ApiGateway/ApiGateway.csproj"
COPY . .
WORKDIR "/src/Service/ApiGateway"
RUN dotnet build "ApiGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiGateway.dll"]
