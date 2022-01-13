using SchoolMvcWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolMvcWebApi.Controllers.API
{
    public class TeacherController : ApiController
    {
        string stringCollection = @"Data Source=laptop-0hsc4h8o;Initial Catalog=School;Integrated Security=True;Pooling=False";
        List<Teacher> Teachers = new List<Teacher>();

        // GET: api/Teacher
        public IHttpActionResult Get()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(stringCollection))
                {
                    conn.Open();
                    string query = @"SELECT * FROM Teacher";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader dataFromDB = cmd.ExecuteReader();
                    if (dataFromDB.HasRows)
                    {
                        while (dataFromDB.Read())
                        {
                            Teachers.Add((new Teacher(dataFromDB.GetInt32(0), dataFromDB.GetString(1), dataFromDB.GetString(2), dataFromDB.GetInt32(3), dataFromDB.GetDateTime(4))));
                        }
                        conn.Close();
                        return Ok(new { Teachers });
                    }
                    return Ok(new { Teachers });
                }
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        // GET: api/Teacher/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(stringCollection))
                {
                    conn.Open();
                    string query = $@"SELECT * FROM Teacher WHERE Teacher.id={id}";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader dataFromDB = cmd.ExecuteReader();
                    if (dataFromDB.HasRows)
                    {
                        while (dataFromDB.Read())
                        {
                            Teacher teacherID = new Teacher(dataFromDB.GetInt32(0), dataFromDB.GetString(1), dataFromDB.GetString(2), dataFromDB.GetInt32(3), dataFromDB.GetDateTime(4));

                            conn.Close();
                            return Ok(new { teacherID });
                        }
                    }
                    return Ok(new { Teachers });
                }
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // POST: api/Teacher
        public IHttpActionResult Post([FromBody] Teacher teacher)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(stringCollection))
                {
                    connection.Open();
                    string query = $@"INSERT INTO Teacher(name,lName,wage,birthday)
                       VALUES('{teacher.Name}','{teacher.LName}',{teacher.wage},'{teacher.Birthday}')";
                    SqlCommand command = new SqlCommand(query, connection);
                    int rowsEffected = command.ExecuteNonQuery();
                    connection.Close();
                    return Ok(rowsEffected);
                }
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Teacher/5
        public IHttpActionResult Put(int id, [FromBody] Teacher teacher)
        {
            using (SqlConnection connection = new SqlConnection(stringCollection))
            {
                connection.Open();
                string query = $@"UPDATE Teacher 
                                SET firstName = '{teacher.Name}', lastName='{teacher.LName}', wage={teacher.wage}, birthday='{teacher.Birthday}'
            WHERE Teacher.id={id}";
                SqlCommand command = new SqlCommand(query, connection);
                //int rowsEffected = command.ExecuteNonQuery();
                connection.Close();
                return Ok("putttttttttt");
            }
        }

        // DELETE: api/Teacher/5
        public IHttpActionResult Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringCollection))
            {
                connection.Open();
                string query = $@"DELETE FROM Teacher
                                    WHERE Id = {id}";
                SqlCommand command = new SqlCommand(query, connection);
                int rowEffected = command.ExecuteNonQuery();
                connection.Close();
                return Ok(rowEffected);
                //return Ok("you delete");
            }
        }
    }
}
