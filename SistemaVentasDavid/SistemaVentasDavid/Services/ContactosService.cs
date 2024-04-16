using Library.Models;
using Microsoft.EntityFrameworkCore;
using SistemaVentasDavid.Data;
using System.Linq.Expressions;

namespace SistemaVentasDavid.Services;

public class ContactosService
{
	private readonly ApplicationDbContext _contexto;

	public ContactosService(ApplicationDbContext contexto)
	{
		_contexto = contexto;
	}

	public async Task<List<Contactos>> Listar(Expression<Func<Contactos, bool>> criterio)
	{
		return await _contexto.Contactos
			.AsNoTracking()
			.Where(criterio)
			.ToListAsync();
	}
}
