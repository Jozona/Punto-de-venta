using System;
using System.Collections.Generic;
using System.Text;

namespace MAD.Forms
{
    class ProductoVenta
    {
        private int codigo;
        private string nombre;
        private decimal precio;
        private decimal cantidad;
        private decimal descuento;
        private decimal total;
        

        public ProductoVenta(int codigo, string nombre, decimal precio, decimal cantidad) {
            this.codigo = codigo;
            this.nombre = nombre;
            this.precio = precio;
            this.cantidad = cantidad;
            this.total = cantidad * precio;

            //El descuento esta por hacerse pero aqui se deberia de calcular...

        }

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
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
        public decimal Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public decimal Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }

        public decimal Total
        {
            get { return total; }
            set { total = value; }
        }

    }
}
