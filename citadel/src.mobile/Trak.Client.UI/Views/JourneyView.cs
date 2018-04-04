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

