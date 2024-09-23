FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . .  
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out ./

EXPOSE 5028

ENV ASPNETCORE_URLS=http://+:5028

ENTRYPOINT ["dotnet", "CustomerCrudApi.dll"]FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . .  
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out ./

# Expor a porta 5028
EXPOSE 5028

# Definir a porta 5028 para o Kestrel escutar
ENV ASPNETCORE_URLS=http://+:5028

ENTRYPOINT ["dotnet", "CustomerCrudApi.dll"]FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . .  
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out ./

# Expor a porta 5028
EXPOSE 5028

# Definir a porta 5028 para o Kestrel escutar
ENV ASPNETCORE_URLS=http://+:5028

ENTRYPOINT ["dotnet", "CustomerCrudApi.dll"]