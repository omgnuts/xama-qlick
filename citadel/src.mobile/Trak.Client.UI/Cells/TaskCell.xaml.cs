using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Trak.Client.Portable;
using Trak.Client.UI.Views;
using Humanizer;
using Trak.Client.UI.Theme;

namespace Trak.Client.UI
{
	public partial class TaskCell : ViewCell
	{
    	public static readonly BindableProperty SelfProperty =
			BindableProperty.Create("Self", typeof(TaskItem), typeof(TaskCell), null);

		public TaskItem Self
		{
			get { return (TaskItem)GetValue(SelfProperty); }
			set { SetValue(SelfProperty, value); }
		}

		public TaskCell()
		{
			InitializeComponent();
			//lblTitle.TextColor = Styles.ThemeColor;
		}

    	protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			if (BindingContext != null && Self != null)
			{
				//Color pc = PantoneColor.FromString(Self.SystId);
				//lblTitle.TextColor = pc;
				Color pc = Self.Priority == Priority.High ? Styles.ColorRed : Styles.ColorGreen;
				lblDueDTTime.TextColor = pc;
				lblDueDT.BackgroundColor = pc;

				lblTitle.Text = Self.Title;
				lblDescription.Text = Self.Description;
				lblUserCreated.Text = "@" + Self.UserId + " • " + Self.CreatedDT.Humanize();

				lblDueDT.Text = Self.DueDT.ToString("dd MMM").ToLower();
				lblDueDTTime.Text = Self.DueDT.ToString("HH:mm");

				joView.Journey = new JourneyView.JourneyValues
				{
					PathIndx = Self.JoIndex,
					PathSize = Self.JoSize
				};

			}
		}
	}
}
