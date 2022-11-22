FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
ENV ASPNETCORE_URLS=http://+:9003
EXPOSE 9003
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Payment/Payment.csproj", "Service/Payment/"]
COPY ["Services/Payment/Controllers/PaymentController.cs", "Service/Payment/"]
COPY ["Services/Payment/Program.cs", "Service/Payment/"]
COPY ["MessageBroker/MessageBroker.csproj", "MessageBroker/"]
COPY ["Domain/Payment/Domain.Payment.csproj", "Domain/Payment/"]
COPY ["Application/Payment/Application.Payment.csproj", "Application/Payment/"]
COPY ["Infra/Payment/Infra.Payment.csproj", "Infra/Payment/"]
RUN dotnet restore "Service/Payment/Payment.csproj"
COPY . .
WORKDIR "/src/Service/Payment"
# RUN dotnet build "AspnetRunBasics.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Payment.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Payment.dll"]
