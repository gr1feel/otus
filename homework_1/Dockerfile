FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8000
EXPOSE 8000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DeliciousService/DeliciousService/DeliciousService.csproj", "DeliciousService/"]
RUN dotnet restore "DeliciousService/DeliciousService.csproj"
COPY . .
WORKDIR "/src/DeliciousService"
RUN dotnet build "DeliciousService/DeliciousService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DeliciousService/DeliciousService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DeliciousService.dll"]
