FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Payment/Payment.csproj", "Payment/"]
COPY ["MessageBroker/MessageBroker.csproj", "MessageBroker/"]
COPY ["Domain/Payment/Domain.Payment.csproj", "Payment/"]
COPY ["Application/Payment/Application.Payment.csproj", "Payment/"]
COPY ["Infra/Payment/Infra.Payment.csproj", "Payment/"]
RUN dotnet restore "Services/Payment/Payment.csproj"
COPY . .
WORKDIR "/src/Payment"
RUN dotnet build "Payment.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Payment.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Payment.dll"]
