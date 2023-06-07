using LordSolutions.Data.Context;
using LordSolutions.Data.Entities;
using LordSolutions.Data.Request;
using LordSolutions.Data.Resquest;
using Microsoft.EntityFrameworkCore;

namespace LordSolutions.Data.Services
{
	public class Result
	{
		public bool Success { get; set; }
		public string? Message { get; set; }

	}
	public class Result<T>
	{
		public bool Success { get; set; }
		public string? Message { get; set; }
		public T? Data { get; set; }

	}
	public class ProveedorServices
	{
		private readonly ILordSolutionsDbContext dbContext;

		public ProveedorServices(ILordSolutionsDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
	}
	public async Task<Result> Crear(ProveedorRequest request)
	{
		try
		{
			var proveedor = Proveedor.Crear(ProveedorRequest);
			dbContext.Proveedor.Add(proveedor);
			await dbContext.SaveChangesAsync();
			return new Result() { Message = "Ok", Success = true };
		}
		catch (Exception E)
		{
			return new Result { Message = E.Message, Success = false };

		}
	}
	public async Task<Result> Modificar(ProveedorRequest request)
	{
		try
		{
			var proveedor = dbContext.Proveedor.FirstOrDefaultAsync(c => c.Id == request.Id);
			if (proveedor == null)
				return new Result { Message = "No se encontro el proveedor", Success = false };

			if (proveedor.Modificar(request))
				await dbContext.SaveChangesAsync();

			return new Result() { Message = "Ok", Success = true };
		}
		catch (Exception E)
		{
			return new Result { Message = E.Message, Success = false };

		}
	}
	public async Task<Result> Eliminar(ProveedorRequest request)
	{
		try
		{
			var proveedor = dbContext.Proveedor.FirstOrDefaultAsync(c => c.Id == request.Id);
			if (proveedor == null)
				return new Result { Message = "No se encontro el proveedor", Success = false };

			dbContext.Proveedor.Remove(proveedor);
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
			var proveedor = await dbContext.Proveedor.Where(c =>
			(c.Nombre + " " + c.Telefono + " " + c.Direccion).ToLower()
			.Contains(filtro.ToLower))
                    )
                    .Select(c => c.ToResponse())
					.ToListAsync();
			return new Result<List<ClienteResponse>>()
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
