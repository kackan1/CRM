using System.Collections.Generic;
using System.Data.SqlClient;

namespace CRM2.Views
{
    public static class DatabaseManager
    {
        public static string ConnectionString = "Data Source=.;Initial Catalog=VSCRM;Integrated Security=True";


        public static List<Package> LoadPackages()
        {
            List<Package> packages = new List<Package>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "" +
                    "select p.PAKID,p.Pakiet,k.Nazwa,p.WaznyOD,p.WaznyDO,p.IloscGodz,p.typ,p.archiwalny " +
                    "from dbo.pakiety as p join dbo.Klienci as k on k.KNTID=p.Klient " +
                    "where p.archiwalny<>1" +
                    "order by k.Nazwa";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Package package = new Package();
                            package.Id = reader.GetInt32(0);
                            package.Name = reader.GetString(1);
                            package.Client = reader.GetString(2);
                            if (!reader.IsDBNull(3))
                            {
                                package.SetValidFrom(reader.GetDateTime(3).ToString().Substring(0, 10));
                            }
                            else
                            {
                                package.SetValidFrom("");
                            }
                            if (!reader.IsDBNull(4))
                            {
                                package.ValidTo = reader.GetDateTime(4).ToString();
                                package.ValidTo = package.ValidTo.Substring(0, 10);
                            }
                            else
                            {
                                package.ValidTo = "";
                            }
                            package.Hours = reader.GetDecimal(5);
                            package.Type = reader.GetString(6);
                            package.Archived = reader.GetBoolean(7);
                            packages.Add(package);
                        }
                    }
                }
            }
            return packages;
        }
    }
}