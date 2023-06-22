using System.Linq;
using LordSolutions.Data.Context;
using LordSolutions.Data.Entities;
using LordSolutions.Data.Request;
using LordSolutions.Data.Resquest;
using Microsoft.EntityFrameworkCore;

namespace LordSolutions.Data.Services
{
	public class ProductoServices : IProductoServices
	{
		private readonly ILordSolutionsDbContext dbContext;

		public ProductoServices(ILordSolutionsDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public async Task<Result> Crear(ProductoRequest request)
		{
			try
			{
				var producto = Producto.Crear(request);
				dbContext.Productos.Add(producto);
				await dbContext.SaveChangesAsync();
				return new Result() { Message = "Ok", Success = true };
			}
			catch (Exception E)
			{
				return new Result { Message = E.Message, Success = false };

			}
		}
		public async Task<Result> Modificar(ProductoRequest request)
		{
			try
			{
				var producto = await dbContext.Productos.FirstOrDefaultAsync(p => p.Id == request.Id);
				if (producto == null)
					return new Result { Message = "No se encontro el producto", Success = false };

				if (producto.Modificar(request))
					await dbContext.SaveChangesAsync();

				return new Result() { Message = "Ok", Success = true };
			}
			catch (Exception E)
			{
				return new Result { Message = E.Message, Success = false };

			}
		}
		public async Task<Result> Eliminar(ProductoRequest request)
		{
			try
			{
				var producto = await dbContext.Productos.FirstOrDefaultAsync(p => p.IdProveedor == request.IdProveedor);
				if (producto == null)
					return new Result { Message = "No se encontro el producto", Success = false };

				dbContext.Productos.Remove(producto);
				await dbContext.SaveChangesAsync();
				return new Result() { Message = "Ok", Success = true };
			}
			catch (Exception E)
			{
				return new Result { Message = E.Message, Success = false };

			}
		}
		public async Task<Result<List<ProductoResponse>>> Consultar(string filtro)
		{
			try
			{
				var productos = await dbContext.Productos.Where(p =>
				(p.Nombre + " " + p.Precio + " " + p.Cantidad).ToLower()
				.Contains(filtro.ToLower())
					)
					.Select(p => p.ToResponse())
					.ToListAsync();
				return new Result<List<ProductoResponse>>()
				{
					Message = "Ok",
					Success = true,
					Data = productos
				};
			}
			catch (Exception E)
			{
				return new Result<List<ProductoResponse>>
				{
					Message = E.Message,
					Success = false
				};
			}
		}
	}
}
