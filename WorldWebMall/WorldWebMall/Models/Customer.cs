using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Microsoft.AspNet.Identity;
using WorldWebMall.Models;
using System.Data.Entity.Spatial;

namespace WorldWebMall.Models
{
    public class Customer
    {
        public Customer()
        {
            //this.Broadcasts = new HashSet<Broadcast>();
            this.Adverts = new HashSet<Advert>();
            this.Followings = new HashSet<Followings>();
        }
        [Key]
        public string CustomerId { get; set; }
        public string fname { get; set; }
        public string mname { get; set; }
        public string lname { get; set; }
        public int contacts { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public int num_friends { get; set; }
        public int active_ads { get; set; }
        public DateTime? dob { get; set; }
        //public int Variable { get; set; }

        //put address here
        public virtual CustomerAddress CustomerAddress { get; set; }
        public virtual Picture p_pic { get; set; }
        public virtual Picture wallpaper { get; set; }

        //The broadcast <=> customer correspondance checked in the broadcast table
        //public virtual ICollection<Broadcast> Broadcasts { get; set; }
        
        
        
        public virtual ICollection<Followings> Followings { get; set; }
        public virtual ICollection<Advert> Adverts { get; set; }
    }

    public class CustomerAddress
    {
        [Key, ForeignKey("Customer")]
        public string CustomerId { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string suburb { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public DbGeography Location { get; set; }

        public virtual Customer Customer { get; set; }
        
    }

    //Followings table used instead of one to many rel because of the need to take note of the follow date for notification 
    //and record keeping purposes
    public class Followings
    {
        [ForeignKey("Company"), Key, Column(Order = 1)]
        public string CompanyId { get; set; }
        [ForeignKey("Customer"), Key, Column(Order = 2)]
        public string CustomerId { get; set; }
        public DateTime time { get; set; }

        public virtual Company Company { get; set; }
        public virtual Customer Customer { get; set; }
    }

    //customers only get notifications form the adverts they would have posted
    public class CustomerNotification
    {
        [Key]
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public int ContentId { get; set; }
        public bool seen { get; set; }
        public DateTime first { get; set; }
        public DateTime last { get; set; }
        public string type { get; set; }//whether its a comment or a like
    }

    public class Request
    {
        [Key]
        public int Id { get; set; }
        public string receiverId { get; set; }
        //customerDTO
        [ForeignKey("receiverId")]
        public virtual Customer Receiver { get; set; }

        public string senderId { get; set; }
        //another customerDTO
        [ForeignKey("senderId")]
        public virtual Customer Sender { get; set; }

        public bool accepted { get; set; }
        public bool seen { get; set; }
    }

    public class Buddy
    {
        public Buddy()
        {
            this.Customers = new HashSet<Customer>();
        }

        //the Id of the user whose friends are in the collection
        [Key]
        public string Id { get; set; }

        //this keeps a colletion of the friends the user has
        public virtual ICollection<Customer> Customers { get; set; }

       

    }

    public class Friend
    {
        [Key]
        public string CustomerId { get; set; }
        public string FriendId { get; set; }

        [ForeignKey("FriendId")]
        public virtual Customer Customer { get; set; }
    }

    public class Advert
    {
        public Advert()
        {
            this.ALikes = new HashSet<ALike>();
            this.AComments = new HashSet<AComment>();
            this.pictures = new HashSet<Picture>();
            this.Categories = new HashSet<Category>();
        }
        [Key]
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string title { get; set; }
        public string info { get; set; }
        [Column(TypeName = "Money")]
        public decimal price { get; set; }
        public string amount { get; set; }
        public DateTime time { get; set; }
        public DateTime exp { get; set; }
        public DbGeography Location { get; set; } 

        public virtual Customer Customer { get; set; }
        
        public virtual ICollection<Picture> pictures { get; set; }
        public virtual ICollection<ALike> ALikes { get; set; }
        public virtual ICollection<AComment> AComments { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }

    public class ALike
    {
        [Key, Column(Order = 1)]
        public int AdvertId { get; set; }
        [Key, Column(Order=2)]
        public string CustomerId { get; set; }
        public DateTime time { get; set; }

        public virtual Customer Customer { get; set; }
    }

    public class Test
    {
        [Key]
        public int Id { get; set; }
        public int parent { get; set; }
        public int child { get; set; }
        public int value { get; set; }
    }

    public class AComment
    {
        [Key]
        public int Id { get; set; }
        public int AdvertId { get; set; }
        public string CustomerId { get; set; }
        public string comment { get; set; }
        public DateTime time { get; set; }

        public virtual Customer Customer { get; set; }
    }

    public class Picture
    {
        [Key]
        public int Id { get; set; }
        public string path { get; set; }
    }

    public class TestVer
    {
        [Key]
        public int Id { get; set; }
        public int parent { get; set; }
        public int child { get; set; }
        public int value { get; set; }
    }

}