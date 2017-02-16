using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Qlick.Client.Portable;
using Humanizer;

namespace Qlick.Client.UI
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
				lblUserId.Text = "@" + Self.UserId;
				lblCreatedDT.Text = Self.CreatedDT.Humanize();
				lblDueDT.Text = Self.DueDT.Humanize();

				lblSystId.Text = Self.SystId;
				lblSystIdLetter.Text = Self.SystId[0].ToString().ToUpper();
			}
		}
	}
}
