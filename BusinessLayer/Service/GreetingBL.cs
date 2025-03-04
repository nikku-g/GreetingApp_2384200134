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
        /// This method is print Hello World
        /// </summary>
        /// <return>"Hello World"</return>
        public string GreetMessage()
        {
            return "Hello World";
        }
    }
}
