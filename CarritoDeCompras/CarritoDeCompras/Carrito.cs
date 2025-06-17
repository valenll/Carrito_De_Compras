using System;
using System.Collections.Generic;
using System.Linq;

namespace Carrito_De_Compras
{
    public class Carrito
    {
        public List<ItemCarrito> Items { get; } = new List<ItemCarrito>();

        public void AgregarItem(Producto producto, int cantidad)
        {
            var itemExistente = Items.FirstOrDefault(i => i.Producto.Codigo == producto.Codigo);

            if (itemExistente != null)
            {
                itemExistente.Cantidad += cantidad;
            }
            else
            {
                Items.Add(new ItemCarrito(producto, cantidad));
            }
        }

        public bool EliminarItem(int codigoProducto)
        {
            var item = Items.FirstOrDefault(i => i.Producto.Codigo == codigoProducto);
            if (item != null)
            {
                Items.Remove(item);
                return true;
            }
            return false;
        }

        public decimal CalcularSubtotal()
        {
            return Items.Sum(item => item.Subtotal());
        }

        public decimal CalcularIVA()
        {
            return CalcularSubtotal() * 0.21m;
        }

        public decimal CalcularTotal()
        {
            return CalcularSubtotal() + CalcularIVA();
        }

        public void MostrarContenido()
        {
            if (Items.Count == 0)
            {
                Console.WriteLine("El carrito está vacío.");
                return;
            }

            Console.WriteLine("\nContenido del carrito:");
            foreach (var item in Items)
            {
                Console.WriteLine($"- {item}");
            }
            Console.WriteLine($"Subtotal: ${CalcularSubtotal()}");
            Console.WriteLine($"IVA (21%): ${CalcularIVA()}");
            Console.WriteLine($"Total a pagar: ${CalcularTotal()}\n");
        }

        public void FinalizarCompra()
        {
            foreach (var item in Items)
            {
                item.Producto.Stock -= item.Cantidad;
            }
            Items.Clear();
            Console.WriteLine("\nCompra finalizada con éxito. Stock actualizado.\n");
        }
    }
}