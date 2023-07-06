using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace VoteApp.ViewModels
{
	public class LoginViewModel
    {
		public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public int Role { get; set; }
    }
}