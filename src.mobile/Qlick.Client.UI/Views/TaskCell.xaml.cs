using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Qlick.Client.Portable;

namespace Qlick.Client.UI
{
	public partial class TaskCell : ViewCell
	{
    	public static readonly BindableProperty SelfProperty =
			BindableProperty.Create("Self", typeof(TaskItem), typeof(TaskCell), null);


		//public static readonly BindableProperty TitleProperty =
		//	BindableProperty.Create("Title", typeof(string), typeof(TaskCell), "Title");
		
  //  	public static readonly BindableProperty DescriptionProperty =
		//	BindableProperty.Create("Description", typeof(string), typeof(TaskCell), "Description");

	    public TaskItem Self
		{
			get { return (TaskItem)GetValue(SelfProperty); }
			set { SetValue(SelfProperty, value); }
		}

		public TaskCell()
		{
			InitializeComponent();
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
