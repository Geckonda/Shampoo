using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shampoo.Domain.Entity;

namespace shampoo.DAL
{
	public class ApplicationDBContext : DbContext
	{
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) 
			: base(options) { }
		public DbSet<Character> Character { get; set; }

	}
}
