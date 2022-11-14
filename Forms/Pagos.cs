using MAD.Conexion;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAD.Forms
{
    class Pagos
    {
        decimal cantidadPagada;
        string nombreMetodo;
        int metodo;

        public Pagos(decimal cantidadPagada, string nombreMetodo) {
            this.cantidadPagada = cantidadPagada;
            this.nombreMetodo = nombreMetodo;

            
            var db = new ConexionDB();
            this.metodo = db.GetIdMetodoDePago(nombreMetodo);
        }

        public decimal CantidadPagada {
            get { return cantidadPagada; }
            set { cantidadPagada = value; }

        }

        public int Metodo {
            get { return metodo; }
            set { metodo = value; }
        }

        public string NombreMetodo {
            get { return nombreMetodo; }
            set { nombreMetodo = value; }
        }


    }
}
