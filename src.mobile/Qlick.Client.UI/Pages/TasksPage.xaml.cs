using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Qlick.Client.Portable;

namespace Qlick.Client.UI
{

	public partial class TasksPage : ContentPage
	{
		public TasksPage()
		{
			InitializeComponent();

			Label header = new Label
			{
				Text = "Quick View",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center,
				Margin = new Thickness(0, 10, 0, 10)
			};


			List<TaskItem> tasks = MockFactory.GenerateMockTasks();

			var dataTemplate = new DataTemplate(typeof(TaskItemCell));

			var listView = new ListView()
			{
				ItemsSource = tasks,
				ItemTemplate = dataTemplate,
				RowHeight = 50,
				HasUnevenRows = true,
			};

			listView.ItemTapped += OnTapListener;

			Content = new StackLayout
			{
				Padding = new Thickness(0, 20, 0, 0),
				Children = {
					header,
					listView
				}
			};
		}


		void OnTapListener(object sender, ItemTappedEventArgs e)
		{
			DisplayAlert("ItemTapped", e.Item.ToString(), "Ok");
		}

	}


	class AppView : StackLayout
	{
		//public static readonly BindableProperty FoobarProperty = BindableProperty.Create<AppView, bool>(p => p.Foobar, false);

		//public bool Foobar
		//		{
		//			get
		//			{
		//				return (bool)GetValue(FoobarProperty);
		//			}
		//			set
		//			{
		//				SetValue(FoobarProperty, value);
		//			}
		//		}

		//protected override void OnPropertyChanged(string propertyName)
		//{
		//	base.OnPropertyChanged(propertyName);

		//	switch (propertyName)
		//	{
		//		case "Foobar":
		//			UpdateFoobar();
		//			break;
		//	}
		//}


		public AppView()
		{
			BoxView boxView = new BoxView
			{
				Color = Color.Yellow,
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			Children.Add(boxView);
		}

	}


	class TaskItemCell : ViewCell
	{
		public TaskItemCell()
		{
			//var lblApp = new AppView()
			//{

			//};

			//lblApp.SetBinding(lblApp.TextProperty, "AppId");

			var stateText = new Label();
			stateText.SetBinding(Label.TextProperty, "Title");

			var cityText = new Label();
			cityText.SetBinding(Label.TextProperty, "Description");

			View = new StackLayout()
			{
				Orientation = StackOrientation.Vertical,
				Children =
				{
					stateText,
					cityText
				}
			};

		}
	}
}
