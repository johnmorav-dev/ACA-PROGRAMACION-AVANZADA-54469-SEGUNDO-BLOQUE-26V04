using System.Data;
using AcaBiblioteca.Entidades;

namespace AcaBiblioteca.Datos
{
    /// <summary>Consultas consolidadas (JOIN, GROUP BY) para el módulo de reportes.</summary>
    public class ReporteDAO : DaoBase
    {
        public DataTable PrestamosActivos()
        {
            return EjecutarConsulta(@"
                SELECT p.IdPrestamo, u.Nombre + ' ' + u.Apellido AS Usuario, u.Documento,
                       l.ISBN, l.Titulo, p.FechaPrestamo,
                       DATEDIFF(DAY, p.FechaPrestamo, CAST(GETDATE() AS DATE)) AS DiasPrestado,
                       p.Estado
                FROM Prestamos p
                INNER JOIN Usuarios u ON p.IdUsuario = u.IdUsuario
                INNER JOIN Libros l ON p.ISBN = l.ISBN
                WHERE p.Estado = 'Prestado'
                ORDER BY p.FechaPrestamo DESC");
        }

        public DataTable PrestamosDevueltos()
        {
            return EjecutarConsulta(@"
                SELECT p.IdPrestamo, u.Nombre + ' ' + u.Apellido AS Usuario,
                       l.ISBN, l.Titulo, p.FechaPrestamo, p.FechaDevolucion, p.Estado
                FROM Prestamos p
                INNER JOIN Usuarios u ON p.IdUsuario = u.IdUsuario
                INNER JOIN Libros l ON p.ISBN = l.ISBN
                WHERE p.Estado = 'Devuelto'
                ORDER BY p.FechaDevolucion DESC");
        }

        public DataTable HistorialPrestamos()
        {
            return EjecutarConsulta(@"
                SELECT p.IdPrestamo, u.Nombre + ' ' + u.Apellido AS Usuario,
                       l.ISBN, l.Titulo, p.FechaPrestamo, p.FechaDevolucion, p.Estado
                FROM Prestamos p
                INNER JOIN Usuarios u ON p.IdUsuario = u.IdUsuario
                INNER JOIN Libros l ON p.ISBN = l.ISBN
                ORDER BY p.FechaPrestamo DESC, p.IdPrestamo DESC");
        }

        public DataTable InventarioLibros()
        {
            return EjecutarConsulta(@"
                SELECT l.ISBN, l.Titulo, a.Nombre + ' ' + a.Apellido AS Autor,
                       e.Nombre AS Editorial, l.Categoria, l.Anio,
                       l.Existencias AS Disponibles,
                       (SELECT COUNT(*) FROM Prestamos p
                        WHERE p.ISBN = l.ISBN AND p.Estado = 'Prestado') AS Prestados
                FROM Libros l
                INNER JOIN Autores a ON l.IdAutor = a.IdAutor
                INNER JOIN Editoriales e ON l.IdEditorial = e.IdEditorial
                ORDER BY l.Titulo");
        }

        public DataTable LibrosDisponibles()
        {
            return EjecutarConsulta(@"
                SELECT l.ISBN, l.Titulo, a.Nombre + ' ' + a.Apellido AS Autor,
                       e.Nombre AS Editorial, l.Existencias AS Disponibles
                FROM Libros l
                INNER JOIN Autores a ON l.IdAutor = a.IdAutor
                INNER JOIN Editoriales e ON l.IdEditorial = e.IdEditorial
                WHERE l.Existencias > 0
                ORDER BY l.Titulo");
        }

        public DataTable UsuariosRegistrados()
        {
            return EjecutarConsulta(@"
                SELECT u.IdUsuario, u.Nombre, u.Apellido, u.Documento, u.Telefono, u.Correo,
                       COUNT(p.IdPrestamo) AS TotalPrestamos
                FROM Usuarios u
                LEFT JOIN Prestamos p ON p.IdUsuario = u.IdUsuario
                GROUP BY u.IdUsuario, u.Nombre, u.Apellido, u.Documento, u.Telefono, u.Correo
                ORDER BY u.Nombre, u.Apellido");
        }

        public DataTable UsuariosConPrestamosActivos()
        {
            return EjecutarConsulta(@"
                SELECT u.Nombre + ' ' + u.Apellido AS Usuario, u.Documento, u.Telefono, u.Correo,
                       COUNT(*) AS PrestamosActivos
                FROM Usuarios u
                INNER JOIN Prestamos p ON p.IdUsuario = u.IdUsuario
                WHERE p.Estado = 'Prestado'
                GROUP BY u.Nombre, u.Apellido, u.Documento, u.Telefono, u.Correo
                ORDER BY PrestamosActivos DESC, Usuario");
        }

        public DataTable AutoresConLibros()
        {
            return EjecutarConsulta(@"
                SELECT a.IdAutor, a.Nombre + ' ' + a.Apellido AS Autor,
                       COUNT(l.ISBN) AS CantidadLibros
                FROM Autores a
                LEFT JOIN Libros l ON l.IdAutor = a.IdAutor
                GROUP BY a.IdAutor, a.Nombre, a.Apellido
                ORDER BY CantidadLibros DESC, Autor");
        }

        public DataTable EditorialesConLibros()
        {
            return EjecutarConsulta(@"
                SELECT e.IdEditorial, e.Nombre AS Editorial,
                       COUNT(l.ISBN) AS CantidadLibros
                FROM Editoriales e
                LEFT JOIN Libros l ON l.IdEditorial = e.IdEditorial
                GROUP BY e.IdEditorial, e.Nombre
                ORDER BY CantidadLibros DESC, Editorial");
        }

        public DataTable LibrosMasPrestados()
        {
            return EjecutarConsulta(@"
                SELECT TOP 10 l.ISBN, l.Titulo, a.Nombre + ' ' + a.Apellido AS Autor,
                       COUNT(p.IdPrestamo) AS VecesPrestado
                FROM Libros l
                INNER JOIN Autores a ON l.IdAutor = a.IdAutor
                LEFT JOIN Prestamos p ON p.ISBN = l.ISBN
                GROUP BY l.ISBN, l.Titulo, a.Nombre, a.Apellido
                ORDER BY VecesPrestado DESC, l.Titulo");
        }

        /// <summary>Indicadores generales para el formulario de Inicio.</summary>
        public ResumenBiblioteca ObtenerResumen()
        {
            DataTable tabla = EjecutarConsulta(@"
                SELECT
                    (SELECT COUNT(*) FROM Libros) AS TotalLibros,
                    (SELECT ISNULL(SUM(Existencias), 0) FROM Libros) AS EjemplaresDisponibles,
                    (SELECT COUNT(*) FROM Usuarios) AS TotalUsuarios,
                    (SELECT COUNT(*) FROM Autores) AS TotalAutores,
                    (SELECT COUNT(*) FROM Editoriales) AS TotalEditoriales,
                    (SELECT COUNT(*) FROM Prestamos WHERE Estado = 'Prestado') AS PrestamosActivos,
                    (SELECT COUNT(*) FROM Prestamos WHERE Estado = 'Devuelto') AS PrestamosDevueltos");

            DataRow fila = tabla.Rows[0];

            return new ResumenBiblioteca
            {
                TotalLibros = Convert.ToInt32(fila["TotalLibros"]),
                EjemplaresDisponibles = Convert.ToInt32(fila["EjemplaresDisponibles"]),
                TotalUsuarios = Convert.ToInt32(fila["TotalUsuarios"]),
                TotalAutores = Convert.ToInt32(fila["TotalAutores"]),
                TotalEditoriales = Convert.ToInt32(fila["TotalEditoriales"]),
                PrestamosActivos = Convert.ToInt32(fila["PrestamosActivos"]),
                PrestamosDevueltos = Convert.ToInt32(fila["PrestamosDevueltos"])
            };
        }
    }
}
