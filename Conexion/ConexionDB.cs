using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace MAD.Conexion
{
    class ConexionDB
    {
        static private string _aux { set; get; }
        static private SqlConnection _conexion;
        static private SqlDataAdapter _adaptador = new SqlDataAdapter();
        static private SqlCommand _comandosql = new SqlCommand();
        static private DataTable _tabla = new DataTable();
        static private DataSet _DS = new DataSet();


        //Conecta a la base de datos. El string de conexion esta en App.config
        private static void conectar()
        {

<<<<<<< Updated upstream
=======
            //string cnn = ConfigurationManager.ConnectionStrings["conexionDefaultJosue"].ToString();
            //_conexion = new SqlConnection(cnn);
            //_conexion.Open();

>>>>>>> Stashed changes
            string cnn = ConfigurationManager.ConnectionStrings["conexionDefaultJahir"].ToString();
            _conexion = new SqlConnection(cnn);
            _conexion.Open();

            //var builder = new SqlConnectionStringBuilder();
            //builder.DataSource = @"DESKTOP-QLGQC24";
            //builder.InitialCatalog = "PuntoDeVenta";
            //builder.IntegratedSecurity = true;


            //var connectionString = builder.ToString();

            //using (SqlConnection sql = new SqlConnection(connectionString))
            //{
            //    sql.Open();
            //}

        }

        //Desconecta la conexion a la base de datos
        private static void desconectar()
        {
            _conexion.Close();
        }


        //Funcion para iniciar sesion al usuario
        public string Login(string username, string password) {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_Login", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@usuario", username));
                cmd.Parameters.Add(new SqlParameter("@contra", password));

                //Ejecutamos el comando
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // While de todas las filas
                    while (rdr.Read())
                    {
                        //Si existe, regresamos que tipo de usuario es
                        byte rol = (byte)rdr["rol"];

                        //Regresamos que tipo de usuario es;
                        if (rol == 1)
                        {
                            return "admin";
                        }
                        else if (rol == 2) {
                            return "caja";
                        }
                    }

                }
                return "no existe";
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return "error";
                
            }
            finally {
                desconectar();
            }
        }

        public int EditarCajero(string nombre, string apellido_materno, string apellido_paterno, string curp, string fecha_nacimiento, string num_nomina, string email, string username, string usernameAdmin, string password, string seleccionado) {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_GestionCajeros", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "ED"));
                cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
                cmd.Parameters.Add(new SqlParameter("@apellido_materno", apellido_materno));
                cmd.Parameters.Add(new SqlParameter("@apellido_paterno", apellido_paterno));
                cmd.Parameters.Add(new SqlParameter("@curp", curp));
                cmd.Parameters.Add(new SqlParameter("@fecha_nacimiento", fecha_nacimiento));
                cmd.Parameters.Add(new SqlParameter("@num_nomina", Int32.Parse(num_nomina)));
                cmd.Parameters.Add(new SqlParameter("@email", email));
                cmd.Parameters.Add(new SqlParameter("@id_admin", Convert.ToInt32(GetIdAdmin(usernameAdmin))));
                cmd.Parameters.Add(new SqlParameter("@id_cajero", Convert.ToInt32(GetIdCajero(username))));
                cmd.Parameters.Add(new SqlParameter("@selectedUser", username));
                cmd.Parameters.Add(new SqlParameter("@password", password));
                cmd.Parameters.Add(new SqlParameter("@id_userSelected", Int32.Parse(seleccionado)));

                //Ejecutamos el comando como NonQuery ya que no necesitamos informacion de regreso
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cajero editado correctamente");
                return 1;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return -1;

            }
            finally
            {
                desconectar();
            }

        }

        public int EliminarCajero(string idCajero) {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_GestionCajeros", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@id_userSelected", Int32.Parse(idCajero)));
                cmd.Parameters.Add(new SqlParameter("@operacion", "EL"));

                //Ejecutamos el comando como NonQuery ya que no necesitamos informacion de regreso
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cajero eliminado correctamente");
                return 1;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return -1;

            }
            finally
            {
                desconectar();
            }

        }
        //Funcion para traer todos los cajeros en la base de datos
        public DataTable GetCajeros()
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Mencionamos que procedure vamos a utilizar 
                SqlCommand cmd = new SqlCommand("sp_GestionCajeros", _conexion);

                //Creamos un adaptador, para traer las filas del sql
                SqlDataAdapter adaptador = new SqlDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1200;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "S"));




                //Creamos una tabla nueva
                DataTable tabla = new DataTable();
                //Al adaptador le asignamos que comando vamos a usar
                adaptador.SelectCommand = cmd;
                //Llenamos la tabla y la regresamos
                adaptador.Fill(tabla);
                return tabla;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                DataTable empty = new DataTable();
                return empty;
            }
            finally
            {
                desconectar();
            }

        }

        public int InsertarUsuarioCajero(string username, string password)
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_GestionCajeros", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@username", username));
                cmd.Parameters.Add(new SqlParameter("@password", password));
                cmd.Parameters.Add(new SqlParameter("@operacion", 'I'));

                //Ejecutamos el comando como NonQuery ya que no necesitamos informacion de regreso
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cajero agregado correctamente");
                return 1;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return 0;

            }
            finally
            {
                desconectar();
            }
        }

        public int InsertarDatosCajero(string nombre, string apellido_materno, string apellido_paterno, string curp, string fecha_nacimiento, string num_nomina, string email, string username, string usernameAdmin)
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_GestionCajeros", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "I2"));
                cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
                cmd.Parameters.Add(new SqlParameter("@apellido_materno", apellido_materno));
                cmd.Parameters.Add(new SqlParameter("@apellido_paterno", apellido_paterno));
                cmd.Parameters.Add(new SqlParameter("@curp", curp));
                cmd.Parameters.Add(new SqlParameter("@fecha_nacimiento", fecha_nacimiento));
                cmd.Parameters.Add(new SqlParameter("@num_nomina", num_nomina));
                cmd.Parameters.Add(new SqlParameter("@email", email));
                cmd.Parameters.Add(new SqlParameter("@id_admin", Convert.ToInt32(GetIdAdmin(usernameAdmin))));
                cmd.Parameters.Add(new SqlParameter("@id_cajero", Convert.ToInt32(GetIdCajero(username))));

                //Ejecutamos el comando
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return 0;

            }
            finally
            {
                desconectar();
            }
        }
