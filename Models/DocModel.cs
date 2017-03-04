using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Document_Upload.Models
{
    public class DocModel
    {
        public bool IsAdmin { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Document { get; set; }
    }
}