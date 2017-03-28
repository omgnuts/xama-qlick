using System;

using Xamarin.Forms;

namespace Trak.Client.UI.Views
{
	public class JourneyView : View
	{
		public static readonly BindableProperty JourneyProperty =
			BindableProperty.Create("Journey", typeof(JourneyValues), typeof(JourneyView), null);

		//Gets or sets the color of the progress bar
		public JourneyValues Journey
		{
			get { return (JourneyValues) GetValue(JourneyProperty); }
			set { SetValue(JourneyProperty, value); }
		}

		//public static readonly BindableProperty PathCountProperty =	
		//	BindableProperty.Create("PathCount", typeof(int), typeof(JourneyView), 1);
		

		////Gets or sets the color of the progress bar
		//public int PathCount
		//{
		//	get { return (int) GetValue(PathCountProperty); }
		//	set { SetValue(PathCountProperty, value); }
		//}

		//public static readonly BindableProperty GarbageProperty = 
		//	BindableProperty.Create("Garbage", typeof(string), typeof(JourneyView), "");

		//public string Garbage
		//{
		//	get { return (string)GetValue(GarbageProperty); }
		//	set { SetValue(GarbageProperty, value); }
		//}

		//protected override void OnPropertyChanged(string propertyName = null)
		//{
		//	System.Diagnostics.Debug.WriteLine("... propertyName = " + propertyName);
		//	base.OnPropertyChanged(propertyName);
		//}

		public class JourneyValues
		{
			public int PathIndx; // current path
			public int PathSize;

			public bool IsEqual(JourneyValues j)
			{
				return PathIndx == j.PathIndx && PathSize == j.PathSize;
			}
		}
	}
}

