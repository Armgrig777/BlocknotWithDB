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
    public class RecordRepository : IRepository<Record>
    {
        SqlConnection connection;
        private bool disposedValue;

        public RecordRepository()
        {
            connection = new SqlConnection(Utils.ConnectionString);
            connection.Open();
        }

        public void Add(Record record)
        {
            string commandStr = "INSERT INTO Records (Name, Surname) VALUES (@Name, @Surname)";

            using SqlCommand cmd = new SqlCommand(commandStr, connection);

            cmd.Parameters.AddWithValue("@Name", record.Name);
            cmd.Parameters.AddWithValue("@Surname", record.Surname);

            cmd.ExecuteNonQuery();
        }

        public void Delete(Record record)
        {
            SqlCommand sqlCommand = new SqlCommand($"DELETE FORM Records WHERE ID =@ID", connection);
            sqlCommand.Parameters.AddWithValue("ID", record.ID);
            sqlCommand.ExecuteNonQuery();

        }

        public void Dispose()
        {
            this.connection.Dispose();
        }

        public IEnumerable<Record> GetAll()
        {
            string sql = "SELECT * FROM Records";

            SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Record record = new Record()
                {
                    ID = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Surname = (string)reader["Surame"],
                };

                yield return record;
            }
        }



        public void SaveChanges()
        {


        }

        public void Update(Record record)
        {
            SqlCommand sqlCommand = new SqlCommand("UPDATE Record SET Name = @Name,Surname = @Surname WHERE ID = @ID", connection);
            sqlCommand.Parameters.AddWithValue("Name", record.Name);
            sqlCommand.Parameters.AddWithValue("Surname", record.Surname);
            sqlCommand.ExecuteNonQuery();
        }




        Record IRepository<Record>.GetById(int? id)
        {
            if (id == null)
                return null;
            Record record = new Record();
            string sql = $"SELECT Book FROM Books WHERE ID= @{id}";

            SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                record.ID = (int)reader["Id"];
                record.Name = (string)reader["Name"];
                record.Surname = (string)reader["Surame"];
            }
            return record;
        }
    }
}
