using blog.Models;

namespace blog.Interface
{
    public interface IBlog
    {
        public List<Blog> GetBlogs();
        public Blog GetSingleBlog(int id);
        public string InsertBlog(Blog blog);
        public string UpdateBlog(Blog blog, int id);
        public string DeleteBlog(int id);
    }
}
