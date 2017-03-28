﻿using System;
using System.Collections.Generic;
using Trak.Client.Portable;

using Xamarin.Forms;

namespace Trak.Client.UI
{
	public partial class RouteCell : ViewCell
	{
		public static readonly BindableProperty SelfProperty =
			BindableProperty.Create("Self", typeof(RouteItem), typeof(RouteCell), null);

		public RouteItem Self
		{
			get { return (RouteItem)GetValue(SelfProperty); }
			set { SetValue(SelfProperty, value); }
		}

		public RouteCell()
		{
			InitializeComponent();
			lblTitle.TextColor = Styles.ThemeColor;
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			if (BindingContext != null && Self != null)
			{
				lblTitle.Text = Self.Title;
				lblDepartDT.Text = Self.DepartDT;
				lblArriveDT.Text = Self.ArriveDT;

				if (Self.BlockChain != 0)
				{
					imgLock.Source = (Self.BlockChain > 0) ? "lock-secure.png" : "lock-broke.png";
				}

			}
		}

	}
}
