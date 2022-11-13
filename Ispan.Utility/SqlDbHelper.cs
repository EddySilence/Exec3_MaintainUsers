using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ispan.Utility
{
	public class SqlDbHelper
	{

		private string connString;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="KeyOfConnString">app.config裡的值，例如default</param>
		public SqlDbHelper(string KeyOfConnString)
		{
			connString = System.Configuration.ConfigurationManager
							   .ConnectionStrings[KeyOfConnString]
							   .ConnectionString; ;
		}
		public void ExecuteNonQuery(string sql, SqlParameter[] parameters)
		{
			using (var conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand(sql, conn);
				conn.Open();

				command.Parameters.AddRange(parameters);

				command.ExecuteNonQuery();
			}
		}

		public DataTable Select(string sql, SqlParameter[] parameters)
		{
			using (var conn = new SqlConnection(connString))
			{

				SqlCommand command = new SqlCommand(sql, conn);
				if (parameters != null)
				{
					command.Parameters.AddRange(parameters);
				}

				SqlDataAdapter adapter = new SqlDataAdapter(command);

				DataSet dataSet = new DataSet();
				adapter.Fill(dataSet, "sb");

				return dataSet.Tables["sb"];

			}

		}
	}
}
