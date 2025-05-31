using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Dto;
using Microsoft.EntityFrameworkCore;

namespace Data.DBContexts
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options){ }

        public DbSet<ItemDto> Items { get; set; }
        public DbSet<RegisterDto> Register { get; set; }
    }
}
