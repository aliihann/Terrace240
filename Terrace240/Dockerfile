## См. статью по ссылке https://aka.ms/customizecontainer, чтобы узнать как настроить контейнер отладки и как Visual Studio использует этот Dockerfile для создания образов для ускорения отладки.
#
## Этот этап используется при запуске из VS в быстром режиме (по умолчанию для конфигурации отладки)
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER $APP_UID
#WORKDIR /app
#EXPOSE 8080
##EXPOSE 8081
##
##
### Этот этап используется для сборки проекта службы
##FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
##ARG BUILD_CONFIGURATION=Release
##WORKDIR /src
##COPY ["Terrace240/Terrace240.csproj", "Terrace240/"]
##RUN dotnet restore "./Terrace240/Terrace240.csproj"
##COPY . .
##WORKDIR "/src/Terrace240"
##RUN dotnet build "./Terrace240.csproj" -c $BUILD_CONFIGURATION -o /app/build
##
### Этот этап используется для публикации проекта службы, который будет скопирован на последний этап
##FROM build AS publish
##ARG BUILD_CONFIGURATION=Release
##RUN dotnet publish "./Terrace240.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
##
### Этот этап используется в рабочей среде или при запуске из VS в обычном режиме (по умолчанию, когда конфигурация отладки не используется)
##FROM base AS final
##WORKDIR /app
##COPY --from=publish /app/publish .
##ENTRYPOINT ["dotnet", "Terrace240.dll"]
#
## См. статью по ссылке https://aka.ms/customizecontainer, чтобы узнать как настроить контейнер отладки и как Visual Studio использует этот Dockerfile для создания образов для ускорения отладки.
#
## Этот этап используется при запуске из VS в быстром режиме (по умолчанию для конфигурации отладки)
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER $APP_UID
#WORKDIR /app
#EXPOSE 8080
#EXPOSE 8081
#
#

## Build stage
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#WORKDIR /src
#
## Копируем csproj и восстанавливаем зависимости
#COPY ["Terrace240.csproj", "./"]
#RUN dotnet restore "Terrace240.csproj"
#
## Копируем весь код и публикуем
#COPY . .
#RUN dotnet publish -c Release -o /app/publish
#
## Runtime stage
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
#WORKDIR /app
#COPY --from=build /app/publish .
#ENTRYPOINT ["dotnet", "Terrace240.dll"]


# 1. Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем csproj и восстанавливаем зависимости
COPY Terrace240.csproj ./
RUN dotnet restore

# Копируем всё остальное и публикуем
COPY . .
RUN dotnet publish -c Release -o /app/publish

# 2. Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Terrace240.dll"]