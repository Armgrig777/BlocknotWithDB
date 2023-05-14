using BlocknotWithRepo.Data.Abstract;
using BlocknotWithRepo.Data.Entites;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocknotWithRepo.Data.Concrete
{
    public class AddressRepository : IRepository<Address>
    {
        SqlConnection connection;
        private bool disposedValue;
        public AddressRepository()
        {
            connection = new SqlConnection(Utils.ConnectionString);
            connection.Open();
        }
        public void Add(Address record)
        {
            string commandStr = "INSERT INTO Address (Street,City) VALUES (@Street, @City)";

            using SqlCommand cmd = new SqlCommand(commandStr, connection);

            cmd.Parameters.AddWithValue("@Name", record.Street);
            cmd.Parameters.AddWithValue("@Surname", record.City);

            cmd.ExecuteNonQuery();
        }

        public void Delete(Address record)
        {
            SqlCommand sqlCommand = new SqlCommand($"DELETE FORM Address WHERE ID =@ID", connection);
            sqlCommand.Parameters.AddWithValue("ID", record.ID);
            sqlCommand.ExecuteNonQuery();
        }

        public void Dispose()
        {
            this.connection.Dispose();
        }

        public IEnumerable<Address> GetAll()
        {
            string sql = "SELECT * FROM Address";

            SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Address record = new Address()
                {
                    ID = (int)reader["Id"],
                    Street = (string)reader["Street"],
                    City = (string)reader["City"],
                };

                yield return record;
            }
        }

        Address IRepository<Address>.GetById(int? id)
        {
            if (id == null)
                return null;
            Address record = new Address();
                string sql = $"SELECT Book FROM Books WHERE ID= @{id}";

                SqlCommand command = new SqlCommand(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    record.ID = (int)reader["Id"];
                    record.Street = (string)reader["Name"];
                    record.City = (string)reader["Surame"];
                }
                return record;
            
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Address record)
        {
            SqlCommand sqlCommand = new SqlCommand("UPDATE Address SET Street = @Street,City = @City WHERE ID = @ID", connection);
            sqlCommand.Parameters.AddWithValue("Name", record.Street);
            sqlCommand.Parameters.AddWithValue("Surname", record.City);
            sqlCommand.ExecuteNonQuery();
        }
    }
}
