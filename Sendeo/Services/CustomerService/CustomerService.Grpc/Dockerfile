#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/CustomerService/CustomerService.Grpc/CustomerService.Grpc.csproj", "Services/CustomerService/CustomerService.Grpc/"]
COPY ["Services/CustomerService/CustomerService.Data/CustomerService.Data.csproj", "Services/CustomerService/CustomerService.Data/"]
COPY ["Services/CustomerService/CustomerService.Core/CustomerService.Core.csproj", "Services/CustomerService/CustomerService.Core/"]
RUN dotnet restore "Services/CustomerService/CustomerService.Grpc/CustomerService.Grpc.csproj"
COPY . .
WORKDIR "/src/Services/CustomerService/CustomerService.Grpc"
RUN dotnet build "CustomerService.Grpc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustomerService.Grpc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerService.Grpc.dll"]