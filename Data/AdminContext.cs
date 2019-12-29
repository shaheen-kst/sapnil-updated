using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Sapnil.Data
{
    public class AdminContext : IdentityDbContext<IdentityUser>
    {
        public AdminContext(DbContextOptions<AdminContext> options) : base(options)
        {

        }
        
    }
}