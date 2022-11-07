using System;
using System.Collections.Generic;
using System.Text;

namespace MAD.Forms
{
    class ProductoVenta
    {
        private string nombre;
        private decimal precio;
        private int cantidad;

        public ProductoVenta(string nombre, decimal precio, int cantidad) {
            this.nombre = nombre;
            this.precio = precio;
            this.cantidad = cantidad;
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public decimal Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
    }
}
