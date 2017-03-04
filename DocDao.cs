using Document_Upload.Models;

namespace Document_Upload
{
    /// <summary>
    /// Use this class to access the database
    /// </summary>
    public class DocDao
    {
        public bool AddDoc(string FirstName, string LastName, string encodedDoc)
        {
            // Add the encoded document to the database.

            // Return whether or not it was successful
            return true;
        }

        public byte[] GetDoc(DocModel model)
        {
            // Retrieve the document

            // Return the doc
            return new byte[2];
        }
    }

}