using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Security.Cryptography;

namespace project1
{
    public class DB:DbContext
    {
        public DB() : base("store")
        {
        }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Mobile> mobiles { get; set; }
        public DbSet<Tools> tools { get; set; }
        public DbSet<Cart> carts { get; set; }
    }
}
