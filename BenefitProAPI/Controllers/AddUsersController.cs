//using BenefitProAPI.Models;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Data;
//using System.Data.SqlClient;
//using Microsoft.Extensions.Configuration;

//namespace BenefitProAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AddUsersController : ControllerBase
//    {
//        private readonly IConfiguration _configuration;
//        public AddUsersController(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }
//         [HttpGet]
//        public IActionResult GetUsers()
//        {
//            try
//            {
//                List<AddUsersModel> userList = new List<AddUsersModel>();
//                string connectionString = _configuration.GetConnectionString("DefaultConnection");
//                using (SqlConnection con = new SqlConnection(connectionString))
//                {
//                    string query = "SELECT Username, Password, FirstName, LastName, Role, DirectoryType, NoOfUsers FROM addusers";

//                    using (SqlCommand cmd = new SqlCommand(query, con))
//                    {
//                        con.Open();
//                        using (SqlDataReader reader = cmd.ExecuteReader())
//                        {
//                            while (reader.Read())
//                            {
//                                AddUsersModel user = new AddUsersModel
//                                {
//                                    Username = reader["Username"].ToString(),
//                                    Password = reader["Password"].ToString(),
//                                    FirstName = reader["FirstName"].ToString(),
//                                    LastName = reader["LastName"].ToString(),
//                                    Role = reader["Role"].ToString(),
//                                    DirectoryType = reader["DirectoryType"].ToString(),
//                                    NoOfUsers = reader["NoOfUsers"].ToString();
//                                };
//                                userList.Add(user);
//                            }
//                        }
//                    }
//                }

//        [HttpPost]
//            public IActionResult AddUser(AddUsersModel obj)
//        {
//            try
//            {
              

//                string connectionString = _configuration.GetConnectionString("DefaultConnection");
//                using (SqlConnection con = new SqlConnection(connectionString))
//                {
//                    string query = "INSERT INTO addusers (Username, Password, FirstName, LastName, Role, DirectoryType, NoOfUsers) " +
//                                   "VALUES (@Username, @Password, @FirstName, @LastName, @Role, @DirectoryType, @NoOfUsers)";

//                    using (SqlCommand cmd = new SqlCommand(query, con))
//                    {
//                        cmd.Parameters.AddWithValue("@Username", obj.Username);
//                        cmd.Parameters.AddWithValue("@Password", obj.Password);
//                        cmd.Parameters.AddWithValue("@FirstName", obj.FirstName);
//                        cmd.Parameters.AddWithValue("@LastName", obj.LastName);
//                        cmd.Parameters.AddWithValue("@Role", obj.Role);
//                        cmd.Parameters.AddWithValue("@DirectoryType", obj.DirectoryType);
//                        cmd.Parameters.AddWithValue("@NoOfUsers", obj.NoOfUsers);
//                        con.Open();
//                        cmd.ExecuteNonQuery();
//                    }
//                }

            
//                return Ok("Form data received successfully!");
//            }
//            catch (Exception e)
//            {

//                return BadRequest(e+"An error occurred while processing the request. Please try again later.");
//            }
//        }
//    }
//    } }
using BenefitProAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BenefitProAPI.Controllers
{
    
    [ApiController]
    public class AddUsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AddUsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/AddUsers
        [Route("GetUsers")]
        [HttpGet]
        public IActionResult GetUsers()
        {
            try
            {
                List<AddUsersModel> userList = new List<AddUsersModel>();
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT Username, Password, FirstName, LastName, Role, DirectoryType, NoOfUsers FROM addusers";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AddUsersModel user = new AddUsersModel
                                {
                                    Username = reader["Username"].ToString(),
                                    Password = reader["Password"].ToString(),
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    Role = reader["Role"].ToString(),
                                    DirectoryType = reader["DirectoryType"].ToString(),
                                    NoOfUsers = reader["NoOfUsers"].ToString()
                                };
                                userList.Add(user);
                            }
                        }
                    }
                }

               
                return Ok(userList);
            }
            catch (Exception e)
            {
                return BadRequest("An error occurred while processing the request. Please try again later.");
            }
        }

       [Route("AddUser")]
        [HttpPost]
        public IActionResult AddUser(AddUsersModel obj)
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO addusers (Username, Password, FirstName, LastName, Role, DirectoryType, NoOfUsers) " +
                                   "VALUES (@Username, @Password, @FirstName, @LastName, @Role, @DirectoryType, @NoOfUsers)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", obj.Username);
                        cmd.Parameters.AddWithValue("@Password", obj.Password);
                        cmd.Parameters.AddWithValue("@FirstName", obj.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", obj.LastName);
                        cmd.Parameters.AddWithValue("@Role", obj.Role);
                        cmd.Parameters.AddWithValue("@DirectoryType", obj.DirectoryType);
                        cmd.Parameters.AddWithValue("@NoOfUsers", obj.NoOfUsers);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                return Ok("Form data received successfully!");
            }
            catch (Exception e)
            {
                return BadRequest("An error occurred while processing the request. Please try again later.");
            }
        }
    }
}

