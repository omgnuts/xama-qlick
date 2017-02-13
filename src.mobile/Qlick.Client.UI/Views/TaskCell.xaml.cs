using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Qlick.Client.UI
{
	public partial class TaskCell : ViewCell
	{
    	public static readonly BindableProperty TitleProperty =
			BindableProperty.Create("Title", typeof(string), typeof(TaskCell), "Title");
		
    	public static readonly BindableProperty DescriptionProperty =
			BindableProperty.Create("Description", typeof(string), typeof(TaskCell), "Description");

	    public string Title
		{
			get { return (string)GetValue(TitleProperty); }
			set { SetValue(TitleProperty, value); }
		}

	    public string Description
		{
			get { return (string)GetValue(DescriptionProperty); }
			set { SetValue(DescriptionProperty, value); }
		}

		public TaskCell()
		{
			InitializeComponent();
		}


    	protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			if (BindingContext != null)
			{
				lblTitle.Text = Title;
				lblDescription.Text = Description;
			}
		}
	}
}
