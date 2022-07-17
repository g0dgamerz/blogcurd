using blog.Interface;
using blog.Models;
using System.Data.SqlClient;

namespace blog.Service
{
    public class BlogService:IBlog
    {
        public string cons { get; set; }
        public IConfiguration _configuration;
        public SqlConnection? con;
        public BlogService(IConfiguration configuration)
        {
            _configuration = configuration;
            cons = _configuration.GetConnectionString("DbConnection");
        }
        public List<Blog> GetBlogs()
        {
            List<Blog> blogList = new List<Blog>();
            try
            {
                using (con=new SqlConnection(cons))
                {
                    con.Open();
                    var cmd = new SqlCommand("blogSelect", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Blog blog = new Blog();
                        blog.ID = Convert.ToInt32(dr["id"]);
                        blog.Title = dr["title"].ToString();
                        blog.Body=dr["body"].ToString();
                        blogList.Add(blog);
                    }
                    con.Close();
                }
                return blogList.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public Blog GetSingleBlog(int id)
        {
            try
            {
                SqlDataReader dr;
                using (SqlConnection con = new SqlConnection(cons))
                {
                    Blog blog = new Blog();
                    var cmd = new SqlCommand("blogSelectbyid", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    dr=cmd.ExecuteReader();
                    dr.Read();
                    blog.ID=Convert.ToInt32(dr["id"]);
                    blog.Title=dr["title"].ToString();
                    blog.Body=dr["body"].ToString();
                    return blog;
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }


        public string InsertBlog(Blog blog)
        {
            string msg = "";
            try
            {
                using (SqlConnection con = new SqlConnection(cons))
                {
                    var cmd = new SqlCommand("blogInsert",con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@title", blog.Title);
                    cmd.Parameters.AddWithValue("@body", blog.Body);
                    con.Open();
                    cmd.ExecuteReader();
                    msg = "Inserted Sucessfully";
                    con.Close();
                }

            }
            catch (Exception)
            {
                throw;
            }
            return msg;
        }


        public string UpdateBlog(Blog blog,int id)
        {
            string msg = "";
            try
            {
                using (SqlConnection con = new SqlConnection(cons))
                {
                    var cmd = new SqlCommand("blogUpdate", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id",id);
                    cmd.Parameters.AddWithValue("@title", blog.Title);
                    cmd.Parameters.AddWithValue("@body", blog.Body);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    msg = "UPdated Sucessfully";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return msg;
        }

        public string DeleteBlog(int id)
        {
            string msg = "";
            try
            {
                using (SqlConnection con = new SqlConnection(cons))
                {
                    var cmd = new SqlCommand("blogDelete",con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    msg = "Sucessfully delted";
                    con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return msg;
        }
    }
}