<<<<<<< Updated upstream
=======

        public List<string> GetCajerosName()
        {
            try
            {
                List<string> cajeros = new List<string>();
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_GestionCajeros", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "SR"));

                //Ejecutamos el comando
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    cajeros.Add("Todos");
                    // While de todas las filas
                    while (rdr.Read())
                    {
                        cajeros.Add((string)rdr["Cajero"]);
                    }

                    return cajeros;
                }

            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                List<string> departamentosNull = new List<string>();
                return departamentosNull;

            }
            finally
            {
                desconectar();
            }

        }
        #endregion
>>>>>>> Stashed changes



        //Aquí empieza Departamentos

        public int InsertarDepartamento(string nombreDepartamento, string claveDepartamento, int devolucion, int estatus,string usernameAdmin) {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_GestionDepartamentos", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "I"));
                if (nombreDepartamento == "")
                    cmd.Parameters.Add(new SqlParameter("@nombreDepartamento", null));
                else
                    cmd.Parameters.Add(new SqlParameter("@nombreDepartamento", nombreDepartamento));
               
                cmd.Parameters.Add(new SqlParameter("@claveDepartamento", claveDepartamento));
                cmd.Parameters.Add(new SqlParameter("@devolucion", devolucion));
                cmd.Parameters.Add(new SqlParameter("@status", estatus));
                cmd.Parameters.Add(new SqlParameter("@id_admin", Convert.ToInt32(GetIdAdmin(usernameAdmin))));
                
                //Ejecutamos el comando
                cmd.ExecuteNonQuery();
                MessageBox.Show("Departamento agregado correctamente");
                return 1;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return 0;

            }
            finally
            {
                desconectar();
            }
        }

        public DataTable GetDepartamentos()
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Mencionamos que procedure vamos a utilizar 
                SqlCommand cmd = new SqlCommand("sp_GestionDepartamentos", _conexion);

                //Creamos un adaptador, para traer las filas del sql
                SqlDataAdapter adaptador = new SqlDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1200;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "S"));




                //Creamos una tabla nueva
                DataTable tabla = new DataTable();
                //Al adaptador le asignamos que comando vamos a usar
                adaptador.SelectCommand = cmd;
                //Llenamos la tabla y la regresamos
                adaptador.Fill(tabla);
                return tabla;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                DataTable empty = new DataTable();
                return empty;
            }
            finally
            {
                desconectar();
            }

        }

        public int EditarDepartamento(string nombreDepartamento, int devolucion, int estatus, string claveDepartamento)
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_GestionDepartamentos", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "U"));
                if (nombreDepartamento == "")
                    cmd.Parameters.Add(new SqlParameter("@nombreDepartamento", null));
                else
                    cmd.Parameters.Add(new SqlParameter("@nombreDepartamento", nombreDepartamento));

                cmd.Parameters.Add(new SqlParameter("@claveDepartamento", claveDepartamento));
                cmd.Parameters.Add(new SqlParameter("@devolucion", devolucion));
                cmd.Parameters.Add(new SqlParameter("@status", estatus));
                //Ejecutamos el comando como NonQuery ya que no necesitamos informacion de regreso
                if (cmd.ExecuteNonQuery() == -1)
                {
                    MessageBox.Show("No se puede asignar inactivo un departamento que tenga productos en venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return 0;
                }
                MessageBox.Show("Departamento editado correctamente");
                return 1;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return -1;

            }
            finally
            {
                desconectar();
            }

        }

        public int EliminarDepartamento(string claveDepartamento)
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_GestionDepartamentos", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "D"));
                cmd.Parameters.Add(new SqlParameter("@claveDepartamento", claveDepartamento));
                cmd.Parameters.Add(new SqlParameter("@status", 0));

                //Ejecutamos el comando como NonQuery ya que no necesitamos informacion de regreso
                if(cmd.ExecuteNonQuery() == -1) {
                    MessageBox.Show("No se puede eliminar un departamento que tenga productos en venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return 0;
                }
                MessageBox.Show("Departamento eliminado correctamente");
                return 1;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return -1;

            }
            finally
            {
                desconectar();
            }

        }

        public List<string> GetDepartamentosName()
        {
            try
            {
                List<string> departamentos = new List<string>();
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_GestionDepartamentos", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "SA"));

                //Ejecutamos el comando
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // While de todas las filas
                    while (rdr.Read())
                    {
                        departamentos.Add((string)rdr["nombre"]);
                    }

                    return departamentos;
                }

            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                List<string> departamentosNull = new List<string>();
                return departamentosNull;

            }
            finally
            {
                desconectar();
            }

        }

        public string GetCveDepart(string nombreDep)
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_GetIds", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "idDp"));
                cmd.Parameters.Add(new SqlParameter("@nombreDepartamento", nombreDep));

                //Ejecutamos el comando
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // While de todas las filas
                    while (rdr.Read())
                    {
                        return (string)rdr["clave_departamento"];
                    }

                }
                return "";
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return "";

            }
            finally
            {
                desconectar();
            }

        }

        public string GetNombreDepart(string cveDep)
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_GestionDepartamentos", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "SN"));
                cmd.Parameters.Add(new SqlParameter("@claveDepartamento", cveDep));

                //Ejecutamos el comando
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // While de todas las filas
                    while (rdr.Read())
                    {
                        return (string)rdr["nombre"];
                    }

                }
                return "";
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return "";

            }
            finally
            {
                desconectar();
            }

        }


        //Aquí termina Departamentos


        //Aquí empieza Productos
        public int InsertarProducto(string nombreProd, string descripcionProd, double costoProd, double preioUProd, decimal existenciaProd, decimal puntoReProd, int estatusProd, string usernameAdmin, string nombreUMed, string nombreDep)
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_GestionProductos", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "I"));
                if (nombreProd == ""|| descripcionProd == "" || nombreUMed == "" || nombreDep == "")
                    return 0;

                cmd.Parameters.Add(new SqlParameter("@nombreProd", nombreProd));
                cmd.Parameters.Add(new SqlParameter("@descripProd", descripcionProd));
                cmd.Parameters.Add(new SqlParameter("@costoProd", costoProd));
                cmd.Parameters.Add(new SqlParameter("@preciounitarioProd", preioUProd   ));
                cmd.Parameters.Add(new SqlParameter("@existencia", existenciaProd));
                
                cmd.Parameters.Add(new SqlParameter("@puntoreordenProd", puntoReProd));
                cmd.Parameters.Add(new SqlParameter("@estatusProd", estatusProd));
                cmd.Parameters.Add(new SqlParameter("@id_unidadMedida", Convert.ToInt32(GetIdUnidadMedida(nombreUMed))));
                cmd.Parameters.Add(new SqlParameter("@cve_departamento", GetCveDepart(nombreDep)));
                cmd.Parameters.Add(new SqlParameter("@id_admin", Convert.ToInt32(GetIdAdmin(usernameAdmin))));

                //Ejecutamos el comando
                cmd.ExecuteNonQuery();
                MessageBox.Show("Producto agregado correctamente");
                return 1;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return 0;

            }
            finally
            {
                desconectar();
            }
        }

        public int EditarProducto(int codProd,string nombreProd, string descripcionProd, double costoProd, double preioUProd, decimal existenciaProd, decimal puntoReProd, int estatusProd, string nombreUMed, string nombreDep)
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_GestionProductos", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "U"));
                if (nombreProd == "" || descripcionProd == "" || nombreUMed == "" || nombreDep == "")
                    return 0;


                cmd.Parameters.Add(new SqlParameter("@codProd", codProd));
                cmd.Parameters.Add(new SqlParameter("@nombreProd", nombreProd));
                cmd.Parameters.Add(new SqlParameter("@descripProd", descripcionProd));
                cmd.Parameters.Add(new SqlParameter("@costoProd", costoProd));
                cmd.Parameters.Add(new SqlParameter("@preciounitarioProd", preioUProd));
                cmd.Parameters.Add(new SqlParameter("@existencia", existenciaProd));

                cmd.Parameters.Add(new SqlParameter("@puntoreordenProd", puntoReProd));
                cmd.Parameters.Add(new SqlParameter("@estatusProd", estatusProd));
                cmd.Parameters.Add(new SqlParameter("@id_unidadMedida", Convert.ToInt32(GetIdUnidadMedida(nombreUMed))));
                cmd.Parameters.Add(new SqlParameter("@cve_departamento", GetCveDepart(nombreDep)));

                //Ejecutamos el comando
                if(cmd.ExecuteNonQuery() == -1){
                    MessageBox.Show("No se puede activar un producto ya que el departamento al que pertenece esta inactivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return 0;
                }
                MessageBox.Show("Producto editado correctamente");
                return 1;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return 0;

            }
            finally
            {
                desconectar();
            }
        }

        public int EliminarProducto(int codProd)
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_GestionProductos", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "D"));
                cmd.Parameters.Add(new SqlParameter("@codProd", codProd));

                //Ejecutamos el comando como NonQuery ya que no necesitamos informacion de regreso
                cmd.ExecuteNonQuery();
                MessageBox.Show("Producto eliminado correctamente");
                return 1;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return -1;

            }
            finally
            {
                desconectar();
            }

        }

        public DataTable GetProductos()
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Mencionamos que procedure vamos a utilizar 
                SqlCommand cmd = new SqlCommand("sp_GestionProductos", _conexion);

                //Creamos un adaptador, para traer las filas del sql
                SqlDataAdapter adaptador = new SqlDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1200;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "S"));




                //Creamos una tabla nueva
                DataTable tabla = new DataTable();
                //Al adaptador le asignamos que comando vamos a usar
                adaptador.SelectCommand = cmd;
                //Llenamos la tabla y la regresamos
                adaptador.Fill(tabla);
                return tabla;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                DataTable empty = new DataTable();
                return empty;
            }
            finally
            {
                desconectar();
            }

        }

        public DataTable GetDatosProductos(int codProd)
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Mencionamos que procedure vamos a utilizar 
                SqlCommand cmd = new SqlCommand("sp_GestionProductos", _conexion);

                //Creamos un adaptador, para traer las filas del sql
                SqlDataAdapter adaptador = new SqlDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1200;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "SA"));
                cmd.Parameters.Add(new SqlParameter("@codProd", codProd));

                //Creamos una tabla nueva
                DataTable tabla = new DataTable();
                //Al adaptador le asignamos que comando vamos a usar
                adaptador.SelectCommand = cmd;
                //Llenamos la tabla y la regresamos
                adaptador.Fill(tabla);
                return tabla;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                DataTable empty = new DataTable();
                return empty;
            }
            finally
            {
                desconectar();
            }

        }

