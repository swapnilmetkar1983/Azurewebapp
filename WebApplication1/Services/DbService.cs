using System.Data.Common;
using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class DbService
    {
        private static string DbDataSource = "myfirstazuresqlserv.database.windows.net";
        private static string userName = "demouser1";
        private static string Password = "swapnilvm1@1983";
        private static string DbName = "myFirstAzureSQLDB";

        private SqlConnection GetConnection()
        {
            var _con = new SqlConnectionStringBuilder();
            _con.DataSource = DbDataSource;
            _con.UserID = userName;
            _con.Password = Password;
            _con.InitialCatalog = DbName;

            return new SqlConnection(_con.ConnectionString);
        }

        public List<Products> GetProducts() 
        {
            SqlConnection _con = GetConnection();
            List<Products> lstproducts = new List<Products>();
            string sqlStatement = "select * from Products";

            _con.Open();

            SqlCommand cmd = new SqlCommand(sqlStatement, _con);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read()) 
                {
                    Products prod = new Products()
                    {
                        productId = reader.GetInt32(0),
                        productName = reader.GetString(1)
                    };

                    lstproducts.Add(prod);
                }
            }
            _con.Close();
            return lstproducts;
        }
    }
}
