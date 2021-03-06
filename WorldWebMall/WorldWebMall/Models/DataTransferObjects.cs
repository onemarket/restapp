﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using Newtonsoft.Json;

namespace WorldWebMall.Models
{
    public class CustomerDTO
    {
        public string ID { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public PictureDTO profile_pic { get; set; }
    }

    public class CustomerDetails
    {
        public string ID { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public PictureDTO profile_pic { get; set; }
        public int contacts { get; set; }
        public string gender { get; set; }
        public int num_friends { get; set; }
        public int active_ads { get; set; }
        public int num_of_followigs { get; set; }
        public DateTime? date_of_birth { get; set; }
        public Location location { get; set; }
    }

    public class CustomerData
    {
        public string fname { get; set; }
        public string mname { get; set; }
        public string lname { get; set; }
        public int contacts { get; set; }
        public string gender { get; set; }
        public DateTime date_of_birth { get; set; }     
    }

    public class Address
    {
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string suburb { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }
        //public virtual Company Company { get; set; }
    }

    public class Location
    {
        public string surburb { get; set; }
        public string city { get; set; }
        public string country { get; set; }
    }

    public class Advertisement
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string details { get; set; }
        public string price { get; set; }
        public int? minutes { get; set; }
        public int? hours { get; set; }
        public DateTime date { get; set; }
        public int number_of_views { get; set; }
        public int number_of_likes { get; set; }
        public int number_of_comments { get; set; }
        public bool liked { get; set; }
        public double? longitude { get; set; }
        public double? latitude { get; set; }
        public virtual Seller seller { get; set; }

        public virtual ICollection<PictureDTO> images { get; set; }
        public virtual  ICollection<AdLike> likes { get; set; }
        public virtual ICollection<AdComment> comments { get; set; }
    }

    public class AdComment
    {
        public int ID { get; set; }
        public string comment { get; set; }
        public int? minutes { get; set; }
        public int? hours { get; set; }
        public DateTime date { get; set; }
        public CustomerDTO customer { get; set; }
    }

    public class AdLike
    {
        public UserDTO user { get; set; }
    }

    public class CommentDTO
    {
        public string comment { get; set; }
    }
    public class CompanyDTO
    {
        public string ID { get; set; }
        public string name { get; set; }
        public PictureDTO wallpaper { get; set; }
        public PictureDTO profile_pic { get; set; }
        public int number_of_followers { get; set; }
    }

    public class CompanyDetails
    {
        public string ID { get; set; }
        public string name { get; set; }
        //public string email { get; set; }

        public PictureDTO wallpaper { get; set; }
        public PictureDTO profile_pic { get; set; }
        public string website { get; set; }
        public int number_of_followers { get; set; }
        public DateTime? regDate { get; set; }
        public string overview { get; set; }
        public string color { get; set; }
        [JsonIgnore]
        public string workinghours { get; set; }
        public WorkingHours work { get { return workinghours != null ? new WorkingHours().Convert(workinghours) : null; } }
       
        public ICollection<CompanyAddress> addresses { get; set; }
        public ICollection<CategoryDTO> category { get; set; }
        public ICollection<ContactDTO> contacts { get; set; }
    }

    public class ContactDTO
    {
        public string type { get; set; }
        [Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered mobile format is not valid.")]
        public string numbers { get; set; }
        [DataType(DataType.EmailAddress)]
        public string emails { get; set; }
    }

    public class CompanyData
    {
        public CompanyData() 
        {
            this.categories = new HashSet<string>();
            this.contacts = new HashSet<ContactDTO>();
        }

        public string name { get; set; }
        //public string email { get; set; }
        public string website { get; set; }
        public string overview { get; set; }
        public string color { get; set; }
        public WorkingHours workinghours { get; set; }

        public ICollection<ContactDTO> contacts { get; set; }
        public ICollection<string> categories { get; set; }
    }

    public class CompanyComment
    {
        public int ID { get; set; }
        public string comment { get; set; }
        public int? minutes { get; set; }
        public int? hours { get; set; }
        public DateTime date { get; set; }
        public CustomerDTO customer { get; set; }
        public CompanyDTO company { get; set; }
    }

    public class BroadcastDTO
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string details { get; set; }
        public int? minutes { get; set; }
        public int? hours { get; set; }
        public DateTime date { get; set; }
        public int number_of_views { get; set; }
        public int number_of_likes { get; set; }
        public int number_of_comments { get; set; }
        public bool liked { get; set; }

        public virtual CompanyDTO company { get; set; }

        public ICollection<PictureDTO> images { get; set; }
        public ICollection<BroadcastLike> likes { get; set; }
        public ICollection<BroadcastComment> comments { get; set; }
    }

    public class BroadcastComment
    {
        public int ID { get; set; }
        public string comment { get; set; }
        public int? minutes { get; set; }
        public int? hours { get; set; }
        public DateTime date { get; set; }
        public CustomerDTO customer { get; set; }
        public CompanyDTO company { get; set; }
    }

    public class Result
    {
        public bool created { get; set; }
        public IQueryable json { get; set; }
    }
    public class BroadcastLike
    {
        public CustomerDTO customer { get; set; }
        public CompanyDTO company { get; set; }
    }

