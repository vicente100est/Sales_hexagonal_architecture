using AppVenta.Infraestructura.Datos.Contextos;

namespace AppVenta.Infraestructura.Datos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creando la base de datos si no existe...");
            VentaContexto db = new VentaContexto();
            db.Database.EnsureCreated();
            Console.WriteLine("DONE!!!!!!!!!!!!!!!!!!!");
            Console.ReadKey();
        }
    }
}