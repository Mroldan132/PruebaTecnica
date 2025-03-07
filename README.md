# 🚀 Prueba Técnica Delosi

Este proyecto es una aplicación desarrollada en **.NET 8** y empaquetada en **Docker** para facilitar su despliegue y ejecución.

---

## 📌 Requisitos Previos

Antes de ejecutar este proyecto, asegúrate de tener instalados:

- [Docker](https://www.docker.com/get-started)
- [Git](https://git-scm.com/downloads)

---

## 🔹 Clonar el Repositorio

```
git clone https://github.com/tu-usuario/PruebaTecnicaDelosi.git
cd PruebaTecnicaDelosi
```

---

## 🏗 Construir y Ejecutar con Docker

### ✅ Opción 1: Usando `docker-compose`

Si tienes **Docker Compose**, simplemente ejecuta en la carpeta contenedora de la solucion:

```
docker-compose up --build
```

Esto hará lo siguiente:

- Construirá la imagen de Docker.
- Ejecutará el contenedor y expondrá el puerto `5000`.

Luego, accede a la aplicación en **[http://localhost:5000](http://localhost:5000)** 🚀

### ✅ Opción 2: Sin `docker-compose` (Manual)

Si prefieres ejecutar los comandos manualmente:

1️⃣ **Construir la imagen**

```
docker build -t pruebatecnica .
```

2️⃣ **Ejecutar el contenedor**

```
docker run -p 5000:5000 pruebatecnica
```

---

## 🔧 Variables de Entorno

Si necesitas modificar el entorno, puedes agregar variables en `docker-compose.yml` o pasar opciones al comando `docker run`.

Ejemplo en `docker-compose.yml`:

```
environment:
  - ASPNETCORE_ENVIRONMENT=Production
  - ASPNETCORE_URLS=http://+:5000
```

---

## 🛑 Detener el Contenedor

Si necesitas detener la aplicación, usa:

```
docker-compose down
```

O si lo ejecutaste manualmente:

```
docker ps  # Para ver el ID del contenedor
docker stop <ID_DEL_CONTENEDOR>
```

---