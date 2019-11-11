# build application image
FROM mcr.microsoft.com/dotnet/core/sdk:3.0 as build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY ./src ./
RUN dotnet restore  ./CQRSService/CQRSService.sln

# build
RUN dotnet publish ./CQRSService/CQRSService.sln -c Release -o out

# build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS final
WORKDIR /app
COPY --from=build-env /app/out ./
EXPOSE 5001

ENTRYPOINT ["dotnet", "CQRSService.GRPC.dll"]