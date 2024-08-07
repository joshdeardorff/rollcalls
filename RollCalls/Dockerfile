#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER root
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RollCalls/RollCalls.csproj", "RollCalls/"]
RUN dotnet restore "./RollCalls/RollCalls.csproj"
COPY . .
WORKDIR "/src/RollCalls"

ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RollCalls.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false --no-restore

FROM base AS final
USER root
WORKDIR /app
EXPOSE 80
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "RollCalls.dll"]