using System;
using System.Collections.Generic;
using System.Linq;

namespace Carrito_De_Compras
{
    public class Tienda
    {
        public List<Categoria> Categorias { get; } = new List<Categoria>();
        public List<Producto> Productos { get; } = new List<Producto>();

        public Tienda()
        {
            var electronica = new Categoria("Electrónica", "Productos electrónicos");
            var ropa = new Categoria("Ropa", "Prendas de vestir");
            var alimentos = new Categoria("Alimentos", "Productos alimenticios");

            Categorias.AddRange(new[] { electronica, ropa, alimentos });

            Productos.Add(new Producto("Smartphone", 500m, 10, electronica));
            Productos.Add(new Producto("Laptop", 1200m, 5, electronica));
            Productos.Add(new Producto("Camiseta", 25m, 20, ropa));
            Productos.Add(new Producto("Pantalón", 45m, 15, ropa));
            Productos.Add(new Producto("Leche", 2.5m, 50, alimentos));
            Productos.Add(new Producto("Pan", 1.2m, 100, alimentos));
        }

        public void MostrarCategorias()
        {
            Console.WriteLine("\nCategorías disponibles:");
            foreach (var categoria in Categorias)
            {
                Console.WriteLine($"- {categoria}");
            }
            Console.WriteLine();
        }

        public void MostrarProductos()
        {
            Console.WriteLine("\nProductos disponibles:");
            foreach (var producto in Productos)
            {
                Console.WriteLine($"- {producto}");
            }
            Console.WriteLine();
        }

        public void MostrarProductosPorCategoria(string nombreCategoria)
        {
            var categoria = Categorias.FirstOrDefault(c => c.Nombre.Equals(nombreCategoria, StringComparison.OrdinalIgnoreCase));

            if (categoria == null)
            {
                Console.WriteLine("\nCategoría no encontrada.\n");
                return;
            }

            var productos = Productos.Where(p => p.Categoria.Nombre.Equals(nombreCategoria, StringComparison.OrdinalIgnoreCase)).ToList();

            Console.WriteLine($"\nProductos en la categoría '{nombreCategoria}':");
            foreach (var producto in productos)
            {
                Console.WriteLine($"- {producto}");
            }
            Console.WriteLine();
        }

        public Producto BuscarProducto(int codigo)
        {
            return Productos.FirstOrDefault(p => p.Codigo == codigo);
        }
    }
}