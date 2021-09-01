using EcommerceGrid.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceGrid.Data
{
    public class ApllicationDbContext: DbContext
    {
        public ApllicationDbContext(DbContextOptions<ApllicationDbContext> options) : base(options)
        {

        }

        public DbSet<ProductName>ProductName { get; set; }
    }
}
