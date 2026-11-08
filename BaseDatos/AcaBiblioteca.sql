/* =====================================================================
   ACA - PROGRAMACIÓN AVANZADA
   Sistema de Gestión de Biblioteca
   Script de base de datos para SQL Server 2022

   Contenido:
     1. Creación de la base de datos
     2. Creación de tablas, claves primarias y foráneas
     3. Restricciones de integridad (UNIQUE, CHECK, DEFAULT)
     4. Índices de apoyo a las consultas
     5. Datos de prueba

   IMPORTANTE: el script ELIMINA y vuelve a crear la base de datos
   AcaBiblioteca, de modo que siempre queda en un estado limpio y
   coherente. Ejecútelo completo (F5) en SQL Server Management Studio.
   ===================================================================== */

USE master;
GO

IF DB_ID('AcaBiblioteca') IS NOT NULL
BEGIN
    ALTER DATABASE AcaBiblioteca SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE AcaBiblioteca;
END
GO

-- 1. CREACIÓN DE LA BASE DE DATOS -------------------------------------
CREATE DATABASE AcaBiblioteca;
GO

USE AcaBiblioteca;
GO

-- 2. CREACIÓN DE TABLAS -----------------------------------------------

CREATE TABLE Autores
(
    IdAutor   INT IDENTITY(1,1) NOT NULL,
    Nombre    VARCHAR(100)      NOT NULL,
    Apellido  VARCHAR(100)      NOT NULL,

    CONSTRAINT PK_Autores PRIMARY KEY (IdAutor),
    -- No se permite registrar dos veces el mismo autor
    CONSTRAINT UQ_Autores_NombreApellido UNIQUE (Nombre, Apellido)
);
GO

CREATE TABLE Editoriales
(
    IdEditorial INT IDENTITY(1,1) NOT NULL,
    Nombre      VARCHAR(150)      NOT NULL,

    CONSTRAINT PK_Editoriales PRIMARY KEY (IdEditorial),
    CONSTRAINT UQ_Editoriales_Nombre UNIQUE (Nombre)
);
GO

CREATE TABLE Libros
(
    ISBN         VARCHAR(20)  NOT NULL,
    Titulo       VARCHAR(200) NOT NULL,
    IdAutor      INT          NOT NULL,
    IdEditorial  INT          NOT NULL,
    Categoria    VARCHAR(100) NULL,
    Anio         INT          NULL,
    Existencias  INT          NOT NULL CONSTRAINT DF_Libros_Existencias DEFAULT (0),

    CONSTRAINT PK_Libros PRIMARY KEY (ISBN),

    CONSTRAINT FK_Libros_Autores
        FOREIGN KEY (IdAutor) REFERENCES Autores (IdAutor),

    CONSTRAINT FK_Libros_Editoriales
        FOREIGN KEY (IdEditorial) REFERENCES Editoriales (IdEditorial),

    -- Las existencias nunca pueden quedar negativas
    CONSTRAINT CK_Libros_Existencias CHECK (Existencias >= 0),
    CONSTRAINT CK_Libros_Anio CHECK (Anio IS NULL OR Anio BETWEEN 1000 AND 2100)
);
GO

CREATE TABLE Usuarios
(
    IdUsuario  INT IDENTITY(1,1) NOT NULL,
    Nombre     VARCHAR(100)      NOT NULL,
    Apellido   VARCHAR(100)      NOT NULL,
    Documento  VARCHAR(30)       NOT NULL,
    Telefono   VARCHAR(30)       NULL,
    Correo     VARCHAR(150)      NULL,

    CONSTRAINT PK_Usuarios PRIMARY KEY (IdUsuario),
    CONSTRAINT UQ_Usuarios_Documento UNIQUE (Documento)
);
GO

CREATE TABLE Prestamos
(
    IdPrestamo       INT IDENTITY(1,1) NOT NULL,
    IdUsuario        INT               NOT NULL,
    ISBN             VARCHAR(20)       NOT NULL,
    FechaPrestamo    DATE              NOT NULL,
    FechaDevolucion  DATE              NULL,
    Estado           VARCHAR(20)       NOT NULL CONSTRAINT DF_Prestamos_Estado DEFAULT ('Prestado'),

    CONSTRAINT PK_Prestamos PRIMARY KEY (IdPrestamo),

    CONSTRAINT FK_Prestamos_Usuarios
        FOREIGN KEY (IdUsuario) REFERENCES Usuarios (IdUsuario),

    CONSTRAINT FK_Prestamos_Libros
        FOREIGN KEY (ISBN) REFERENCES Libros (ISBN),

    -- Solo se admiten estos dos estados
    CONSTRAINT CK_Prestamos_Estado CHECK (Estado IN ('Prestado', 'Devuelto')),

    -- Coherencia entre estado y fecha de devolución
    CONSTRAINT CK_Prestamos_EstadoFecha CHECK (
        (Estado = 'Prestado' AND FechaDevolucion IS NULL) OR
        (Estado = 'Devuelto' AND FechaDevolucion IS NOT NULL)
    ),

    -- La devolución no puede ser anterior al préstamo
    CONSTRAINT CK_Prestamos_Fechas CHECK (
        FechaDevolucion IS NULL OR FechaDevolucion >= FechaPrestamo
    )
);
GO

-- 3. ÍNDICES (optimización de búsquedas frecuentes) -------------------
CREATE INDEX IX_Libros_Titulo        ON Libros (Titulo);
CREATE INDEX IX_Libros_IdAutor       ON Libros (IdAutor);
CREATE INDEX IX_Prestamos_Estado     ON Prestamos (Estado);
CREATE INDEX IX_Prestamos_IdUsuario  ON Prestamos (IdUsuario);
CREATE INDEX IX_Prestamos_ISBN       ON Prestamos (ISBN);
GO

