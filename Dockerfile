#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
ARG BUILD_CONTAINER=false
WORKDIR /src
COPY ["Directory.Packages.props", "."]
COPY ["Directory.Build.props", "."]
COPY ["Tranchy.Ask.Api/Tranchy.Ask.Api.csproj", "Tranchy.Ask.Api/"]
COPY ["Tranchy.QuestionModule/Tranchy.QuestionModule.csproj", "Tranchy.QuestionModule/"]
COPY ["Tranchy.Common/Tranchy.Common.csproj", "Tranchy.Common/"]
RUN dotnet restore "./Tranchy.Ask.Api/Tranchy.Ask.Api.csproj"
COPY . .
WORKDIR "/src/Tranchy.Ask.Api"
RUN dotnet build "./Tranchy.Ask.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Tranchy.Ask.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tranchy.Ask.Api.dll"]