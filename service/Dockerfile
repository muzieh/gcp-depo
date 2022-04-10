FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Depo/Depo.csproj", "Depo/"]
RUN dotnet restore "Depo/Depo.csproj"
COPY . .
WORKDIR "/src/Depo"
RUN dotnet build "Depo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Depo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Depo.dll"]
