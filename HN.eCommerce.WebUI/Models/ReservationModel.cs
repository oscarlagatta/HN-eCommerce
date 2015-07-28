using System;

namespace HN.eCommerce.WebUI.Models
{
    public class ReservationModel
    {
        public int Car { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}