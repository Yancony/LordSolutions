using System.Linq;
using LordSolutions.Data.Context;
using LordSolutions.Data.Entities;
using LordSolutions.Data.Request;
using LordSolutions.Data.Resquest;
using Microsoft.EntityFrameworkCore;

namespace LordSolutions.Data.Services
{
	public class DetalleDeFactura
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

		private readonly ILordSolutionsDbContext dbContext;

		public DetalleDeFactura(ILordSolutionsDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public async Task<Result> Crear(DetalleDeFacturaRequest request)
		{
			try
			{
				var detalledefactura = DetalleDeFactura.Crear(DetalleDeFacturaRequest);
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
				var detalledefactura = dbContext.DetallesDeFacturas.FirstOrDefaultAsync(c => c.Id == request.Id);
				if (detalledefactura == null)
					return new Result { Message = "No se encontro el Detalle de la Factura", Success = false };

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
				var detalledefactura = dbContext.DetallesDeFacturas.FirstOrDefaultAsync(c => c.Id == request.Id);
				if (detalledefactura == null)
					return new Result { Message = "No se encontro el Detalle de la Factura", Success = false };

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
				var detalledefactura = await dbContext.DetallesDeFacturas.Where(c =>
				(c.Nombre + " " + c.Telefono + " " + c.Direccion).ToLower()
				.Contains(filtro.ToLower))
                    )
                    .Select(c => c.ToResponse())
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
