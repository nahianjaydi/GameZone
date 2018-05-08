using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GameZone.Models;

namespace GameZone.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }


        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        [Required]
        [Min18YearsForMembership]
        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public byte? MembershipTypeId { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Customer" :  "New Customer";
            }
        }

        public CustomerFormViewModel()
        {
            Id = 0;
        }

        public CustomerFormViewModel(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            Birthdate = customer.Birthdate;
            MembershipTypeId = customer.MembershipTypeId;
            IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
        }
    }
}