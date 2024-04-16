using Library.Models;
using Microsoft.EntityFrameworkCore;
using SistemaVentasDavid.Data;
using System.Linq.Expressions;

namespace SistemaVentasDavid.Services;

public class TiposContribuyenteService
{
	private readonly ApplicationDbContext _contexto;

	public TiposContribuyenteService(ApplicationDbContext contexto)
	{
		_contexto = contexto;
	}

	public async Task<List<TiposContribuyente>> Listar(Expression<Func<TiposContribuyente, bool>> criterio)
	{
		return await _contexto.TiposContribuyente
			.AsNoTracking()
			.Where(criterio)
			.ToListAsync();
	}
}
