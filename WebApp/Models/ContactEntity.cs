using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApp.Models;

[Table("contact")]
public class ContactEntity
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(length: 20)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(length: 50)]
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    [Column("number")]
    public string PhoneNumber { get; set; }
    
    public DateOnly BirthDate { get; set; }
    
    public Category Category { get; set; }
    
    public DateTime Created { get; set; }
}