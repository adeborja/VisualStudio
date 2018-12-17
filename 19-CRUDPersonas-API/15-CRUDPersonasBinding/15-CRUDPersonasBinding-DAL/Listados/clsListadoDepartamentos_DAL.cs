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
    public class clsListadoDepartamentos_DAL
    {
        public async Task<List<clsDepartamento>> listadoCompletoDepartamentos_DAL()
        {
            List<clsDepartamento> lista = new List<clsDepartamento>();

            HttpClient client = new HttpClient();
            clsUriBase uriBase = new clsUriBase();
            String uri = uriBase.getUriBase() + "personas";
            Uri miUri = new Uri(uri);
            clsPersona persona = new clsPersona();

            String jsonText;

            HttpResponseMessage respuesta = await client.GetAsync(miUri);

            jsonText = await respuesta.Content.ReadAsStringAsync();

            lista = JsonConvert.DeserializeObject<List<clsDepartamento>>(jsonText);


            return lista;
        }

        /*public List<clsDepartamento> listadoCompletoDepartamentos_DAL()
        {
            List<clsDepartamento> lista = new List<clsDepartamento>();

            SqlConnection miConexion = null;
            SqlDataReader miLector = null;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestoraConexion = new clsMyConnection();
            clsDepartamento departamento = null;

            try
            {
                //Obtener conexion abierta
                miConexion = gestoraConexion.getConnection();

                //Definir los parametros del comando
                miComando.CommandText = "SELECT IDDepartamento, nombreDepartamento FROM Departamentos";

                //Definir la conexion
                miComando.Connection = miConexion;

                //Ejecutar la consulta
                miLector = miComando.ExecuteReader();

                //Comprobar si el lector tiene filas, y en caso afirmativo, recorrerlo
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        departamento = new clsDepartamento();
                        //Definir los atributos del objeto
                        departamento.idDepartamento = (int)miLector["IDDepartamento"];
                        departamento.nombreDepartamento = (string)miLector["nombreDepartamento"];
                        //Añadir objeto a la lista
                        lista.Add(departamento);
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
        }*/
    }
}
