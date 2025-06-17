﻿using Carrito_De_Compras;
using System;

namespace Carrito_De_Compras
{
    public class Categoria
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Categoria(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public override string ToString()
        {
            return $"{Nombre}: {Descripcion}";
        }
    }
}

