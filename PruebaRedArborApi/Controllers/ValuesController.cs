using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PruebaRedArborApi.Models;
using System.Diagnostics;

namespace PruebaRedArborApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration config;
        public ValuesController(IConfiguration configuracion)
        {
            config = configuracion;
            
        }
        

        private List<DataViewModel> ListDB()
        {
            try
            {
                List<DataViewModel> list = new List<DataViewModel>();
                using (SqlConnection conexion = new SqlConnection(config.GetConnectionString("DefaultConnection")))
                {
                    //<Procedimiento almacenado
                    SqlCommand command = new SqlCommand("SP_Empleado", conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    //>

                    //<Action
                    command.Parameters.Add("@Action", SqlDbType.Int).Value = 0;
                    //>

                    conexion.Open();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        DataViewModel obj = new DataViewModel();
                        obj.Id_Empleado = Convert.ToInt32(row["Id_Empleado"]);
                        obj.Nombre = row["Nombre"].ToString();
                        obj.Usuario = row["Usuario"].ToString();
                        obj.Contraseña = row["Contraseña"].ToString();
                        obj.Telefono = row["Telefono"].ToString();
                        obj.Email = row["Email"].ToString();
                        obj.Ultimo_Login = row["Ultimo_Login"].ToString();
                        obj.Fecha_Creacion = row["Fecha_Creacion"].ToString();
                        obj.Fecha_Actualiza = row["Fecha_Actualiza"].ToString();
                        obj.Fecha_Elimina = row["Fecha_Elimina"].ToString();
                        obj.Id_Rol = Convert.ToInt32(row["Id_Rol"]);
                        obj.Id_Estado = Convert.ToInt32(row["Id_Estado"]);

                        list.Add(obj);
                    }
                    return list;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/values
        [HttpGet]
        public List<DataViewModel> Get()
        {
            return ListDB();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public List<DataViewModel> Get(int id)
        {
            return ListDB().Where(e => e.Id_Empleado == id).ToList();
        }

        // POST api/values
        [HttpPost]
        public string Post(DataViewModel obj)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(config.GetConnectionString("DefaultConnection")))
                {
                    conexion.Open();

                    //<Procedimiento almacenado
                    SqlCommand command = new SqlCommand("SP_Empleado", conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    //<Parametros
                    command.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = obj.Nombre;
                    command.Parameters.Add("@Usuario", SqlDbType.NVarChar, 50).Value = obj.Usuario;
                    command.Parameters.Add("@Contraseña", SqlDbType.NVarChar, 100).Value = obj.Contraseña;
                    command.Parameters.Add("@Telefono", SqlDbType.NVarChar, 50).Value = obj.Telefono;
                    command.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = obj.Email;
                    command.Parameters.Add("@Id_Rol", SqlDbType.Int).Value = Convert.ToInt32(obj.Id_Rol);
                    command.Parameters.Add("@Id_Estado", SqlDbType.Int).Value = Convert.ToInt32(obj.Id_Estado);
                    //>

                    //<Action
                    command.Parameters.Add("@Action", SqlDbType.Int).Value = 1;
                    //>


                    command.ExecuteNonQuery();
                    conexion.Close();

                    return "¡Registro exitoso!";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public string Put(DataViewModel obj, int id)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(config.GetConnectionString("DefaultConnection")))
                {
                    conexion.Open();

                    //<Procedimiento almacenado
                    SqlCommand command = new SqlCommand("SP_Empleado", conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    //<Parametros
                    command.Parameters.Add("@Id_Empleado", SqlDbType.Int).Value = Convert.ToInt32(id);
                    command.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = obj.Nombre;
                    command.Parameters.Add("@Usuario", SqlDbType.NVarChar, 50).Value = obj.Usuario;
                    command.Parameters.Add("@Contraseña", SqlDbType.NVarChar, 100).Value = obj.Contraseña;
                    command.Parameters.Add("@Telefono", SqlDbType.NVarChar, 50).Value = obj.Telefono;
                    command.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = obj.Email;
                    command.Parameters.Add("@Id_Rol", SqlDbType.Int).Value = Convert.ToInt32(obj.Id_Rol);
                    command.Parameters.Add("@Id_Estado", SqlDbType.Int).Value = Convert.ToInt32(obj.Id_Estado);
                    //>

                    //<Action
                    command.Parameters.Add("@Action", SqlDbType.Int).Value = 2;
                    //>


                    command.ExecuteNonQuery();
                    conexion.Close();

                    return "¡Actualización de registros exitosa!";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(DataViewModel obj, int id)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(config.GetConnectionString("DefaultConnection")))
                {
                    conexion.Open();

                    //<Procedimiento almacenado
                    SqlCommand command = new SqlCommand("SP_Empleado", conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    //<Parametros
                    command.Parameters.Add("@Id_Empleado", SqlDbType.Int).Value = Convert.ToInt32(id);
                    //>

                    //<Action
                    command.Parameters.Add("@Action", SqlDbType.Int).Value = 3;
                    //>


                    command.ExecuteNonQuery();
                    conexion.Close();

                    return "¡Registro fue eliminado con exito!";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
