using Library.Models;
using Microsoft.EntityFrameworkCore;
using SistemaVentasDavid.Data;
using System.Linq.Expressions;

namespace SistemaVentasDavid.Services;

public class ProveedoresService
{
	private readonly ApplicationDbContext _contexto;

	public ProveedoresService(ApplicationDbContext contexto)
	{
		_contexto = contexto;
	}

	public async Task<bool> Crear(Proveedores proveedor)
	{
		if (!await Existe(proveedor.ProveedorId))
			return await Insertar(proveedor);
		else
			return await Modificar(proveedor);
	}

	public async Task<bool> Insertar(Proveedores proveedor)
	{
		_contexto.Proveedores.Add(proveedor);
		return await _contexto.SaveChangesAsync() > 0;
	}

	public async Task<bool> Modificar(Proveedores proveedor)
	{
		_contexto.Proveedores.Update(proveedor);
		return await _contexto.SaveChangesAsync() > 0;
	}

	public async Task<bool> Existe(int id)
	{
		return await _contexto.Proveedores.AnyAsync(p => p.ProveedorId == id);
	}

	public async Task<bool> Eliminar(int id)
	{
		var eliminar = await _contexto.Proveedores
			.Where(p => p.ProveedorId == id)
			.ExecuteDeleteAsync();

		return eliminar > 0;
	}

	public async Task<Proveedores?> BuscarId(int id)
	{
		return await _contexto.Proveedores
			.Include(d => d.ProveedorDetalle)
			.AsNoTracking()
			.FirstOrDefaultAsync(p => p.ProveedorId == id);
	}

	public async Task<List<Proveedores>> Listar(Expression<Func<Proveedores, bool>> criterio)
	{
		return await _contexto.Proveedores
			.Include(d => d.ProveedorDetalle)
			.AsNoTracking()
			.Where(criterio)
			.ToListAsync();
	}
}
