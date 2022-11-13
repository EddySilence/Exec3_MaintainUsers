using Ispan.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exec3_MaintainUsers
{
	internal class Program
	{
		static void Main(string[] args)
		{

			CRUD.Insert("Eddy", "asdqwe", "123456", new DateTime(1999, 11, 18), 173);
			CRUD.Insert("Amy", "qwerty", "123456", new DateTime(2000, 3, 9), 165);
			CRUD.Insert("Alen", "qwerty123", "123456", new DateTime(2000, 3, 9), 165);

			CRUD.Delete(3);

			CRUD.Update(1, "Eddy", "asdqwe", "666666", new DateTime(1999, 11, 18), 173);

			CRUD.Select(1);

		}
		public static class CRUD
		{
			public static void Insert(string name, string account, string password, DateTime dateOfBirth, int height)
			{
				string sql = @"INSERT INTO Users(Name,Account,Password,DateOfBirth,Height)
						   VALUES(@Name,@Account,@Password,@DateOfBirth,@Height)";
				var dbHelper = new SqlDbHelper("default");

				try
				{
					var parameters = new SqlParameterBuilder()
								  .AddNVarchar("Name", 50, name)
								  .AddNVarchar("Account", 50000, account)
								  .AddNVarchar("Password", 50, password)
								  .AddDateTime("DateOfBirth", dateOfBirth)
								  .AddInt("Height", height)
								  .Build();

					dbHelper.ExecuteNonQuery(sql, parameters);

					Console.WriteLine("已新增資料");
				}
				catch (Exception ex)
				{
					Console.WriteLine($"操作失敗，原因：{ex.Message}");
				}

			}

			public static void Delete(int id)
			{
				string sql = "DELETE from Users WHERE id = @id";
				var dbHelper = new SqlDbHelper("default");

				try
				{
					var parameters = new SqlParameterBuilder().AddInt("id", id).Build();
					dbHelper.ExecuteNonQuery(sql, parameters);

					Console.WriteLine("資料已刪除");
				}
				catch (Exception ex)
				{
					Console.WriteLine($"操作失敗，原因：{ex.Message}");
				}

			}

			public static void Select(int id)
			{
				string sql = "SELECT * FROM Users WHERE id = @id";
				var dbHelper = new SqlDbHelper("default");

				try
				{
					var parameters = new SqlParameterBuilder().AddInt("id", id).Build();
					DataTable data = dbHelper.Select(sql, parameters);

					foreach (DataRow item in data.Rows)
					{
						Console.WriteLine($"name = {item["name"]}\r\nAccount = {item["account"]}\r\ndateOfBirth = {item["dateOfBirth"]:yyyy-MM-dd}\r\nHeight = {item["height"]}");
					}
					Console.WriteLine();
				}
				catch (Exception ex)
				{
					Console.WriteLine($"操作失敗，原因：{ex.Message}");
				}
			}
			public static void Update(int id, string name, string account, string password, DateTime dateOfBirth, int height)
			{
				string sql = @"UPDATE Users SET 
							   Name = @name,
							   Account = @account,
							   Password = @password,
							   DateOfBirth = @dateofbirth,
							   Height= @height
							   WHERE id = @id";
				var dbHelper = new SqlDbHelper("default");

				try
				{
					var parameters = new SqlParameterBuilder()
										 .AddNVarchar("Name", 50, name)
										 .AddInt("id", id)
										 .AddNVarchar("Account", 50, account)
										 .AddNVarchar("Password", 50, password)
										 .AddDateTime("DateOfBirth", dateOfBirth)
										 .AddInt("Height", height)
										 .Build();
					dbHelper.ExecuteNonQuery(sql, parameters);

					Console.WriteLine("資料已變更");

				}
				catch (Exception ex)
				{
					Console.WriteLine($"操作失敗，原因：{ex.Message}");
				}

			}

		}

		//}
		//public static void Update()
		//{
		//	string sql = ""
		//}
	}
}
