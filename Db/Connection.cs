using Linq.Models;
using Microsoft.Data.SqlClient;

namespace Linq.Db;


internal class Connection
{
    private string _ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=sounds;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";


    public SqlConnection GetConnection()
    {
        return new SqlConnection(_ConnectionString);
    }


}