<<<<<<< Updated upstream
        //Aquí termina Productos
=======
        public DataTable GetProductosCaja()
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Mencionamos que procedure vamos a utilizar 
                SqlCommand cmd = new SqlCommand("sp_GestionProductos", _conexion);

                //Creamos un adaptador, para traer las filas del sql
                SqlDataAdapter adaptador = new SqlDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1200;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "BP"));




                //Creamos una tabla nueva
                DataTable tabla = new DataTable();
                //Al adaptador le asignamos que comando vamos a usar
                adaptador.SelectCommand = cmd;
                //Llenamos la tabla y la regresamos
                adaptador.Fill(tabla);
                return tabla;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                DataTable empty = new DataTable();
                return empty;
            }
            finally
            {
                desconectar();
            }

        }

        public Forms.ProductoVenta BuscarProducto(int codigo, decimal cantidad)
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_GestionProductos", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "PC"));
                cmd.Parameters.Add(new SqlParameter("@codProd", codigo));
                cmd.Parameters.Add(new SqlParameter("@existencia", cantidad));

                //Ejecutamos el comando
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // While de todas las filas
                    while (rdr.Read())
                    {
                        Forms.ProductoVenta producto = new Forms.ProductoVenta((int)rdr["cod_producto"], (string)rdr["nombre"], (decimal)rdr["precio_unitario"], cantidad);
                        return producto;
                    }

                }
                return null;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return null;
            }
            finally
            {
                desconectar();
            }

        }

        //Descuentos
        public int AñadirDescuento(string fechaInicial, string fechaFinal, int codProd, int cantidad, int estatus)
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_GestionProductos", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "AD"));
               

                cmd.Parameters.Add(new SqlParameter("@DFechaI", fechaInicial));
                cmd.Parameters.Add(new SqlParameter("@DFechaF", fechaFinal));
                cmd.Parameters.Add(new SqlParameter("@DCantidad", cantidad));
                cmd.Parameters.Add(new SqlParameter("@codProd", codProd));
                cmd.Parameters.Add(new SqlParameter("@DEstatus", estatus));

                //Ejecutamos el comando
                if (cmd.ExecuteNonQuery() != -1)
                {
                    MessageBox.Show("Descuento agregado correctamente");
                    return 1;
                }
                MessageBox.Show("No se puede agregar más de un descuento durante las mismas fechas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                
                return 0;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return 0;

            }
            finally
            {
                desconectar();
            }
        }



        //Aquí termina Productos
        #endregion

        #region Recibos y Notas
        //Funciones del recibo
        public int CrearRecibo(List<Forms.ProductoVenta> Carrito, List<Forms.Pagos> Pagos ,decimal descuento, decimal subtotal, decimal total, string cajero, int caja)
        {

            //En esta funcion vamos a crear todo lo relacionado con los recibos
            try
            {
                //Primero generamos el recibo con los datos que necesita
                GenerarRecibo(descuento, subtotal, total, caja, GetIdCajero(cajero));

                //Despues conseguimos el numero del recibo que acabamos de crear
                decimal numRecibo = IdUltimoRecibo();


                //Por cada producto en el carrito, lo vamos a asociar con sus datos necesarios al recibo que creamos
                foreach (var producto in Carrito) {
                    ProductoVendido(producto, (int)numRecibo);
                }

                foreach (var pago in Pagos)
                {
                    AsignarPagos(pago, (int)numRecibo);
                }

                //Fin, si llego aqui todo se genero correctamente
                GenerarTicketPDF((int)numRecibo, Carrito, Pagos);
                return (int)numRecibo;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return -1;

            }
            finally
            {
                desconectar();
            }
        }

        private int ProductoVendido(Forms.ProductoVenta producto, int recibo) {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_GestionRecibos", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "ID"));
                cmd.Parameters.Add(new SqlParameter("@precioProducto", producto.Precio));
                cmd.Parameters.Add(new SqlParameter("@cantidadProducto", producto.Cantidad));
                cmd.Parameters.Add(new SqlParameter("@codProducto", producto.Codigo));
                cmd.Parameters.Add(new SqlParameter("@numRecibo", recibo));  

                //Ejecutamos el comando
                cmd.ExecuteNonQuery();
                return -1;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return -1;

            }
            finally
            {
                desconectar();
            }


        }

        private int GenerarRecibo(decimal descuento, decimal subtotal, decimal total, int caja, int cajero) {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_GestionRecibos", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "I"));
                cmd.Parameters.Add(new SqlParameter("@descuento", (object)descuento));
                cmd.Parameters.Add(new SqlParameter("@subtotal", (object)subtotal));
                cmd.Parameters.Add(new SqlParameter("@idCaja", (object)caja));
                cmd.Parameters.Add(new SqlParameter("@idCajero", (object)cajero));
                cmd.Parameters.Add(new SqlParameter("@total", (object)total));

                //Ejecutamos el comando
                cmd.ExecuteNonQuery();
                return -1;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return -1;

            }
            finally
            {
                desconectar();
            }
        }

        private decimal IdUltimoRecibo()
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_GestionRecibos", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "ID"));

                //Ejecutamos el comando
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // While de todas las filas
                    while (rdr.Read())
                    {
                        return (decimal)rdr["UltimoId"];
                    }

                }
                return -1;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return -1;

            }
            finally
            {
                desconectar();
            }
        }


        private int AsignarPagos(Forms.Pagos pagos, int recibo)
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_GestionRecibos", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "RP"));
                cmd.Parameters.Add(new SqlParameter("@metodoPago", pagos.Metodo));
                cmd.Parameters.Add(new SqlParameter("@cantidadPago", pagos.CantidadPagada));
                cmd.Parameters.Add(new SqlParameter("@numRecibo", recibo));

                //Ejecutamos el comando
                cmd.ExecuteNonQuery();
                return -1;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return -1;

            }
            finally
            {
                desconectar();
            }


        }

