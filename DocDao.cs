using Document_Upload.Models;
using System.Data;
using System.Data.SqlClient;

namespace Document_Upload
{
    /// <summary>
    /// Use this class to access the database
    /// </summary>
    public class DocDao
    {
        private readonly string connectionString;

        public DocDao()
        {
            connectionString = "Server = (LocalDB)\\MSSQLLocalDB; Initial Catalog=DocDB; Integrated Security = false;";
        }

        public bool AddDoc(string FirstName, string LastName, byte[] encodedDoc)
        {
            string sql = "INSERT INTO DocDB.dbo.DocMain (FirstName, LastName, DocByteArray) VALUES (@First, @Last, @Doc)";

            using (SqlConnection _con = new SqlConnection(connectionString))
            using (SqlCommand _cmd = new SqlCommand(sql, _con))
            {
                _cmd.Parameters.AddWithValue("@Doc", encodedDoc);
                _cmd.Parameters.AddWithValue("@First", FirstName);
                _cmd.Parameters.AddWithValue("@Last", LastName);

                _con.Open();
                _cmd.ExecuteNonQuery();
                _con.Close();
            }
            // Return whether or not it was successful
            return true;
        }

        public byte[] GetDoc(DocModel model)
        {
            // Retrieve the document
            string sql = "SELECT TOP 1 pdf_url FROM records WHERE first_name = @First AND last_name = @Last";
            SqlDataReader reader;
            using (SqlConnection _con = new SqlConnection(connectionString))
            using (SqlCommand _cmd = new SqlCommand(sql, _con))
            {
                SqlParameter paramFirst = _cmd.Parameters.Add("@First", SqlDbType.VarChar);
                SqlParameter paramLast = _cmd.Parameters.Add("@Last", SqlDbType.VarChar);
                
                paramFirst.Value = model.FirstName;
                paramLast.Value = model.LastName;

                _con.Open();
                reader = _cmd.ExecuteReader();
                _con.Close();
            }

            // Return the doc
            return (byte[])reader.GetValue(0);
        }
    }

}