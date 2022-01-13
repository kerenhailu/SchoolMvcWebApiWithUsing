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
                    cmd.ExecuteReader();
                    if (dataFromDB.HasRows)
                    {
                        while (dataFromDB.Read())
                        {
                            Teachers.Add((new Teacher(dataFromDB.GetInt32(0), dataFromDB.GetString(1), dataFromDB.GetString(2), dataFromDB.GetInt32(3), dataFromDB.GetDateTime(4))));
                        }
                        return Ok(new { Teachers });
                    }
                    conn.Close();
                    return Ok(new { Teachers });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //catch (SqlException ex)
            //{
            //    return ex.Message;
            //}
        }

        // GET: api/Teacher/5
        public IHttpActionResult Get(int id)
        {
            return Ok();

        }

        // POST: api/Teacher
        public IHttpActionResult Post([FromBody] Teacher teacher)
        {
            return Ok();
        }

        // PUT: api/Teacher/5
        public IHttpActionResult Put(int id, [FromBody] Teacher teacher)
        {
            return Ok();
        }

        // DELETE: api/Teacher/5
        public IHttpActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
