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
        public int InsertarProducto(string nombreProd, string descripcionProd, double costoProd, double preioUProd, int existenciaProd, int puntoReProd, int estatusProd, string usernameAdmin, string nombreUMed, string nombreDep)
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

        public int EditarProducto(int codProd,string nombreProd, string descripcionProd, double costoProd, double preioUProd, int existenciaProd, int puntoReProd, int estatusProd, string nombreUMed, string nombreDep)
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

        //Aquí termina Productos



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
    }



}

