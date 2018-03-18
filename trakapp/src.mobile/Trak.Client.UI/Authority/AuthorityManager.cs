﻿using Trak.Client.Portable;
using Xamarin.Forms;

namespace Trak.Client.UI
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

		public void InvalidateCredentials()
		{
			token = null;
			Save(null);
			MessagingCenter.Send(this, ON_REQUIRE_CREDENTIALS, false);
		}

		public void RequestUpdateCredentials()
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
				CredentialToken.Hydrate(creddata);
			}

			return null;
		}

		public static bool Save(CredentialToken token)
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
