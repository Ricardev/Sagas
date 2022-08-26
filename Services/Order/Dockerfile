﻿FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Order/Order.csproj", "Service/Order/"]
COPY ["Services/Order/Program.cs", "Service/Order/"]
COPY ["Application/Order/Application.Order.csproj", "Application/Order/"]
COPY ["Domain/Order/Domain.Order.csproj", "Domain/Order/"]
COPY ["MessageBroker/MessageBroker.csproj", "MessageBroker/"]
COPY ["Infra/Order/Infra.Order.csproj", "Infra/Order/"]
RUN dotnet restore "Service/Order/Order.csproj"
COPY . .
WORKDIR "/src/Service/Order"

FROM build AS publish
RUN dotnet publish "Order.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Order.dll"]