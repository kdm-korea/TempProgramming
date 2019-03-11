using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetConnectAzure
{
    class Program
    {
        public static void Main(string[] args) {
            try {
                AzureDBService();
            }
            catch (SqlException e) {
                Console.WriteLine($"SqlException : {e}");
                Console.ReadLine();
            }
            catch (Exception e) {
                Console.WriteLine($"Exception : {e}");
                Console.ReadLine();
            }
        }

        private static void AzureDBService() {
            using (SqlConnection connection = new SqlConnection(BankDatabase())) {
                connection.Open();
                string sql = GetColorName();

                using (SqlCommand command = new SqlCommand(sql, connection)) {
                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                        }
                    }
                }
            }
            throw new Exception();
        }

        private static string BankDatabase() {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "dongmindbserver.database.windows.net";
            builder.UserID = "kdm";
            builder.Password = "rlaehdals1!";
            builder.InitialCatalog = "BankDatabase";
            return builder.ConnectionString;
        }

        private static string GetColorName() {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT TOP 20 pc.Name as CategoryName, p.name as ProductName ");
            sb.Append("FROM [SalesLT].[ProductCategory] pc ");
            sb.Append("JOIN [SalesLT].[Product] p ");
            sb.Append("ON pc.productcategoryid = p.productcategoryid;");
            return sb.ToString();
        }
    }
}
