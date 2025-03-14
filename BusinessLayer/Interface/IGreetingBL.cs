﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReposatoryLayer.Entity;

namespace BusinessLayer.Interface
{
    /// <summary>
    /// This is an interface class
    /// </summary>
    public interface IGreetingBL
    {
        /// <summary>
        /// This method is to print message
        /// </summary>
        public string GreetMessage(String FirstName, String LastName);
        void SaveGreeting(GreetingMessage greetingMessage);
        List<GreetingMessage> GetAllGreetings();
        GreetingMessage FindGreetingById(int id);

        // New method to update a greeting message
        GreetingMessage UpdateGreeting(int id, string newMessage);

        // New method for deleting a greeting message
        bool DeleteGreeting(int id);
    }
}
