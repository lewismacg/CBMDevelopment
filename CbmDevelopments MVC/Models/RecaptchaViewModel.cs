namespace CbmDevelopments.MVC.Models
{
	public class RecaptchaViewModel
	{
		public virtual string FormSelector { get; set; }
		public virtual string SubmitButtonSelector { get; set; }
		public virtual bool DisplayRecaptchaText { get; set; }
	}
}
