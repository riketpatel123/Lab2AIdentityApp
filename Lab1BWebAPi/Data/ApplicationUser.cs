﻿// I, Riket patel, 000730183, certify that this material is my
// original work. No other person's work has been used without due
// acknowledgement and I have not made my work available to anyone else.
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1BWebAPi.Data
{
    public class ApplicationUser:IdentityUser
    {
       
        [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public string Company { get; set; }

    public string Position { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
    }
}
