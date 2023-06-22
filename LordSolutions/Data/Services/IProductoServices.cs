﻿using LordSolutions.Data.Request;

namespace LordSolutions.Data.Services
{
	public interface IProductoServices
	{
		Task<Result<List<ProductoResponse>>> Consultar(string filtro);
		Task<Result> Crear(ProductoRequest request);
		Task<Result> Eliminar(ProductoRequest request);
		Task<Result> Modificar(ProductoRequest request);
	}
}