using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ispan.Utility
{
	public class SqlParameterBuilder
	{

		private List<SqlParameter> list = new List<SqlParameter>();

		public SqlParameter[] Build()
		{
			return list.ToArray();
		}
		public SqlParameterBuilder AddNVarchar(string name, int length, string values)
		{
			SqlParameter titleParam = new SqlParameter(name, SqlDbType.NVarChar, length)
			{ Value = values };

			list.Add(titleParam);

			return this;
		}

		public SqlParameterBuilder AddInt(string name, int values)
		{
			SqlParameter titleParam = new SqlParameter(name, SqlDbType.Int) { Value = values };
			list.Add(titleParam);

			return this;
		}
		public SqlParameterBuilder AddDateTime(string name, DateTime values)
		{
			SqlParameter titleParam = new SqlParameter(name, SqlDbType.DateTime)
			{ Value = values };

			list.Add(titleParam);

			return this;
		}
		public SqlParameterBuilder AddBool(string name, bool values)
		{
			SqlParameter titleParam = new SqlParameter(name, SqlDbType.Bit)
			{ Value = values };

			list.Add(titleParam);

			return this;
		}

	}
}
