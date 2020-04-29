using System;
using Microsoft.EntityFrameworkCore;

namespace RateYourDerp.Models
{
    public class DerpDb : DbContext
    {
        public DerpDb(DbContextOptions<DerpDb> options) : base(options)
        {
        }

        public DbSet<Derp> Derps {get;set;}

    }
}