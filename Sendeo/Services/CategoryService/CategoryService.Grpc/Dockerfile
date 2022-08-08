#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/CategoryService/CategoryService.Grpc/CategoryService.Grpc.csproj", "Services/CategoryService/CategoryService.Grpc/"]
COPY ["Services/CategoryService/CategoryService.Data/CategoryService.Data.csproj", "Services/CategoryService/CategoryService.Data/"]
COPY ["Services/CategoryService/CategoryService.Core/CategoryService.Core.csproj", "Services/CategoryService/CategoryService.Core/"]
RUN dotnet restore "Services/CategoryService/CategoryService.Grpc/CategoryService.Grpc.csproj"
COPY . .
WORKDIR "/src/Services/CategoryService/CategoryService.Grpc"
RUN dotnet build "CategoryService.Grpc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CategoryService.Grpc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CategoryService.Grpc.dll"]