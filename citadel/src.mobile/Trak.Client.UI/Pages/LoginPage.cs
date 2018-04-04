
using System;
using Trak.Client.Portable;
using Xamarin.Forms;

namespace Trak.Client.UI
{

	public partial class LoginPage : ContentPage
	{
		public static readonly BindableProperty ThemeColorProperty =
			BindableProperty.Create(nameof(ThemeColor), typeof(string), typeof(LoginPage), "#0e95e0");

		public string ThemeColor
		{
			get { return (string)GetValue(ThemeColorProperty); }
			set { SetValue(ThemeColorProperty, value); }
		}

		public LoginPage()
		{
			BindingContext = this;

			InitializeComponent();
			BackgroundColor = Color.White;

		}

		async void OnLoginClick(object sender, EventArgs e)
		{
			CredentialRequest request = new CredentialRequest
			{
				ImpersonateUsername = "javantan",
				Username = "javantan",
				Password = "p75xe80wh$URdD*ClS16",
			};

			BlockSchema schema = new BlockSchema
			{
				Database = "db1",
				Schema = "sc1",
				Table = "tbl1"
			};

			if (await AuthorityManager.Instance.RequestAuthenticationToken(request))
			{
				CredentialToken token = AuthorityManager.Instance.Token;
				bool result = await TrakAPI.Instance.CoreCreate(schema, token);

				await Navigation.PopModalAsync();
			}

		}

		//private bool validate(string username, string password)
		//{
		//	if (!(username == null || password == null || username == "" || password == ""))
		//	{
		//		return PolicyManager.Save(username, password);
		//	}
		//	return false;
		//}

		//async void OnCancelClick(object sender, EventArgs e)
		//{
		//	await Navigation.PopModalAsync();
		//}

		//protected override void OnAppearing()
		//{
		//	base.OnAppearing();
		//	btnCancel.IsVisible = isCancellable;
		//}
	}
}
