using Biblioteca.Data;

public class Prestamo
{
    public int Id {get; set; }
    public int LibroId {get; set;}
    public string NombreSocio {get; set;}
    public bool Devuelto {get; set;}
//     private int id;
//     private int libroId; 
//     private string nombreSocio; 
//     private DateTime fechaPrestamo; 
//     private DateTime fechaDevolucionEst;
//     private bool devuelto; 
//     public int Id {get{return id;} set{id = value;}}
//     public int LibroId{get{return libroId;} set{libroId = value;}}
//     public string NombreSocio{get{return nombreSocio;} set{nombreSocio = value;}}
//     public DateTime FechaPrestamo{get{return fechaPrestamo;} set{fechaPrestamo = value;}}
//     public DateTime FechaDevolucionEst{get{return fechaDevolucionEst;} set{fechaDevolucionEst = value;}}
//     public bool Devuelto {get{return devuelto;} set{devuelto = value;}}
//   public Prestamo(int id, int libroId, string nombreSocio, DateTime fechaPrestamo, DateTime fechaDevolucionEst, bool devuelto)
//     {
//         this.id = id;
//         this.libroId = libroId;
//         this.nombreSocio = nombreSocio;
//         this.fechaPrestamo = fechaPrestamo;
//         this.fechaDevolucionEst = fechaDevolucionEst; 
//         this.devuelto = devuelto;
//     }
}