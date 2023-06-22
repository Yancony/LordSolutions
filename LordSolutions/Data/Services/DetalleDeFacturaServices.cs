using System.Diagnostics.Contracts;
using LordSolutions.Data.Context;
using LordSolutions.Data.Entities;
using LordSolutions.Data.Request;
using LordSolutions.Data.Resquest;
using Microsoft.EntityFrameworkCore;

namespace LordSolutions.Data.Services
{
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
				var detalle = DetalleDeFacturas.Crear(request);
				dbContext.DetallesDeFacturas.Add(detalle);
				await dbContext.SaveChangesAsync();
				return new Result() { Message = "Ok", Success = true };
			}
			catch (Exception E)
			{

				return new Result() { Message = E.Message, Success = false };
			}
		}
		public async Task<Result> Modificar(DetalleDeFacturaRequest request)
		{
			try
			{
				var detalle = await dbContext.DetallesDeFacturas.FirstOrDefaultAsync(d => d.Id == request.Id);
				if (detalle == null)
					return new Result() { Message = "No se encontro el detalle de la factura", Success = false };

				if (detalle.Modificar(request))
					await dbContext.SaveChangesAsync();

				return new Result() { Message = "Ok", Success = true };
			}
			catch (Exception E)
			{
				return new Result() { Message = E.Message, Success = false };

			}
		}
		public async Task<Result> Eliminar(DetalleDeFacturaRequest request)
		{
			try
			{
				var	detalle	 = await dbContext.DetallesDeFacturas.FirstOrDefaultAsync(d => d.Id == request.Id);
				if (detalle == null)
					return new Result() { Message = "No se encontro el detalle de la factura", Success = false };

				dbContext.DetallesDeFacturas.Remove(detalle);
				await dbContext.SaveChangesAsync();
				return new Result() { Message = "Ok", Success = true };
			}
			catch (Exception E)
			{
				return new Result() { Message = E.Message, Success = false };

			}
		}
		public async Task<Result<List<DetalleDeFacturaResponse>>> Consultar(string filtro)
		{
			try
			{
				var detalle = await dbContext.DetallesDeFacturas.Where(d =>
				(d.IdProducto + " " + d.IdFactura + " " + d.Cantidad " " + d.Precio).ToLower()
				.Contains(filtro.ToLower()))
					.Select(d => d.ToResponse())
					.ToListAsync();
				return new Result<List<DetalleDeFacturaResponse>>()
				{
					Message = "Ok",
					Success = true,
					Data = detalle
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
