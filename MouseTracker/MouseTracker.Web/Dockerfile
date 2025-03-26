FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MouseTracker.Web/MouseTracker.Web.csproj", "MouseTracker.Web/"]
COPY ["MouseTracker.Application/MouseTracker.Application.csproj", "MouseTracker.Application/"]
COPY ["MouseTracker.Domain/MouseTracker.Domain.csproj", "MouseTracker.Domain/"]
COPY ["MouseTracker.Infrastructure/MouseTracker.Infrastructure.csproj", "MouseTracker.Infrastructure/"]
RUN dotnet restore "MouseTracker.Web/MouseTracker.Web.csproj"
COPY . .
WORKDIR "/src/MouseTracker.Web"
RUN dotnet build "MouseTracker.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MouseTracker.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MouseTracker.Web.dll"]
