using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biblioteca;
using Biblioteca.Data;
namespace Biblioteca.Business;
public class PrestamosService
{
    private readonly PrestamosRepository _repository;

    public PrestamosService(PrestamosRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Libro>> ObtenerLibrosAsync() =>
        _repository.ObtenerLibrosAsync();

    public ValueTask<Libro?> ObtenerLibroAsync(int id) =>
        _repository.ObtenerLibroAsync(id);

    public Task<List<Prestamo>> ObtenerPrestamosAsync() =>
        _repository.ObtenerPrestamosAsync();

    public ValueTask<Prestamo?> ObtenerPrestamoAsync(int id) =>
        _repository.ObtenerPrestamoAsync(id);

    public Task CrearLibroAsync(Libro libro) =>
        _repository.CrearLibroAsync(libro);

    public Task CrearPrestamoAsync(Prestamo prestamo) =>
        _repository.CrearPrestamoAsync(prestamo);

    public Task<int> GuardarCambiosAsync() =>
        _repository.GuardarCambiosAsync();
}