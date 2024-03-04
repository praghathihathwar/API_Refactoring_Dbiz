namespace LegacyApp.Repository;

public class ClientRepository : IClientRepository
{
    private readonly IDatabaseConfig _dbConnectionString;
    public ClientRepository(IDatabaseConfig dbConnectionSting) 
    { 
        _dbConnectionString = dbConnectionSting;
    }
    public async Task<Client> GetByIdAsync(int id)
    {
        Client client = null;
        //var connectionString = ConfigurationManager.ConnectionStrings["appDatabase"].ConnectionString;
        var connectionString = _dbConnectionString.GetConnectionString();

        using (var connection = new SqlConnection(connectionString))
        {
            var command = new SqlCommand
            {
                Connection = connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "uspGetClientById"
            };

            var parameter = new SqlParameter("@ClientId", SqlDbType.Int) { Value = id };
            command.Parameters.Add(parameter);

            connection.Open();
            var reader = await command.ExecuteReaderAsync(CommandBehavior.CloseConnection);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    client = new Client
                    {
                        Id = int.Parse(reader["ClientId"].ToString()),
                        Name = reader["Name"].ToString(),
                        ClientStatus = (ClientStatus)int.Parse(reader["ClientStatusId"].ToString())
                    };
                }
            }
        }

        return client;
    }
}
