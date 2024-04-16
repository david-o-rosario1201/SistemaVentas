using Library.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SistemaVentasDavid.Data
{
	public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
	{
		public DbSet<TiposContribuyente> TiposContribuyente { get;  set; }
		public DbSet<Numeros> Contactos { get;  set; }
		public DbSet<Proveedores> Proveedores { get;  set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<TiposContribuyente>().HasData(new List<TiposContribuyente>
			{
				new TiposContribuyente { TipoContribuyenteId = 1, TipoContribuyente = "Persona Fisica"},
				new TiposContribuyente { TipoContribuyenteId = 2, TipoContribuyente = "Persona Juridica"}
			});

			modelBuilder.Entity<Numeros>().HasData(new List<Numeros>
			{
				new Numeros { NumeroId = 1, Numero = "Teléfono"},
				new Numeros { NumeroId = 2, Numero = "Fax"}
			});
		}
	}	
}
