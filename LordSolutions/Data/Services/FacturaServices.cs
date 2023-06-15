using System.Linq;
using LordSolutions.Data.Context;
using LordSolutions.Data.Entities;
using LordSolutions.Data.Request;
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
	public class FacturaServices
	{
		private readonly ILordSolutionsDbContext dbContext;

		public FacturaServices(ILordSolutionsDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public async Task<Result> Crear(FacturaRequest request)
		{
			try
			{
				var factura = Factura.Crear(request);
				dbContext.Facturas.Add(factura);
				await dbContext.SaveChangesAsync();
				return new Result() { Message = "Ok", Success = true };
			}
			catch (Exception E)
			{
				return new Result { Message = E.Message, Success = false };

			}
		}
		public async Task<Result> Modificar(FacturaRequest request)
		{
			try
			{
				var factura = dbContext.Facturas.FirstOrDefaultAsync(c => c.Id == request.Id);
				if (factura == null)
					return new Result { Message = "No se encontro ninguna factura", Success = false };

				if (factura.Modificar(request))
					await dbContext.SaveChangesAsync();

				return new Result() { Message = "Ok", Success = true };
			}
			catch (Exception E)
			{
				return new Result { Message = E.Message, Success = false };

			}
		}
		public async Task<Result> Eliminar(FacturaRequest request)
		{
			try
			{
				var factura = dbContext.DetallesDeFacturas.FirstOrDefaultAsync(c => c.Id == request.Id);
				if (factura == null)
					return new Result { Message = "No se encontro ninguna factura", Success = false };

				dbContext.Facturas.Remove(factura);
				await dbContext.SaveChangesAsync();
				return new Result() { Message = "Ok", Success = true };
			}
			catch (Exception E)
			{
				return new Result { Message = E.Message, Success = false };

			}
		}
		public async Task<Result<List<FacturaResponse>>> Consultar(string filtro)
		{
			try
			{
				var factura = await dbContext.Facturas.Where(c =>
				(c.Nombre + " " + c.Telefono + " " + c.Direccion).ToLower()
				.Contains(filtro.ToLower))
                    )
                    .Select(c => c.ToResponse())
					.ToListAsync();
				return new Result<List<FacturaResponse>>()
				{
					Message = "Ok",
					Success = true,
					Data = factura
				};
			}
			catch (Exception E)
			{
				return new Result<List<FacturaResponse>>
				{
					Message = E.Message,
					Success = false
				};
			}
		}
	}
}
