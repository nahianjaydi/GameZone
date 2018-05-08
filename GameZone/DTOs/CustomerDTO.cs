﻿using GameZone.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameZone.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        [Required]
        //[Min18YearsForMembership]
        public DateTime Birthdate { get; set; }

        [Required]
        public byte MembershipTypeId { get; set; }
        public MembershipTypeDTO MembershipType { get; set; }
    }
}