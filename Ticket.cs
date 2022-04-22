using System;
using Microsoft.EntityFrameworkCore;

namespace Tournament
{
    public class Ticket  //: Fans
    {
        public int Id { get; set; }
        public string FanName { get; set; }
        public string FavoriteCommand { get; set; }
        public int TicketNumber { get; set; } 
    }
    
}
