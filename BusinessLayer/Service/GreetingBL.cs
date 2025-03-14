﻿using BusinessLayer.Interface;
using ModelLayer.Model;
using ReposatoryLayer.Entity;
using ReposatoryLayer.Interface;
using ReposatoryLayer.Service;

namespace BusinessLayer.Service
{
    public class GreetingBL : IGreetingBL
    {
        private readonly IGreetingRL _greetingRL;

        public GreetingBL(IGreetingRL greetingRL)
        {
            _greetingRL = greetingRL;
        }


        public string GreetMessage(string firstName, string lastName)
        {
            string message = string.Empty;

            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                message = $"Hello {firstName} {lastName}";
            }
            else if (!string.IsNullOrEmpty(firstName))
            {
                message = $"Hello {firstName}";
            }
            else if (!string.IsNullOrEmpty(lastName))
            {
                message = $"Hello Mr./ Mrs./ Miss {lastName}";
            }
            else
            {
                message = "Hello World";
            }

            // Save the greeting to the database
            var greetingMessage = new GreetingMessage
            {
                Message = message
            };

            _greetingRL.SaveGreeting(greetingMessage);

            return message;
        }

        public List<GreetingMessage> GetAllGreetings()
        {
            return _greetingRL.GetAllGreetings();
        }
        public void SaveGreeting(GreetingMessage greetingMessage)
        {
            throw new NotImplementedException();
        }


        public GreetingMessage FindGreetingById(int id)
        {
            return _greetingRL.GetGreetingById(id);
        }

        public GreetingMessage UpdateGreeting(int id, string newMessage)
        {
            var existingGreeting = _greetingRL.GetGreetingById(id);
            if (existingGreeting != null)
            {
                existingGreeting.Message = newMessage;
                return _greetingRL.SaveGreeting(existingGreeting);  // Save the updated greeting
            }
            return null;  // If greeting with the given id does not exist
        }

        public bool DeleteGreeting(int id)
        {
            return _greetingRL.DeleteGreeting(id);  // Call repository layer to delete
        }
    }
}
