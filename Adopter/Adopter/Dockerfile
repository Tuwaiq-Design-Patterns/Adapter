FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Adopter/Adopter.csproj", "Adopter/"]
RUN dotnet restore "Adopter/Adopter.csproj"
COPY . .
WORKDIR "/src/Adopter"
RUN dotnet build "Adopter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Adopter.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Adopter.dll"]
