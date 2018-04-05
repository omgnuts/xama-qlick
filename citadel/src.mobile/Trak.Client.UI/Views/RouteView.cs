using System;

using Trak.Client.Portable;
using Xamarin.Forms;

namespace Trak.Client.UI.Views
{
	public class RouteView : View
	{
		public static readonly BindableProperty RouteProperty =
			BindableProperty.Create("Route", typeof(RouteValues), typeof(RouteView), null);

		//Gets or sets the color of the progress bar
		public RouteValues Route
		{
			get { return (RouteValues) GetValue(RouteProperty); }
			set { SetValue(RouteProperty, value); }
		}

		public class RouteValues
		{
            public StageStatus Status; // current path
            public StagePosition Point;

			public bool IsEqual(RouteValues rv)
			{
				return Status == rv.Status && Point == rv.Point;
			}
		}
	}
}

