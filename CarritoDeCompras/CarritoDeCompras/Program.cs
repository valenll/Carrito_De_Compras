using System;
using System.Collections.Generic;

namespace Carrito_De_Compras
{
    class Program
    {
        private static Tienda tienda = new Tienda();
        private static Carrito carrito = new Carrito();
        private static bool salir = false;

        static void Main(string[] args)
        {
            var menuActions = new Dictionary<string, Action>
            {
                {"1", () => tienda.MostrarCategorias()},
                {"2", () => tienda.MostrarProductos()},
                {"3", MostrarProductosPorCategoria},
                {"4", AgregarAlCarrito},
                {"5", EliminarDelCarrito},
                {"6", () => carrito.MostrarContenido()},
                {"7", () => Console.WriteLine($"\nTotal a pagar: ${carrito.CalcularTotal()}\n")},
                {"8", () => carrito.FinalizarCompra()},
                {"9", () => salir = true}
            };

            while (!salir)
            {
                MostrarMenu();
                string opcion = Console.ReadLine();

                if (menuActions.TryGetValue(opcion, out var action))
                {
                    action();
                }
                else
                {
                    Console.WriteLine("\nOpción no válida. Intente nuevamente.\n");
                }
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("MENÚ PRINCIPAL");
            Console.WriteLine("1. Ver categorías disponibles");
            Console.WriteLine("2. Ver productos disponibles");
            Console.WriteLine("3. Ver productos por categoría");
            Console.WriteLine("4. Agregar producto al carrito");
            Console.WriteLine("5. Eliminar producto del carrito");
            Console.WriteLine("6. Ver contenido del carrito");
            Console.WriteLine("7. Ver total a pagar");
            Console.WriteLine("8. Finalizar compra");
            Console.WriteLine("9. Salir");
            Console.Write("Seleccione una opción: ");
        }

        static void MostrarProductosPorCategoria()
        {
            Console.Write("\nIngrese el nombre de la categoría: ");
            string nombreCategoria = Console.ReadLine();
            tienda.MostrarProductosPorCategoria(nombreCategoria);
        }

        static void AgregarAlCarrito()
        {
            try
            {
                Console.Write("\nIngrese el código del producto: ");
                int codigo = int.Parse(Console.ReadLine());

                Console.Write("Ingrese la cantidad: ");
                int cantidad = int.Parse(Console.ReadLine());

                if (cantidad <= 0)
                {
                    Console.WriteLine("\nLa cantidad debe ser mayor que cero.\n");
                    return;
                }

                Producto producto = tienda.BuscarProducto(codigo);
                if (producto == null)
                {
                    Console.WriteLine("\nProducto no encontrado.\n");
                    return;
                }

                if (producto.Stock < cantidad)
                {
                    Console.WriteLine($"\nNo hay suficiente stock. Stock disponible: {producto.Stock}\n");
                    return;
                }

                carrito.AgregarItem(producto, cantidad);
                Console.WriteLine($"\nProducto '{producto.Nombre}' agregado al carrito.\n");
            }
            catch (FormatException)
            {
                Console.WriteLine("\nEntrada no válida. Debe ingresar un número.\n");
            }
        }

        static void EliminarDelCarrito()
        {
            try
            {
                Console.Write("\nIngrese el código del producto a eliminar: ");
                int codigo = int.Parse(Console.ReadLine());

                if (carrito.EliminarItem(codigo))
                {
                    Console.WriteLine("\nProducto eliminado del carrito.\n");
                }
                else
                {
                    Console.WriteLine("\nProducto no encontrado en el carrito.\n");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nEntrada no válida. Debe ingresar un número.\n");
            }
        }
    }
}