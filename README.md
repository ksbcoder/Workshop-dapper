# WorkShop Dapper con SQL-Server

## Script Base de Datos SQL Server


```
IF EXISTS (SELECT * FROM sysdatabases WHERE (name = 'tiendaPeliculas')) 
  DROP DATABASE tiendaPeliculas;   

CREATE DATABASE tiendaPeliculas;
GO

-- Seleccionar la base de datos
USE tiendaPeliculas;
GO

-- Crear la tabla de directores
CREATE TABLE directores (
  id INT PRIMARY KEY IDENTITY,
  nombre VARCHAR(50) NOT NULL,
  fecha_nacimiento DATE NOT NULL,
  cantidad_premios INT NOT NULL
);
GO

-- Crear la tabla de peliculas
CREATE TABLE peliculas (
  id INT PRIMARY KEY IDENTITY,
  nombre_pelicula VARCHAR(50) NOT NULL,
  lanzamiento INT NOT NULL,
  cantidad_disponible INT NOT NULL,
  id_director INT NOT NULL,
  CONSTRAINT fk_directores FOREIGN KEY (id_director)
    REFERENCES directores(id)
);
GO

-- Insertar datos en la tabla de directores
INSERT INTO directores (nombre, fecha_nacimiento, cantidad_premios)
VALUES 
  ('Steven Spielberg', '1946-12-18', 178),
  ('Martin Scorsese', '1942-11-17', 146),
  ('Quentin Tarantino', '1963-03-27', 117),
  ('Christopher Nolan', '1970-07-30', 136),
  ('Sofia Coppola', '1971-05-14', 52),
  ( 'Woody Allen', '1935-12-01', 124),
  ('Alfonso Cuarón', '1961-11-28', 81),
  ('David Fincher', '1962-08-28', 83),
  ('James Cameron', '1954-08-16', 108),
  ('Francis Ford Coppola', '1939-04-07', 70);

-- Insertar datos en la tabla de peliculas
INSERT INTO peliculas (nombre_pelicula, lanzamiento, cantidad_disponible, id_director)
VALUES 
  ('La lista de Schindler', 1993, 20, 1),
  ('Taxi Driver', 1976, 15, 2),
  ('Pulp Fiction', 1994, 25, 3),
  ('El Caballero de la Noche', 2008, 18, 4),
  ('Lost in Translation', 2003, 12, 5),
  ('Annie Hall', 1977, 10, 6),
  ('Gravity', 2013, 5, 7),
  ('El club de la pelea', 1999, 22, 8),
  ('Avatar', 2009, 30, 9),
  ('El Padrino', 1972, 8, 10);

```