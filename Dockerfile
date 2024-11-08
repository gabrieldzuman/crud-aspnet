FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CrudApi/CrudApi.csproj", "CrudApi/"]
RUN dotnet restore "CrudApi/CrudApi.csproj"
COPY . .
WORKDIR "/src/CrudApi"
RUN dotnet build "CrudApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CrudApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CrudApi.dll"]
