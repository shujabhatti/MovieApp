using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Model
{
    public class MyCustomer
    {
        [Key] public int customer_ID { get; set; }
        [Required] public string name { get; set; }
        [Required] public string email { get; set; }
        [Required] public long phone { get; set; }
    }

    public class CustomerCred
    {
        [Key] public int customer_cred_ID { get; set; }
        [Required] public string email { get; set; }
        [ForeignKey("customer_ID")] public int customer_ID { get; set; }
        [Required] public string password { get; set; }
    }

    public class Ticket
    {
        [Key] public int ticket_ID { get; set; }
        [ForeignKey("customer_ID")] public int customer_ID { get; set; }
        [ForeignKey("showing_ID")] public int showing_ID { get; set; }
        [ForeignKey("seat_ID")] public int seat_ID { get; set; }
        [Required] public double price { get; set; }
    }

    public class Seat
    {
        [Key] public int seat_ID { get; set; }
        [ForeignKey("screen_ID")] public int screen_ID { get; set; }
        [ForeignKey("type_ID")] public int seat_type { get; set; }
    }

    public class SeatType
    {
        [Key] public int type_ID { get; set; }
        [Required] public string name { get; set; }
        [Required] public double price { get; set; }
    }

    public class Screen
    {
        [Key] public int screen_ID { get; set; }
        [Required] public string capacity { get; set; }
        [ForeignKey("tier_ID")] public int sc_tier_ID { get; set; }
    }

    public class ScreenTier
    {
        [Key] public int tier_ID { get; set; }
        [Required] public double price { get; set; }
        [Required] public string description { get; set; }
    }

    public class Showing
    {
        [Key] public int showing_ID { get; set; }
        [ForeignKey("movie_ID")] public int movie_ID { get; set; }
        [ForeignKey("screen_ID")] public int screen_ID { get; set; }
        [Required] public DateTime date { get; set; }
        [Required] public DateTime start_time { get; set; }
        [ForeignKey("staff_ID")] public int scheduler_ID { get; set; }
    }

    public class Staff
    {
        [Key] public int staff_ID { get; set; }
        [Required] public string name { get; set; }
        [Required] public string username { get; set; }
    }

    public class StaffCredential
    {
        [Key] public int staffcred_ID { get; set; }
        [Required] public string username { get; set; }
        [ForeignKey("staff_ID")] public int staff_ID { get; set; }
        [Required] public string password { get; set; }
    }

    public class Movie
    {
        [Key] public int movie_ID { get; set; }
        [Required] public string title { get; set; }
        [Required] public string genre { get; set; }
        [Required] public DateTime release_date { get; set; }
        [Required] public string synopsis { get; set; }
        [Required] public string director { get; set; }
        [Required] public int rating { get; set; }
        [Required] public string age_rating { get; set; }
        [Required] public DateTime timestamp { get; set; }
    }
}
