using _15_CRUDPersonasBinding_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using _15_CRUDPersonasBinding_DAL.Conexion;
using System.Net.Http;
using Newtonsoft.Json;

namespace _15_CRUDPersonasBinding_DAL.Listados
{
    public class clsListadoPersonas_DAL
    {
        /// <summary>
        /// funcion que devuelve un List de objetos clsPersona, Lista vacia si no hay datos en la base de datos o no se han podido acceder a ellos
        /// </summary>
        /// <returns>List de clsPersona</returns>
        public async Task<List<clsPersona>> listadoCompletoPersonas_DAL()
        {
            List<clsPersona> lista = new List<clsPersona>();

            HttpClient client = new HttpClient();
            clsUriBase uriBase = new clsUriBase();
            String uri = uriBase.getUriBase()+"personas";
            Uri miUri = new Uri(uri);
            clsPersona persona = new clsPersona();

            String jsonText;

            HttpResponseMessage respuesta = await client.GetAsync(miUri);

            jsonText = await respuesta.Content.ReadAsStringAsync();

            lista = JsonConvert.DeserializeObject<List<clsPersona>>(jsonText);


            return lista;
        }


        /*public List<clsPersona> listadoCompletoPersonas_DAL()
        {
            List<clsPersona> lista = new List<clsPersona>();
            SqlConnection miConexion = null;
            SqlDataReader miLector = null;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestoraConexion = new clsMyConnection();
            clsPersona persona;

            try //try no obligatorio porque lo controlamos en la clase myConnection
            {
                //Obtener conexion abierta
                miConexion = gestoraConexion.getConnection();

                //Definir los parametros del comando
                miComando.CommandText = "SELECT IDPersona, nombrePersona, apellidosPersona, fechaNacimiento, telefono, direccion, IDDepartamento FROM Personas";

                //Definir la conexion
                miComando.Connection = miConexion;

                //Ejecutar la consulta
                miLector = miComando.ExecuteReader();

                //Comprobar si el lector tiene filas, y en caso afirmativo, recorrerlo
                if (miLector.HasRows)
                {
                    while(miLector.Read())
                    {
                        persona = new clsPersona();
                        //Definir los atributos del objeto
                        persona.idPersona = (int)miLector["IDPersona"];
                        persona.nombre = (string)miLector["nombrePersona"];
                        persona.apellidos = (string)miLector["apellidosPersona"];
                        persona.fechaNacimiento = (DateTime)miLector["fechaNacimiento"];
                        persona.telefono = (string)miLector["telefono"];
                        persona.direccion = (string)miLector["direccion"];
                        persona.idDepartamento = (int)miLector["IDDepartamento"];

                        //Añadir objeto a la lista
                        lista.Add(persona);
                    }
                }

            }
            catch(SqlException e)
            {
                throw e;
            }
            finally
            {

                gestoraConexion.closeConnection(ref miConexion);

                miLector.Close();
            }

            return lista;
        }*/


        /// <summary>
        /// funcion que devuelve un List de objetos clsPersona, Lista vacia si no hay datos en la base de datos o no se han podido acceder a ellos
        /// </summary>
        /// <returns>List de clsPersona</returns>
        public List<clsPersona> listadoPersonasBusquedaNombreApellidos_DAL(String parametro)
        {
            List<clsPersona> lista = new List<clsPersona>();
            SqlConnection miConexion = null;
            SqlDataReader miLector = null;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestoraConexion = new clsMyConnection();
            clsPersona persona;

        //https://www.dotnetperls.com/split
            String[] parametros = parametro.Split(' '); //TODO implementar en el comando de busqueda los parametros segun el numero de parametros mandados (insertar cada parametro y buscarlo en nombre o apellido)

            try //try no obligatorio porque lo controlamos en la clase myConnection
            {
                //Obtener conexion abierta
                miConexion = gestoraConexion.getConnection();

                //Definir los parametros del comando
                miComando.CommandText = "SELECT IDPersona, nombrePersona, apellidosPersona, fechaNacimiento, telefono, direccion, IDDepartamento FROM Personas";

                //Definir la conexion
                miComando.Connection = miConexion;

                //Ejecutar la consulta
                miLector = miComando.ExecuteReader();

                //Comprobar si el lector tiene filas, y en caso afirmativo, recorrerlo
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        persona = new clsPersona();
                        //Definir los atributos del objeto
                        persona.idPersona = (int)miLector["IDPersona"];
                        persona.nombre = (string)miLector["nombrePersona"];
                        persona.apellidos = (string)miLector["apellidosPersona"];
                        persona.fechaNacimiento = (DateTime)miLector["fechaNacimiento"];
                        persona.telefono = (string)miLector["telefono"];
                        persona.direccion = (string)miLector["direccion"];
                        persona.idDepartamento = (int)miLector["IDDepartamento"];

                        //Añadir objeto a la lista
                        lista.Add(persona);
                    }
                }

            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {

                gestoraConexion.closeConnection(ref miConexion);

                miLector.Close();
            }

            return lista;
        }
    }
}
