using System;
using System.Collections.Generic;
using System.Text;

namespace MAD.Forms
{
    class ProductoNotaCredito
    {

        private int id_producto;
        private decimal total;
        private decimal cantidad;
        private decimal precio;
        private decimal merma;
        private string motivo;

        public ProductoNotaCredito(int id_producto, decimal cantidad, decimal precio, decimal merma, string motivo)
        {
            this.id_producto = id_producto;
            this.total = cantidad * precio;
            this.cantidad = cantidad;
            this.precio = precio;
            this.merma = merma;
            this.motivo = motivo;
        }

        public int IdProucto
        {
            get { return id_producto; }
            set { id_producto = value; }
        }

        public decimal Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        public decimal Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public decimal Merma
        {
            get { return merma; }
            set { merma = value; }
        }

        public decimal Total
        {
            get { return total; }
            set { total = value; }
        }

        public string Motivo
        {
            get { return motivo; }
            set { motivo = value; }
        }
    }
}
