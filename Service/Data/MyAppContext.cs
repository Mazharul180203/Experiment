using API.Dto;
using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Data
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options){ }

        public DbSet<ItemDto> Items { get; set; }
        public DbSet<RegisterDto> Register { get; set; }
    }
}
