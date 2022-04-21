using Core.Entities;
//using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
	public class CleaningContext : DbContext
	{
		public CleaningContext(DbContextOptions<CleaningContext> options): base(options)
		{
			Database.Migrate();
		}

		public DbSet<CleaningObject> CleaningObjects { get; set; }
		public DbSet<Order> Orders { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
