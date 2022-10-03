using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models;

public sealed class Customer
{
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(40)]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(40)]
    public string LastName { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(70)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Phone { get; set; } = string.Empty;
    
    public DateTime Date { get; set; }

}
