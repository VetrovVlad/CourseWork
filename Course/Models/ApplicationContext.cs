namespace Course.Models
{
    using System.Data.Entity;

    
    internal class ApplicationContext : DbContext
    {
        
        public DbSet<User> Users { get; set; }

        
        public ApplicationContext() : base("DefaultConnection")
        {
        }

       
        public void deleteAll()
        {
            foreach (User user in Users)
            {
                Users.Remove(user);
            }
        }
    }
}
