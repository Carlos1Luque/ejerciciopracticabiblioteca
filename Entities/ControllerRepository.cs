using Microsoft.EntityFrameworkCore;
namespace Biblioteca.Data;
public class PrestamosRepository
{
    private readonly AppDbContext _context;

    public PrestamosRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<List<Libro>> ObtenerLibrosAsync() =>
        _context.Libros.AsNoTracking().ToListAsync();

    public ValueTask<Libro?> ObtenerLibroAsync(int id) =>
        _context.Libros.FindAsync(id);

    public Task<List<Prestamo>> ObtenerPrestamosAsync() =>
        _context.Prestamos.AsNoTracking().ToListAsync();

    public ValueTask<Prestamo?> ObtenerPrestamoAsync(int id) =>
        _context.Prestamos.FindAsync(id);

    public Task CrearLibroAsync(Libro libro) =>
        _context.Libros.AddAsync(libro).AsTask();

    public Task CrearPrestamoAsync(Prestamo prestamo) =>
        _context.Prestamos.AddAsync(prestamo).AsTask();

    public Task<int> GuardarCambiosAsync() =>
        _context.SaveChangesAsync();
}