FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR / src
COPY ["Terrace240/Terrace240. csproj", "Terrace240/"]
COPY ["Terrace240. DAL/Terrace240.DAL.csproj", "Terrace240. DAL/"]
RUN dotnet restore "Terrace240/Terrace240. csproj"
COPY . .
WORKDIR "/src/Terrace240"
RUN dotnet publish -c Release -o /app/publish
FROM mcr-microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR / app
COPY --from=build /app/publish •
EXPOSE 8080
EXPOSE 8081
ENTRYPOINT ["dotnet", "Terrace240.d1l"]
