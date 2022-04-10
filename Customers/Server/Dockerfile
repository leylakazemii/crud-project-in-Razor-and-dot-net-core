#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Customers/Server/Customers.Server.csproj", "Customers/Server/"]
COPY ["Customers/Client/Customers.Client.csproj", "Customers/Client/"]
COPY ["Customers/Shared/Customers.Shared.csproj", "Customers/Shared/"]
RUN dotnet restore "Customers/Server/Customers.Server.csproj"
COPY . .
WORKDIR "/src/Customers/Server"
RUN dotnet build "Customers.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Customers.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Customers.Server.dll"]