using LordSolutions.Data.Context;
using LordSolutions.Data.Entities;
using LordSolutions.Data.Request;
using LordSolutions.Data.Resquest;
using Microsoft.EntityFrameworkCore;

namespace LordSolutions.Data.Services
{
	public class ProveedorServices
	{
		private readonly ILordSolutionsDbContext dbContext;

		public ProveedorServices(ILordSolutionsDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public async Task<Result> Crear(ProveedorRequest request)
		{
			try
			{
				var proveedor = Proveedor.Crear(request);
				dbContext.Proveedores.Add(proveedor);
				await dbContext.SaveChangesAsync();
				return new Result() { Message = "Ok", Success = true };
			}
			catch (Exception E)
			{
				return new Result() { Message = E.Message, Success = false };

			}
		}
		public async Task<Result> Modificar(ProveedorRequest request)
		{
			try
			{
				var proveedor = await dbContext.Proveedores.FirstOrDefaultAsync(p => p.Id == request.Id);
				if (proveedor == null)
					return new Result() { Message = "No se encontro el proveedor", Success = false };

				if (proveedor.Modificar(request))
					await dbContext.SaveChangesAsync();

				return new Result() { Message = "Ok", Success = true };
			}
			catch (Exception E)
			{
				return new Result() { Message = E.Message, Success = false };

			}
		}
		public async Task<Result> Eliminar(ProveedorRequest request)
		{
			try
			{
				var proveedor = await dbContext.Proveedores.FirstOrDefaultAsync(p => p.Id == request.Id);
				if (proveedor == null)
					return new Result() { Message = "No se encontro el proveedor", Success = false };

				dbContext.Proveedores.Remove(proveedor);
				await dbContext.SaveChangesAsync();
				return new Result() { Message = "Ok", Success = true };
			}
			catch (Exception E)
			{
				return new Result { Message = E.Message, Success = false };

			}
		}
		public async Task<Result<List<ProveedorResponse>>> Consultar(string filtro)
		{
			try
			{
				var proveedor = await dbContext.Proveedores.Where(p =>
				(p.Nombre + " " + p.Telefono + " " + p.CorreoElectronico).ToLower()
				.Contains(filtro.ToLower())
						)
						.Select(p => p.ToResponse())
						.ToListAsync();
				return new Result<List<ProveedorResponse>>()
				{
					Message = "Ok",
					Success = true,
					Data = proveedor
				};
			}
			catch (Exception E)
			{
				return new Result<List<ProveedorResponse>>
				{
					Message = E.Message,
					Success = false
				};
			}
		}
	}
	
}
