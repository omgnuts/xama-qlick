using System.Threading.Tasks;
using Xamarin.Forms;

namespace Trak.Client.Portable
{
	public class AuthorityManager
	{
		public const string ON_REQUIRE_CREDENTIALS = "RequireNewCredentials";

		static AuthorityManager instance;
		public static AuthorityManager Instance
		{
			get
			{
				if (instance == null) instance = new AuthorityManager();
				return instance;
			}
		}

		CredentialToken token;

		public CredentialToken Token
		{
			get
			{
				if (token == null)
				{
					token = Load();
				}
				return token;
			}
		}

        public void ResetDemoCredentials() {
            token = null;
            Save(null);
        }

		public void InvalidateCredentials()
		{
			token = null;
			Save(null);
			MessagingCenter.Send(this, ON_REQUIRE_CREDENTIALS, false);
		}

		public void RequireNewCredentials()
		{
			MessagingCenter.Send(this, ON_REQUIRE_CREDENTIALS, true);
		}

		public bool IsValidCredentials()
		{
			if (Token == null)
			{
				InvalidateCredentials();
				return false;
			}
			return true;
		}

		CredentialToken Load()
		{
			string creddata = DependencyService.Get<IAuthentication>().GetFromKeychain("credentials");
			if (creddata != null)
			{
				return CredentialToken.Hydrate(creddata);
			}

			return null;
		}

		public async Task<bool> RequestAuthenticationToken(CredentialRequest request)
		{
			CredentialToken ctoken = await TrakAPI.Instance.GetAuthenticationTokenAsync(request);
			if (ctoken != null)
			{
				return Save(ctoken);
			}
			return false;
		}

		public bool Save(CredentialToken token)
		{
			bool success = false;

			if (token != null)
			{
                success = DependencyService.Get<IAuthentication>().StoreInKeychain("credentials", token.Dehydrate);
			}
			else
			{
				success = DependencyService.Get<IAuthentication>().RemoveFromKeychain("credentials");
			}

			return success;
		}
	}
}
