FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY . ./
RUN dotnet restore


COPY . ./
RUN dotnet publish -c Release -o /out


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app


ENV ASPNETCORE_ENVIRONMENT Development
COPY --from=build /out .

EXPOSE 8080
ENTRYPOINT ["dotnet", "PruebaTecnicaSivar.API.dll"]