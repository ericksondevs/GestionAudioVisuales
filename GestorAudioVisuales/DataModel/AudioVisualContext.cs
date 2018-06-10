using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
        public partial class AudioVisualContext : DbContext
        {
            public AudioVisualContext()
                : base("name=Modelo")
            {
            }

            public virtual DbSet<Blog> Blogs { get; set; }
            public virtual DbSet<Post> Posts { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
            }
        }
}
