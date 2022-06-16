using System.ComponentModel.DataAnnotations;

namespace CbmDevelopments.MVC.Models
{
	public class ContactUsModel
	{
		[Required(ErrorMessage = "Please enter your name")]
		public virtual string Name { get; set; }
		[Required(ErrorMessage = "Please enter an email address")]
		[EmailAddress(ErrorMessage = "Please enter a valid email address")]
		public virtual string Email { get; set; }
		public virtual string PhoneNumber { get; set; }
		[Required(ErrorMessage = "Please write your message below.")]
		[StringLength(1000, ErrorMessage = "Please make your message a bit shorter, or ring us instead if you prefer.")]
		public virtual string Message { get; set; }
	}
}
