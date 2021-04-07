using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Models
{
    public class CreateTweetRequest
    {
        [FromForm(Name = "text")]
        [Required(ErrorMessage = "Text is required")]
        public string Text { get; set; }
    }
}