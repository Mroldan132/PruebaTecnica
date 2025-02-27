# Etapa 1: Construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar y restaurar dependencias
COPY ["PruebaTecnicaDelosi/PruebaTecnicaDelosi.csproj", "PruebaTecnicaDelosi/"]
RUN dotnet restore "PruebaTecnicaDelosi/PruebaTecnicaDelosi.csproj"

# Copiar el código fuente
COPY PruebaTecnicaDelosi/ PruebaTecnicaDelosi/
WORKDIR "/src/PruebaTecnicaDelosi"
RUN dotnet build "PruebaTecnicaDelosi.csproj" -c Release -o /app/build

# Etapa 2: Publicación
FROM build AS publish
RUN dotnet publish "PruebaTecnicaDelosi.csproj" -c Release -o /app/publish

# Etapa 3: Ejecución (Usa la imagen correcta para producción)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Configurar puerto correctamente
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000

# Copiar la aplicación publicada desde la etapa anterior
COPY --from=publish /app/publish .

# Ejecutar la aplicación
ENTRYPOINT ["dotnet", "PruebaTecnicaDelosi.dll"]