-- 4. DATOS DE PRUEBA --------------------------------------------------

INSERT INTO Usuarios (Nombre, Apellido, Documento, Telefono, Correo)
VALUES
    ('Ana',       'Pérez',     '1001001001', '3001234567', 'ana@gmail.com'),
    ('Carlos',    'Gómez',     '1001001002', '3012345678', 'carlos@gmail.com'),
    ('María',     'Rodríguez', '1001001003', '3023456789', 'maria@gmail.com'),
    ('Laura',     'Martínez',  '1001001004', '3034567890', 'laura.martinez@gmail.com'),
    ('Andrés',    'López',     '1001001005', '3045678901', 'andres.lopez@gmail.com'),
    ('Sofía',     'Hernández', '1001001006', '3056789012', 'sofia.hernandez@gmail.com'),
    ('Daniel',    'Torres',    '1001001007', '3067890123', 'daniel.torres@gmail.com'),
    ('Mariana',   'Ramírez',   '1001001008', '3078901234', 'mariana.ramirez@gmail.com'),
    ('Felipe',    'Castro',    '1001001009', '3089012345', 'felipe.castro@gmail.com'),
    ('Valentina', 'Morales',   '1001001010', '3090123456', 'valentina.morales@gmail.com');
GO

-- Se eliminaron los autores repetidos del script original
-- (Julio Cortázar e Isabel Allende aparecían dos veces).
INSERT INTO Autores (Nombre, Apellido)
VALUES
    ('Gabriel',    'García Márquez'),     -- 1
    ('Julio',      'Cortázar'),           -- 2
    ('Isabel',     'Allende'),            -- 3
    ('George',     'Orwell'),             -- 4
    ('Miguel',     'de Cervantes'),       -- 5
    ('Jane',       'Austen'),             -- 6
    ('Mario',      'Vargas Llosa'),       -- 7
    ('Jorge Luis', 'Borges'),             -- 8
    ('Antoine',    'de Saint-Exupéry'),   -- 9
    ('Ernest',     'Hemingway');          -- 10
GO

INSERT INTO Editoriales (Nombre)
VALUES
    ('Planeta'),               -- 1
    ('Alfaguara'),             -- 2
    ('Penguin Random House'),  -- 3
    ('Debolsillo'),            -- 4
    ('Anagrama'),              -- 5
    ('Seix Barral'),           -- 6
    ('Tusquets Editores');     -- 7
GO

-- Existencias = ejemplares totales; más abajo se descuentan los préstamos activos
INSERT INTO Libros (ISBN, Titulo, IdAutor, IdEditorial, Categoria, Anio, Existencias)
VALUES
    ('9780307474728', 'Cien años de soledad',              1,  1, 'Novela',              1967, 5),
    ('9780451524935', '1984',                              4,  3, 'Distopía',            1949, 4),
    ('9780060934347', 'Don Quijote de la Mancha',          5,  1, 'Novela',              1605, 3),
    ('9780141439518', 'Orgullo y prejuicio',               6,  4, 'Novela romántica',    1813, 5),
    ('9788437604947', 'Rayuela',                           2,  2, 'Novela',              1963, 2),
    ('9788401352836', 'La casa de los espíritus',          3,  1, 'Realismo mágico',     1982, 4),
    ('9788420471839', 'La ciudad y los perros',            7,  6, 'Novela',              1963, 3),
    ('9788420633114', 'Ficciones',                         8,  7, 'Cuentos',             1944, 2),
    ('9780156012195', 'El principito',                     9,  3, 'Literatura infantil', 1943, 6),
    ('9780684830490', 'El viejo y el mar',                 10, 5, 'Novela',              1952, 3),
    ('9780307389732', 'El amor en los tiempos del cólera', 1,  1, 'Novela',              1985, 4);
GO

INSERT INTO Prestamos (IdUsuario, ISBN, FechaPrestamo, FechaDevolucion, Estado)
VALUES
    (1,  '9780307474728', '2026-08-04', NULL,         'Prestado'),
    (2,  '9780451524935', '2026-08-05', '2026-08-14', 'Devuelto'),
    (3,  '9780060934347', '2026-08-07', NULL,         'Prestado'),
    (5,  '9780307389732', '2026-08-08', '2026-08-16', 'Devuelto'),
    (6,  '9780156012195', '2026-08-09', NULL,         'Prestado'),
    (7,  '9780684830490', '2026-08-10', '2026-08-15', 'Devuelto'),
    (8,  '9788420633114', '2026-08-11', NULL,         'Prestado'),
    (9,  '9788401352836', '2026-08-12', '2026-08-17', 'Devuelto'),
    (10, '9788420471839', '2026-08-13', NULL,         'Prestado'),
    (4,  '9780141439518', '2026-08-14', '2026-08-18', 'Devuelto');
GO

-- Cada préstamo activo ocupa un ejemplar: se descuenta de las existencias
UPDATE L
SET L.Existencias = L.Existencias - P.Activos
FROM Libros L
INNER JOIN (
    SELECT ISBN, COUNT(*) AS Activos
    FROM Prestamos
    WHERE Estado = 'Prestado'
    GROUP BY ISBN
) P ON P.ISBN = L.ISBN;
GO

-- 5. VERIFICACIÓN -----------------------------------------------------
SELECT 'Autores' AS Tabla, COUNT(*) AS Registros FROM Autores
UNION ALL SELECT 'Editoriales', COUNT(*) FROM Editoriales
UNION ALL SELECT 'Libros',      COUNT(*) FROM Libros
UNION ALL SELECT 'Usuarios',    COUNT(*) FROM Usuarios
UNION ALL SELECT 'Prestamos',   COUNT(*) FROM Prestamos;
GO
