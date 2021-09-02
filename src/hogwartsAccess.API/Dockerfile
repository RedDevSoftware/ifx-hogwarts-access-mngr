FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/hogwartsAccess.API/hogwartsAccess.API.csproj", "src/hogwartsAccess.API/"]
COPY ["src/hogwartsAccess.Persistence/hogwartsAccess.Persistence.csproj", "src/hogwartsAccess.Persistence/"]
COPY ["src/hogwartsAccess.Application/hogwartsAccess.Application.csproj", "src/hogwartsAccess.Application/"]
COPY ["src/hogwartsAccess.Domain/hogwartsAccess.Domain.csproj", "src/hogwartsAccess.Domain/"]
RUN dotnet restore "src/hogwartsAccess.API/hogwartsAccess.API.csproj"
COPY . .
WORKDIR "/src/src/hogwartsAccess.API"
RUN dotnet build "hogwartsAccess.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "hogwartsAccess.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ifx.Services.hogwartsAccess.API.dll"]