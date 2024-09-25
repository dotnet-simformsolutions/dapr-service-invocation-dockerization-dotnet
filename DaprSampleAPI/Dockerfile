#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.


FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

RUN apt-get update \
    && apt-get install -y --allow-unauthenticated \
        libc6-dev \
        libgdiplus \
        libx11-dev \
     && rm -rf /var/lib/apt/lists/*

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DaprSampleAPI/DaprSampleAPI.csproj", "DaprSampleAPI/"]
RUN dotnet restore "DaprSampleAPI/DaprSampleAPI.csproj"
COPY . .
WORKDIR "/src/DaprSampleAPI"
RUN dotnet build "DaprSampleAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DaprSampleAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DaprSampleAPI.dll"]