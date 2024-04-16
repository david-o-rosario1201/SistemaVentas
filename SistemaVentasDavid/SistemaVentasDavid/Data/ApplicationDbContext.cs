using Library.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SistemaVentasDavid.Data
{
	public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
	{
		public DbSet<TiposContribuyente> TiposContribuyente { get;  set; }
		public DbSet<Contactos> Contactos { get;  set; }
	}
}
