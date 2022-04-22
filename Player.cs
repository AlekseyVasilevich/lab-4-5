using System;
using Microsoft.EntityFrameworkCore;

namespace Tournament
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }  
    }

    
}
