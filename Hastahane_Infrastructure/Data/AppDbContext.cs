using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Hastahane_Infrastructure.Data
{
    public class AppDbContext : DbContext;
    {
         public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
}
}
