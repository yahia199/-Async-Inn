using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_App.Services.DTOs
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        [NotMapped]
        public IList<string> Roles { get; set; }
    }
}
