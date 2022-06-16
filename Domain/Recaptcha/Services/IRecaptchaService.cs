using System.Threading.Tasks;
using Domain.Recaptcha.Entities;

namespace Domain.Recaptcha.Services
{
	public interface IRecaptchaService
	{
		Task<IsRecaptchaValidResponseEnum> IsReCaptchaValidAsync(string responseToken);
	}
}