>>>>>>> Stashed changes


<<<<<<< Updated upstream
=======
        //Notas de credito
        public int CrearNotaCredito(List<Forms.ProductoNotaCredito> CarritoNota, string admin, int numRecibo)
        {

            //En esta funcion vamos a crear todo lo relacionado con los recibos
            try
            {
                decimal total = 0;
                foreach (var producto in CarritoNota)
                {
                    total += producto.Total;
                }
                //Primero generamos la nota con los datos que necesita
                GenerarNotaCredito(total, GetIdAdmin(admin), numRecibo);

                //Despues conseguimos el numero de la nota que acabamos de crear
                decimal numNotaCredito = IdUltimaNotaCredito();


                //Por cada producto en el carrito, lo vamos a asociar con sus datos necesarios a la nota que creamos
                foreach (var producto in CarritoNota)
                {
                    ProductoRegresado(producto, (int)numNotaCredito);
                    if(producto.Merma > 0)
                    {
                        ProductoRegresadoExistencias(producto, producto.IdProucto, producto.Cantidad-producto.Merma);
                        ProductoRegresadoMerma(producto, producto.IdProucto);
                    }
                    else
                        ProductoRegresadoExistencias(producto, producto.IdProucto, producto.Cantidad);
                }

                //Fin, si llego aqui todo se genero correctamente
                //GenerarTicketPDF((int)numRecibo, Carrito, Pagos);
                return (int)numNotaCredito;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return -1;

            }
            finally
            {
                desconectar();
            }
        }

        private int ProductoRegresado(Forms.ProductoNotaCredito producto, int notaCredito)
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_Devoluciones", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "IDe"));
                cmd.Parameters.Add(new SqlParameter("@id_prod", producto.IdProucto));
                cmd.Parameters.Add(new SqlParameter("@idNota", notaCredito));
                cmd.Parameters.Add(new SqlParameter("@totalProd", producto.Total));
                cmd.Parameters.Add(new SqlParameter("@cantidadProd", producto.Cantidad));

                //Ejecutamos el comando
                cmd.ExecuteNonQuery();
                return -1;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return -1;

            }
            finally
            {
                desconectar();
            }


        }

        private int ProductoRegresadoExistencias(Forms.ProductoNotaCredito producto, int prodcomprado, decimal cantidad)
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_Devoluciones", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "IPN"));
                cmd.Parameters.Add(new SqlParameter("@cantidadProd", cantidad));
                cmd.Parameters.Add(new SqlParameter("@id_prod", prodcomprado));
                //Ejecutamos el comando
                cmd.ExecuteNonQuery();
                return -1;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return -1;

            }
            finally
            {
                desconectar();
            }


        }

        private int ProductoRegresadoMerma(Forms.ProductoNotaCredito producto, int prodcomprado)
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_Devoluciones", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "IPM"));
                cmd.Parameters.Add(new SqlParameter("@cantidadProd", producto.Merma));
                cmd.Parameters.Add(new SqlParameter("@id_prod", prodcomprado));
                //Ejecutamos el comando
                cmd.ExecuteNonQuery();
                return -1;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return -1;

            }
            finally
            {
                desconectar();
            }


        }

        private decimal IdUltimaNotaCredito()
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_Devoluciones", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "IdD"));

                //Ejecutamos el comando
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // While de todas las filas
                    while (rdr.Read())
                    {
                        return (decimal)rdr["UltimoId"];
                    }

                }
                return -1;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return -1;

            }
            finally
            {
                desconectar();
            }
        }

        private int GenerarNotaCredito(decimal total, int admin, int numRecibo)
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_Devoluciones", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "INo"));
                cmd.Parameters.Add(new SqlParameter("@id_admin", (object)admin));
                cmd.Parameters.Add(new SqlParameter("@totalNota", (object)total));
                cmd.Parameters.Add(new SqlParameter("@numRecibo", (object)numRecibo));

                //Ejecutamos el comando
                cmd.ExecuteNonQuery();
                return -1;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return -1;

            }
            finally
            {
                desconectar();
            }
        }

        #endregion
