using System;
using Trak.Client.Portable;
using Xamarin.Forms;

namespace Trak.Client.UI
{
	public partial class LoginPage : ContentPage
	{
        public LoginPage()
		{
			InitializeComponent();
			BackgroundColor = Color.White;
		}

		async void OnLoginClick(object sender, EventArgs e)
		{
            if (!validate(usernameEntry.Text, passwordEntry.Text)) {
                return;
            }
         
            // demo purposes. else construct an actual request
			CredentialRequest request = new CredentialRequest
			{
				ImpersonateUsername = "javantan",
				Username = "javantan",
				Password = "p75xe80wh$URdD*ClS16",
			};

			if (await AuthorityManager.Instance.RequestAuthenticationToken(request))
			{
				await Navigation.PopModalAsync();
			}
		}

		private bool validate(string username, string password)
		{
			if (!(username == null || password == null || username == "" || password == ""))
			{
				return true;
			}
			return false;
		}
	}
}
