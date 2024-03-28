using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MznQuestion
{
	public class DataOperation
	{
		private readonly ProductsDbContext context;

		public DataOperation(ProductsDbContext context)
		{
			this.context = context;
		}

		public void ExportDataToJson(string FilePath)
		{
			var Products = context.ProductInformations.ToList();
			string json = JsonSerializer.Serialize(Products);
			File.WriteAllText(FilePath, json);
			Console.WriteLine("The File was Exported successfully");
		}

		public void ImportDataFromJson(string FilePath)
		{
			string json = File.ReadAllText(FilePath);
			List<ProductInformation> products = JsonSerializer.Deserialize<List<ProductInformation>>(json);

				foreach (var product in products)
				{
					context.ProductInformations.Add(product);
				}

				try
				{
					context.SaveChanges();
				 Console.WriteLine("The File was imported successfully");
				 }
				catch (Exception ex)
				{
					 Console.WriteLine(" Error Type: " +ex.GetType());
				}
		}


	}
}
