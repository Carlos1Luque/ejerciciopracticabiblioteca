using Microsoft.EntityFrameworkCore;
using Biblioteca;

namespace Biblioteca.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Prestamo> Prestamos => Set<Prestamo>();
    public DbSet<Libro> Libros => Set<Libro>();
}
