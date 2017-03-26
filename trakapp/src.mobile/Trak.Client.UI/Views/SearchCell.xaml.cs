using System;
using System.Collections.Generic;
using Trak.Client.Portable;

using Xamarin.Forms;

namespace Trak.Client.UI
{
	public partial class SearchCell : ViewCell
	{
    	public static readonly BindableProperty SelfProperty =
			BindableProperty.Create("Self", typeof(SearchItem), typeof(SearchCell), null);

		public SearchItem Self
		{
			get { return (SearchItem)GetValue(SelfProperty); }
			set { SetValue(SelfProperty, value); }
		}

		public SearchCell()
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
				lblDescription.Text = Self.Description;
			}
		}

	}
}
