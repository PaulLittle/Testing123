using Microsoft.EntityFrameworkCore;
using SAC_Web_Application.Models.ClubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAC_Web_Application.Models.ClubModel
{
    public class ClubContext : DbContext
    {
        public ClubContext(DbContextOptions<ClubContext> options)
            : base(options)
        { }
        
        //public DbSet<Members> Members { get; set; }
        
    }
}