>>>>>>> Stashed changes

        //Aquí empieza Cajas

        public string GetNumCaja()
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_GestionCajas", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "SN"));

                //Ejecutamos el comando
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // While de todas las filas
                    while (rdr.Read())
                    {
                        decimal result = (decimal)rdr["UltimoId"];
                        if (result != 1)
                            result++;
                        return result.ToString();
                    }

                }
                return "";
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return "";

            }
            finally
            {
                desconectar();
            }

        }

        public int InsertarCaja(string usernameAdmin, int activo)
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_GestionCajas", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "I"));
                cmd.Parameters.Add(new SqlParameter("@estatusCaja", activo));
                cmd.Parameters.Add(new SqlParameter("@id_admin", Convert.ToInt32(GetIdAdmin(usernameAdmin))));

                //Ejecutamos el comando
                cmd.ExecuteNonQuery();
                MessageBox.Show("Caja agregada correctamente");
                return 1;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return 0;

            }
            finally
            {
                desconectar();
            }
        }

        public int EditarCaja(int numCaja, int activo)
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_GestionCajas", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "U"));
                cmd.Parameters.Add(new SqlParameter("@estatusCaja", activo));
                cmd.Parameters.Add(new SqlParameter("@num_caja", numCaja));

                //Ejecutamos el comando
                cmd.ExecuteNonQuery();
                MessageBox.Show("Caja editada correctamente");
                return 1;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return 0;

            }
            finally
            {
                desconectar();
            }
        }

        public int EliminarCaja(int numCaja)
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_GestionCajas", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "D"));
                cmd.Parameters.Add(new SqlParameter("@num_caja", numCaja));

                //Ejecutamos el comando
                cmd.ExecuteNonQuery();
                MessageBox.Show("Caja eliminada correctamente");
                return 1;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return 0;

            }
            finally
            {
                desconectar();
            }
        }

        public DataTable GetCajas()
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Mencionamos que procedure vamos a utilizar 
                SqlCommand cmd = new SqlCommand("sp_GestionCajas", _conexion);

                //Creamos un adaptador, para traer las filas del sql
                SqlDataAdapter adaptador = new SqlDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1200;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "S"));

                //Creamos una tabla nueva
                DataTable tabla = new DataTable();
                //Al adaptador le asignamos que comando vamos a usar
                adaptador.SelectCommand = cmd;
                //Llenamos la tabla y la regresamos
                adaptador.Fill(tabla);
                return tabla;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                DataTable empty = new DataTable();
                return empty;
            }
            finally
            {
                desconectar();
            }

        }

        //Aquí termina Cajas




        public DataTable GetReporteCajeros(string cajero, string depar, string fechaI, string fechaF)
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Mencionamos que procedure vamos a utilizar 
                SqlCommand cmd = new SqlCommand("sp_Reportes", _conexion);

                //Creamos un adaptador, para traer las filas del sql
                SqlDataAdapter adaptador = new SqlDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1200;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "RC"));
                cmd.Parameters.Add(new SqlParameter("@cajero", cajero));
                cmd.Parameters.Add(new SqlParameter("@departamento", depar));
                cmd.Parameters.Add(new SqlParameter("@fechaI", fechaI));
                cmd.Parameters.Add(new SqlParameter("@fechaF", fechaF));



                //Creamos una tabla nueva
                DataTable tabla = new DataTable();
                //Al adaptador le asignamos que comando vamos a usar
                adaptador.SelectCommand = cmd;
                //Llenamos la tabla y la regresamos
                adaptador.Fill(tabla);

                if (tabla.Rows.Count > 0)
                {
                    decimal ventaTot = 0; decimal utilidadTot = 0; decimal cantTot = 0;
                    foreach (DataRow row in tabla.Rows)
                    {
                        cantTot = cantTot + Convert.ToDecimal(row["Cantidad"]);
                        ventaTot = ventaTot + Convert.ToDecimal(row["Venta"]);
                        utilidadTot = utilidadTot + Convert.ToDecimal(row["Utilidad"]);
                    }
                    tabla.Rows.Add(null, null, null, cantTot, ventaTot, utilidadTot);
                }
                return tabla;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                DataTable empty = new DataTable();
                return empty;
            }
            finally
            {
                desconectar();
            }

        }


        //obtener IDS
        public byte GetIdCajero(string username)
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_GestionCajeros", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@username", username));
                cmd.Parameters.Add(new SqlParameter("@operacion", "CI"));

                //Ejecutamos el comando
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // While de todas las filas
                    while (rdr.Read())
                    {
                        byte id = (byte)rdr["id_cajero"];
                        return id;
                    }

                }
                return 0;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return 0;

            }
            finally
            {
                desconectar();
            }

        }

        public byte GetIdAdmin(string username)
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_IdAdmin", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@usuario", username));

                //Ejecutamos el comando
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // While de todas las filas
                    while (rdr.Read())
                    {
                        byte id = (byte)rdr["id_admin"];
                        return id;
                    }

                }
                return 0;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return 0;

            }
            finally
            {
                desconectar();
            }

        }

        public int GetIdUnidadMedida(string nombreUnidad)
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_GetIds", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@nombreUnidadMedida", nombreUnidad));
                cmd.Parameters.Add(new SqlParameter("@operacion", "idUn"));
                //Ejecutamos el comando
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // While de todas las filas
                    while (rdr.Read())
                    {  
                        return (byte)rdr["id_unidadMedida"];
                    }

                }
                return 0;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return 0;

            }
            finally
            {
                desconectar();
            }

        }
