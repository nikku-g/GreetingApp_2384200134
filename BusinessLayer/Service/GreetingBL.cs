using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interface;

namespace BusinessLayer.Service
{
    public class GreetingBL : IGreetingBL
    {
        /// <summary>
        /// This method is return greet message
        /// </summary>
        /// <return>"Hello World"</return>
        public string GreetMessage(String? FirstName, String? LastName)
        {
            if (FirstName!= null && LastName!= null)
            {
                return $"Hello {FirstName} {LastName}";
            }
            else if (FirstName!= null)
            {
                return $"Hello {FirstName}";
            }
            else if (LastName!= null)
            {
                return $"Hello Mr./ Mrs./ Miss.{LastName}";
            }
            else
            {
                return "Hello World";
            }
            
        }
    }
}
