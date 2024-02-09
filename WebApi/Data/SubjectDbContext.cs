using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class SubjectDbContext : DbContext
    {
        public SubjectDbContext (DbContextOptions<SubjectDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebApi.Models.Subject> Subject { get; set; } = default!;
    }
}
