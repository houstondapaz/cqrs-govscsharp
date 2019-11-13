FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 5001
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["CQRSService.Service/CQRSService.Service.csproj", "CQRSService.Service/"]
COPY ["CQRSService.Client/CQRSService.Client.csproj", "CQRSService.Client/"]
COPY ["CQRSService.Domain/CQRSService.Domain.csproj", "CQRSService.Domain/"]
RUN dotnet restore "CQRSService.Service/CQRSService.Service.csproj"
COPY . .
WORKDIR "/src/CQRSService.Service"
RUN dotnet build "CQRSService.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CQRSService.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CQRSService.Service.dll"]