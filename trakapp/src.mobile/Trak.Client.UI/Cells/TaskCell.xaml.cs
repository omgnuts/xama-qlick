using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Trak.Client.Portable;
using Trak.Client.UI.Views;
using Humanizer;

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
			lblTitle.TextColor = Styles.ThemeColor;

		}

    	protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			if (BindingContext != null && Self != null)
			{
				Color pc = PantoneColor.FromString(Self.SystId);
				lblTitle.TextColor = pc;
				lblSystId.TextColor = pc;
				lblSystIdLetter.BackgroundColor = pc;

				lblTitle.Text = Self.Title;
				lblDescription.Text = Self.Description;
				lblUserCreated.Text = "@" + Self.UserId + " • " + Self.CreatedDT.Humanize();
				lblDueDT.Text = "Due " + Self.DueDT.Humanize();

				lblSystId.Text = Self.SystId;
				lblSystIdLetter.Text = Self.SystId[0].ToString().ToUpper();

				if (Self.SystId == "prism")
				{
					joView.Journey = new JourneyView.JourneyValues
					{
						PathIndx = 2,
						PathSize = 5
					};
				}
				else
				{
					joView.Journey = new JourneyView.JourneyValues
					{
						PathIndx = 3,
						PathSize = 8
					};
				}


			}
		}
	}
}
