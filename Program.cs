using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MznQuestion
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var context = new ProductsDbContext();
			var DataOperation=new DataOperation(context);
			string input;
			while(true)
			{

                Console.WriteLine("1-import json file to database");
                Console.WriteLine("2-Export json file From database");
                Console.WriteLine("3-Stop App");
                Console.WriteLine("4-Clear History");
                int x = int.Parse(Console.ReadLine());
				switch(x)
				{
					case 1: Console.WriteLine("Write The File Path: Example: D:\\\\FileName.json "); input = Console.ReadLine(); DataOperation.ImportDataFromJson(input); break;
					case 2: Console.WriteLine("Write The File Path: Example: D:\\\\FileName.json "); input = Console.ReadLine(); DataOperation.ExportDataToJson(input); break;
					case 3:break;
					case 4:Console.Clear();break;
				}
				if (x == 3)
				{
					break;
				}
				
			}  
			
		}
	}
	
}
