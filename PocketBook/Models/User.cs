﻿using System.ComponentModel.DataAnnotations;

namespace PocketBook.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
      
        public string LastName { get; set; }

        [EmailAddress]
        public String Email { get; set; }
    }
}
