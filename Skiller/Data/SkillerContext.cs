using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Skiller.Models;

namespace Skiller.Models
{
    public class SkillerContext : DbContext
    {
        public SkillerContext (DbContextOptions<SkillerContext> options)
            : base(options)
        {
        }

        public DbSet<Skiller.Models.Company> Company { get; set; }

        public DbSet<Skiller.Models.Employee> Employee { get; set; }

        public DbSet<Skiller.Models.MadSkill> MadSkill { get; set; }

        public DbSet<Skiller.Models.Project> Project { get; set; }

        public DbSet<Skiller.Models.User> User { get; set; }
    }
}
