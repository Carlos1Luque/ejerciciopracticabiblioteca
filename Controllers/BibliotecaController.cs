using Microsoft.AspNetCore.Mvc;
using Biblioteca.Business;
namespace Biblioteca.Controllers;

[ApiController]
[Route("[controller]")]
public class PrestamosController : ControllerBase
{
    private readonly PrestamosService _service;

    public PrestamosController(PrestamosService service)
    {
        _service = service;
    }

    [HttpPost("Libros")]
    public async Task<IActionResult> CrearLibro([FromBody] Libro libroNuevo)
    {
        if (libroNuevo.Id <= 0)
        {
            return BadRequest("El Id tiene que ser mayor a 0");
        }

        if (await _service.ObtenerLibroAsync(libroNuevo.Id) is not null)
        {
            return Conflict("Ya existe un libro con ese Id");
        }

        if (string.IsNullOrWhiteSpace(libroNuevo.Titulo) ||
            string.IsNullOrWhiteSpace(libroNuevo.Genero))
        {
            return BadRequest("El nombre y el género del libro no pueden estar vacíos");
        }

        await _service.CrearLibroAsync(libroNuevo);
        await _service.GuardarCambiosAsync();
        return Ok(libroNuevo);
    }

    [HttpPost("Prestamos")]
    public async Task<IActionResult> CrearPrestamo([FromBody] Prestamo prestamoNuevo)
    {
        if (prestamoNuevo.Id <= 0)
        {
            return BadRequest("El Id tiene que ser mayor a 0");
        }

        if (await _service.ObtenerPrestamoAsync(prestamoNuevo.Id) is not null)
        {
            return Conflict("Ya existe un préstamo con ese Id");
        }

        if (string.IsNullOrWhiteSpace(prestamoNuevo.NombreSocio))
        {
            return BadRequest("El nombre del socio no puede estar vacío");
        }

        var libro = await _service.ObtenerLibroAsync(prestamoNuevo.LibroId);
        if (libro is null)
        {
            return NotFound("No existe un libro con ese Id");
        }

        if (!libro.Disponible)
        {
            return Conflict("El libro no está disponible");
        }

        libro.Disponible = false;
        await _service.CrearPrestamoAsync(prestamoNuevo);
        await _service.GuardarCambiosAsync();
        return Ok(prestamoNuevo);
    }

    [HttpGet("Libros")]
    public async Task<IActionResult> ObtenerLibros()
    {
        return Ok(await _service.ObtenerLibrosAsync());
    }

    [HttpGet("Prestamos")]
    public async Task<IActionResult> ObtenerPrestamos()
    {
        return Ok(await _service.ObtenerPrestamosAsync());
    }

    [HttpPut("{id:int}/libroDevuelto")]
    public async Task<IActionResult> LibroDevuelto([FromRoute] int id)
    {
        var prestamo = await _service.ObtenerPrestamoAsync(id);
        if (prestamo is null)
        {
            return NotFound("No existe un préstamo con ese Id");
        }

        if (prestamo.Devuelto)
        {
            return Conflict("Este préstamo ya fue devuelto");
        }

        var libro = await _service.ObtenerLibroAsync(prestamo.LibroId);
        if (libro is null)
        {
            return NotFound("No se encontró el libro asociado al préstamo");
        }

        prestamo.Devuelto = true;
        libro.Disponible = true;
        await _service.GuardarCambiosAsync();
        return Ok(prestamo);
    }
}
