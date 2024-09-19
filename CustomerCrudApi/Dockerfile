# Use a imagem base do .NET SDK para construir o aplicativo
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copie o csproj e restaure as dependências
COPY *.csproj ./
RUN dotnet restore

# Copie o restante dos arquivos e construa o aplicativo
COPY . ./  
RUN dotnet publish -c Release -o out

# Use a imagem base do .NET Runtime para rodar o aplicativo
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out ./
ENTRYPOINT ["dotnet", "CustomerCrudApi.dll"]
