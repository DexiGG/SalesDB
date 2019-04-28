using System.Configuration;
using System.Data.Common;

namespace SalesDB.DataAccess
{
    public class SalesDBDataService
    {
        public string connectionString { get; }
        public string providerName { get; }
        public DbProviderFactory providerFactory { get; }

        public SalesDBDataService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            providerName = ConfigurationManager.ConnectionStrings["DefaultConnection"].ProviderName;
            providerFactory = DbProviderFactories.GetFactory(providerName);
        }
    }
}