    public class Feeds
    {
        public virtual ICollection<BroadcastDTO> feeds { get; set; }
    }

    //add the broadcasts a company has posted under company details
    public class Suggestions
    {
        public virtual ICollection<CompanyDetails> suggestions { get; set; }
    }

    public class CategoryDTO
    {
        public string category { get; set; }
    }

    public class CreateAd
    {
        public string title { get; set; }
        public string details { get; set; }
        [Column(TypeName = "Money")]
        public decimal price { get; set; }
        public string currency { get; set; }
        private string amount { get { return String.Format(CultureInfo.CreateSpecificCulture(currency), "{0:C}", price); } }
        public virtual ICollection<string> categories { get; set; }
    }

    public class CreateB
    {
        //public string companyId { get; set; }
        public string title { get; set; }
        public string details { get; set; }
        public virtual ICollection<string> categories { get; set;}
    }

    public class PictureDTO
    {
        public int Id { get; set; }
        public string url { get; set; }
    }

    public class Notification
    {
        public int ID { get; set; }
        public int ContentId { get; set; }
        public string type { get; set; }
        public bool seen { get; set; }
        public int? minutes { get; set; }
        public int? hours { get; set; }
        public DateTime date { get; set; }
        [JsonIgnore]
        public DateTime first { get; set; }
        public ICollection<CustomerDTO> customers { get; set; }
    }

    public class FriendRequest
    {
        public int Id { get; set; }
        public CustomerDTO friend { get; set; }
        public bool seen { get; set; }
    }

    public class AcceptedRequest
    {
        public int Id { get; set; }
        public CustomerDTO friend { get; set; }
        public bool seen { get; set; }
    }

    
    public class Seller
    {
        public string Id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string profile_pic { get; set; }
        public int contacts { get; set; }
        public string email { get; set; }
    }

    public class UserDTO
    {
        public string Id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
    }

    public class CategoryCompanies
    {
        public string category { get; set; }
        public ICollection<CompanyDTO> Companies { get; set; }
    }

    public class WorkingHours
    {
        [Required]
        [RegularExpression(@"^[0-2][0-9][0-5][0-9][-][0-2][0-9][0-5][0-9]|(closed)|(all\sday)$", ErrorMessage = "Invalid working hours provided")]
        public string sunday { get; set; }
        [Required]
        [RegularExpression(@"^[0-2][0-9][0-5][0-9][-][0-2][0-9][0-5][0-9]|(closed)|(all\sday)$", ErrorMessage = "Invalid working hours provided")]
        public string monday { get; set; }
        [Required]
        [RegularExpression(@"^[0-2][0-9][0-5][0-9][-][0-2][0-9][0-5][0-9]|(closed)|(all\sday)$", ErrorMessage = "Invalid working hours provided")]
        public string tuesday { get; set; }
        [Required]
        [RegularExpression(@"^[0-2][0-9][0-5][0-9][-][0-2][0-9][0-5][0-9]|(closed)|(all\sday)$", ErrorMessage = "Invalid working hours provided")]
        public string wednesday { get; set; }
        [Required]
        [RegularExpression(@"^[0-2][0-9][0-5][0-9][-][0-2][0-9][0-5][0-9]|(closed)|(all\sday)$", ErrorMessage = "Invalid working hours provided")]
        public string thursday { get; set; }
        [Required]
        [RegularExpression(@"^[0-2][0-9][0-5][0-9][-][0-2][0-9][0-5][0-9]|(closed)|(all\sday)$", ErrorMessage = "Invalid working hours provided")]
        public string friday { get; set; }
        [Required]
        [RegularExpression(@"^[0-2][0-9][0-5][0-9][-][0-2][0-9][0-5][0-9]|(closed)|(all\sday)$", ErrorMessage = "Invalid working hours provided")]
        public string saturday { get; set; }
        [Required]
        [RegularExpression(@"^[0-2][0-9][0-5][0-9][-][0-2][0-9][0-5][0-9]|(closed)|(all\sday)$", ErrorMessage = "Invalid working hours provided")]
        public string public_holiday { get; set; }

        public override string ToString()
        {
            return sunday + ":" + monday + ":" + tuesday + ":" + wednesday + ":" + thursday + ":" + friday + ":" + saturday + ":" + public_holiday;
        }

        public WorkingHours Convert(string working)
        {
            string[] hours = working.Split(':');
            this.sunday = hours[0]; this.monday = hours[1]; this.tuesday = hours[2]; this.wednesday = hours[3];
            this.thursday = hours[4]; this.friday = hours[5]; this.saturday = hours[6]; this.public_holiday = hours[7];

            return this;
        }
    }

    public class Working
    {
        public string hours { get; set; }
        //public string[] array { get { return hours.Split(':'); } }
        //public string sunday { get { return array[0]; } }
        //public string monday { get { return array[1]; } }
        //public string tuesday { get { return array[2]; } }
        //public string wednesday { get { return array[3]; } }
        //public string thursday { get { return array[4]; } }
        //public string friday { get { return array[5]; } }
        //public string saturday { get { return array[6]; } }
        //public string public_holiday { get { return array[7]; } }
    }
    
}