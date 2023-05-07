using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;



namespace Logic
{
    public class LogicStudent
    {
        string connectionString = "Data Source=DESKTOP-6H57L2G;Initial Catalog=CRUD_DAPPER_STUDENT;Integrated Security=True";

       public Estudiante Create(Estudiante estudiante)
        {
            try
            {

                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    Estudiante pEstudiante = new Estudiante()
                    {

                        Nombre = estudiante.Nombre,
                        Direccion = estudiante.Direccion,
                        Fecha_cumpleaños = estudiante.Fecha_cumpleaños
,
                    };

                    string sqlQuery = "INSERT INTO Estudiante (Nombre, Direccion, Fecha_cumpleaños) VALUES(@Nombre, @Direccion,@Fecha_cumpleaños)";

                    int rowsAffected = db.Execute(sqlQuery, pEstudiante);

                    if (rowsAffected == 0)
                    {
                        throw new ArgumentException("error al insertar a la base de datos");

                    }
                    return pEstudiante;
                }

            }
            catch (Exception e)
            {

                throw new ArgumentException("error al insertar a la base de datos");
            }


        }

        public Estudiante Update(Estudiante estudiante, int Id)
        {
            try
            {

                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    Estudiante pEstudiante = new Estudiante()
                    {
                        Nombre = estudiante.Nombre,
                        Direccion = estudiante.Direccion,
                        Fecha_cumpleaños = estudiante.Fecha_cumpleaños
                    
                    };

                    string sqlQuery = $"UPDATE Estudiante Set Nombre=@Nombre,Direccion=@Direccion,Fecha_cumpleaños = @Fecha_cumpleaños where Id={Id}";


                    int rowsAffected = db.Execute(sqlQuery, pEstudiante);

                    if (rowsAffected == 0)
                    {
                        throw new ArgumentException("error al actualizar a la base de datos");

                    }
                    return pEstudiante;
                }

            }
            catch (Exception e)
            {

                throw new ArgumentException("error al actualizar a la base de datos");
            }
        }
        public int Delete(int Id)
        {
            try
            {

                using (IDbConnection db = new SqlConnection(connectionString))
                {

                    string sqlQuery = $"DELETE FROM Estudiante WHERE Id={Id}";


                    int rowsAffected = db.Execute(sqlQuery);

                    if (rowsAffected == 0)
                    {
                        throw new ArgumentException("error al eliminar");

                    }
                    return rowsAffected;
                }

            }
            catch (Exception e)
            {

                throw new ArgumentException("error al eliminar");
            }
        }
        public List<Estudiante> getAll()
        {
            try
            {
                List<Estudiante> list = new List<Estudiante>();
                using (IDbConnection db = new SqlConnection(connectionString))
                {


                    string sqlQuery = "select * from Estudiante";

                    var Estudiantes = db.Query<Estudiante>(sqlQuery);
                    foreach (var item in Estudiantes)
                    {


                        list.Add(item);
                    }
                    return list;
                }

            }
            catch (Exception e)
            {

                throw new ArgumentException("error al consultar datos");
            }
        }

        public Estudiante getId(int Id)
        {

            try
            {

                using (IDbConnection db = new SqlConnection(connectionString))
                {


                    string sqlQuery = $"SELECT * FROM Estudiante where id={Id}";

                    var Estudiantes = db.QuerySingle<Estudiante>(sqlQuery);

                    return Estudiantes;
                }


            }
            catch (Exception e)
            {

                throw new ArgumentException("error al consultar datos");
            }
        }

    }
}

