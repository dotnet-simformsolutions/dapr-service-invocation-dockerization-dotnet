#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DaprSampleAPI/Dapr.ServiceInvocation.csproj", "DaprSampleAPI/"]
RUN dotnet restore "./DaprSampleAPI/Dapr.ServiceInvocation.csproj"
COPY . .
WORKDIR "/src/DaprSampleAPI"
RUN dotnet build "./Dapr.ServiceInvocation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Dapr.ServiceInvocation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dapr.ServiceInvocation.dll"]