<<<<<<< Updated upstream
=======

        public int GetIdMetodoDePago(string metodo) {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_GestionCajas", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@metodo", metodo));
                cmd.Parameters.Add(new SqlParameter("@operacion", "BM"));
                //Ejecutamos el comando
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // While de todas las filas
                    while (rdr.Read())
                    {
                        return (byte)rdr["id_metodo"];
                    }

                }
                return 0;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return 0;

            }
            finally
            {
                desconectar();
            }
        }



        public List<string> GetMetodosDePagoName()
        {
            try
            {
                List<string> departamentos = new List<string>();
                //Nos conectamos a la base de datos
                conectar();

                //Creamos un comando que identifica la procedure que vamos a utilizar
                SqlCommand cmd = new SqlCommand("sp_GestionCajas", _conexion);

                //Declaramos que vamos a utilizar una procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "MP"));

                //Ejecutamos el comando
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // While de todas las filas
                    while (rdr.Read())
                    {
                        departamentos.Add((string)rdr["metodo"]);
                    }

                    return departamentos;
                }

            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                List<string> departamentosNull = new List<string>();
                return departamentosNull;

            }
            finally
            {
                desconectar();
            }

        }


        #endregion

        #region Inventario
        public DataTable GetProductosInventario()
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Mencionamos que procedure vamos a utilizar 
                SqlCommand cmd = new SqlCommand("sp_GestionProductos", _conexion);

                //Creamos un adaptador, para traer las filas del sql
                SqlDataAdapter adaptador = new SqlDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1200;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "SI"));




                //Creamos una tabla nueva
                DataTable tabla = new DataTable();
                //Al adaptador le asignamos que comando vamos a usar
                adaptador.SelectCommand = cmd;
                //Llenamos la tabla y la regresamos
                adaptador.Fill(tabla);
                return tabla;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                DataTable empty = new DataTable();
                return empty;
            }
            finally
            {
                desconectar();
            }

        }

        public DataTable GetProductosInventarioFiltros(string departamento, int existencias, int agotados, int merma)
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Mencionamos que procedure vamos a utilizar 
                SqlCommand cmd = new SqlCommand("sp_GestionProductos", _conexion);

                //Creamos un adaptador, para traer las filas del sql
                SqlDataAdapter adaptador = new SqlDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1200;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "SI"));
                if(departamento != "")
                    cmd.Parameters.Add(new SqlParameter("@FIDepartamento", departamento));
                cmd.Parameters.Add(new SqlParameter("@FIExistencia", existencias));
                cmd.Parameters.Add(new SqlParameter("@FIAgotados", agotados));
                cmd.Parameters.Add(new SqlParameter("@FIMerma", merma));



                //Creamos una tabla nueva
                DataTable tabla = new DataTable();
                //Al adaptador le asignamos que comando vamos a usar
                adaptador.SelectCommand = cmd;
                //Llenamos la tabla y la regresamos
                adaptador.Fill(tabla);
                return tabla;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                DataTable empty = new DataTable();
                return empty;
            }
            finally
            {
                desconectar();
            }

        }

        #endregion

        #region Devolucion
        public DataTable GetProductosRecibo(int recibo)
        {
            try
            {
                //Nos conectamos a la base de datos
                conectar();

                //Mencionamos que procedure vamos a utilizar 
                SqlCommand cmd = new SqlCommand("sp_Devoluciones", _conexion);

                //Creamos un adaptador, para traer las filas del sql
                SqlDataAdapter adaptador = new SqlDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1200;

                //Añadimos los parametros 
                cmd.Parameters.Add(new SqlParameter("@operacion", "SP"));
                cmd.Parameters.Add(new SqlParameter("@numRecibo", recibo));

                //Creamos una tabla nueva
                DataTable tabla = new DataTable();
                //Al adaptador le asignamos que comando vamos a usar
                adaptador.SelectCommand = cmd;
                //Llenamos la tabla y la regresamos
                adaptador.Fill(tabla);
                return tabla;
            }
            catch (SqlException e)
            {
                string error = "Excepcion en la base de datos: " + e.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                DataTable empty = new DataTable();
                return empty;
            }
            finally
            {
                desconectar();
            }

        }

        

        #endregion

>>>>>>> Stashed changes
    }



}

