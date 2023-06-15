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
	public class DetalleDeFacturaServices
	{
		private readonly ILordSolutionsDbContext dbContext;

		public DetalleDeFacturaServices(ILordSolutionsDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<Result> Crear(DetalleDeFacturaRequest request)
		{
			try
			{
				var detalledefactura = DetalleDeFactura.Crear(request);
				dbContext.DetallesDeFacturas.Add(detalledefactura);
				await dbContext.SaveChangesAsync();
				return new Result() { Message = "Ok", Success = true };
			}
			catch (Exception E)
			{
				return new Result { Message = E.Message, Success = false };

			}
		}
		public async Task<Result> Modificar(DetalleDeFacturaRequest request)
		{
			try
			{
				var detalledefactura = dbContext.DetallesDeFacturas.FirstOrDefaultAsync(d => d.Id == request.Id);
				if (detalledefactura == null)
					return new Result { Message = "No se encontro ningún detalle de factura", Success = false };

				if (detalledefactura.Modificar(request))
					await dbContext.SaveChangesAsync();

				return new Result() { Message = "Ok", Success = true };
			}
			catch (Exception E)
			{
				return new Result { Message = E.Message, Success = false };

			}
		}
		public async Task<Result> Eliminar(DetalleDeFacturaRequest request)
		{
			try
			{
				var detalledefactura = dbContext.DetallesDeFacturas.FirstOrDefaultAsync(d => d.Id == request.Id);
				if (detalledefactura == null)
					return new Result { Message = "No se encontro ninguna factura", Success = false };

				dbContext.DetallesDeFacturas.Remove(detalledefactura);
				await dbContext.SaveChangesAsync();
				return new Result() { Message = "Ok", Success = true };
			}
			catch (Exception E)
			{
				return new Result { Message = E.Message, Success = false };

			}
		}
		public async Task<Result<List<DetalleDeFacturaResponse>>> Consultar(string filtro)
		{
			try
			{
				var detalledefactura = await dbContext.DetallesDeFacturas.Where(d =>
				(d.Nombre + " " + d.Telefono + " " + d.Direccion).ToLower()
				.Contains(filtro.ToLower())
                    )
                    .Select(d => d.ToResponse())
					.ToListAsync();
				return new Result<List<DetalleDeFacturaResponse>>()
				{
					Message = "Ok",
					Success = true,
					Data = detalledefactura
				};
			}
			catch (Exception E)
			{
				return new Result<List<DetalleDeFacturaResponse>>
				{
					Message = E.Message,
					Success = false
				};
			}
		}
	}
}
