#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["API/CleanArchitecture.API.csproj", "API/"]
COPY ["Infrastructure/IoC/CleanArchitecture.Infra.IoC.csproj", "Infrastructure/IoC/"]
COPY ["Core/Application/CleanArchitecture.Core.Application.csproj", "Core/Application/"]
COPY ["Core/Domain/CleanArchitecture.Core.Domain.csproj", "Core/Domain/"]
COPY ["Infrastructure/Data/CleanArchitecture.Infra.Data.csproj", "Infrastructure/Data/"]
RUN dotnet restore "API/CleanArchitecture.API.csproj"
COPY . .
WORKDIR "/src/API"
RUN dotnet build "CleanArchitecture.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CleanArchitecture.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanArchitecture.API.dll"]
