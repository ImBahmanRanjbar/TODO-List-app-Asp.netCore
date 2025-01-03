using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TODO.Models;

public class TODO
{
    public int  ID { get; set; }
    [Required(ErrorMessage = "please enter a description.")]
    public string Description { get; set; }=String.Empty;
    [Required(ErrorMessage = "please enter a due date.")]
    public DateTime? DueDate { get; set; }
    [Required(ErrorMessage = "please enter a Category")]
    public string CategoryID { get; set; }=String.Empty;

    [ValidateNever] 
    public Category Category { get; set; } = null!;
    [Required(ErrorMessage = "please enter a Status")]
    public string StatusID { get; set; }=String.Empty;

    [ValidateNever] 
    public Status Status { get; set; } = null!;

    public bool Overdue => StatusID == "Open" && DueDate < DateTime.Today;
    

}