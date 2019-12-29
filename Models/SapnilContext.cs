using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sapnil.Models
{
    public class  SapnilContext : DbContext
    {
        public SapnilContext(DbContextOptions<SapnilContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set;}
        public DbSet<Product> Products { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}