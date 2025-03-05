using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReposatoryLayer.Entity
{
    /// <summary>
    /// Entity representing a greeting message stored in the database.
    /// </summary>
    public class GreetingMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }
    }
}
