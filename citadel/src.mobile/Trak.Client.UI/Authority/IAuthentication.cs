﻿namespace Trak.Client.UI
{
	public interface IAuthentication
	{
		bool StoreInKeychain(string key, string value);
		string GetFromKeychain(string key);
		bool RemoveFromKeychain(string key);
		void PostNotificationName(string key);
	}
}
