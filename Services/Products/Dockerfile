FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
ENV ASPNETCORE_URLS=http://+:9002
EXPOSE 9002
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Products/Products.csproj", "Service/Products/"]
COPY ["Services/Products/Controllers/ProductController.cs", "Service/Products/Controllers/"]
COPY ["Services/Products/Program.cs", "Service/Products/"]
COPY ["Domain/Products/Domain.Products.csproj", "Domain/Products/"]
COPY ["Application/Products/Application.Products.csproj", "Application/Products/"]
COPY ["MessageBroker/MessageBroker.csproj", "MessageBroker/"]
COPY ["Infra/Products/Infra.Products.csproj", "Infra/Products/"]
COPY ["Infra/IoC/Infra.Ioc.Products/Infra.Ioc.Products.csproj", "Infra/IoC/Infra.Ioc.Products/"]
COPY ["Infra/IoC/Infra.Ioc.Products/DependencyInjector.cs", "Infra/IoC/Infra.Ioc.Products/"]
RUN dotnet restore "Service/Products/Products.csproj"
COPY . .
WORKDIR "/src/Service/Products"
# RUN dotnet build "AspnetRunBasics.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Products.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Products.dll"]
