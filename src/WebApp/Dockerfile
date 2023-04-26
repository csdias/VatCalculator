#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/WebApp/VatCalculator.WebApp.csproj", "src/WebApp/"]
COPY ["src/Application/VatCalculator.Application.csproj", "src/Application/"]
COPY ["src/Domain/VatCalculator.Domain.csproj", "src/Domain/"]
RUN dotnet restore "src/WebApp/VatCalculator.WebApp.csproj"
COPY . .
WORKDIR "/src/src/WebApp"
RUN dotnet build "VatCalculator.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VatCalculator.WebApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VatCalculator.WebApp.dll"]