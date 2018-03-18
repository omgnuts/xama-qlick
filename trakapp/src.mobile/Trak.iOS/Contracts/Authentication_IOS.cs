using Foundation;
using Trak.Client.UI;
using Trak.iOS.DependencyService;
using Security;
using Xamarin.Forms;

[assembly: Dependency(typeof(Authentication_IOS))]
namespace Trak.iOS.DependencyService
{
	public class Authentication_IOS : IAuthentication
	{
		public bool StoreInKeychain(string key, string value)
		{
			var rec = new SecRecord(SecKind.GenericPassword)
			{
				Accessible = SecAccessible.WhenUnlockedThisDeviceOnly,
				Generic = NSData.FromString(key),
				ValueData = NSData.FromString(value)
			};

			SecKeyChain.Remove(rec);
			SecStatusCode err = SecKeyChain.Add(rec);

			if (err != SecStatusCode.Success)
			{
				return false;
			}

			return true;
		}

		public string GetFromKeychain(string key)
		{
			SecStatusCode res;
			var rec = new SecRecord(SecKind.GenericPassword)
			{
				Generic = NSData.FromString(key)
			};
			var match = SecKeyChain.QueryAsRecord(rec, out res);
			if (match != null)
			{
				return match.ValueData.ToString();
			}

			return null;
		}

		public bool RemoveFromKeychain(string key)
		{
			var rec = new SecRecord(SecKind.GenericPassword)
			{
				Generic = NSData.FromString(key)
			};

			var err = SecKeyChain.Remove(rec);

			if (err != SecStatusCode.Success || err != SecStatusCode.ItemNotFound)
			{
				return false;
			}

			return true;
		}

		public void PostNotificationName(string key)
		{
			NSNotificationCenter.DefaultCenter.PostNotificationName(key, null);
		}

		public Authentication_IOS()
		{
		}
	}
}
