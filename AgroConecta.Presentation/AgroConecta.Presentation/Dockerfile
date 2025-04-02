FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AgroConecta.Shared/AgroConecta.Shared.csproj", "AgroConecta.Shared/"]
COPY ["AgroConecta.Domain/AgroConecta.Domain.csproj", "AgroConecta.Domain/"]
COPY ["AgroConecta.Application/AgroConecta.Application.csproj", "AgroConecta.Application/"]
COPY ["AgroConecta.Infrastructure/AgroConecta.Infrastructure.csproj", "AgroConecta.Infrastructure/"]

COPY ["AgroConecta.Presentation/AgroConecta.Presentation/AgroConecta.Presentation.csproj", "AgroConecta.Presentation/AgroConecta.Presentation/"]
COPY ["AgroConecta.Presentation/AgroConecta.Presentation.Client/AgroConecta.Presentation.Client.csproj", "AgroConecta.Presentation/AgroConecta.Presentation.Client/"]
RUN dotnet restore "AgroConecta.Presentation/AgroConecta.Presentation/AgroConecta.Presentation.csproj"
COPY . .
WORKDIR "/src/AgroConecta.Presentation/AgroConecta.Presentation"
RUN dotnet build "AgroConecta.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AgroConecta.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
USER root
RUN mkdir -p /app/wwwroot/uploads && chmod -R 755 /app/wwwroot/uploads
USER $APP_UID
ENTRYPOINT ["dotnet", "AgroConecta.Presentation.dll"]
