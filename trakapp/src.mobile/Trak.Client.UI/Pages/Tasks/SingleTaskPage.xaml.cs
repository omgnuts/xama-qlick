using System;
using System.Threading.Tasks;
using System.Text;
using System.Collections.Generic;
using Humanizer;
using Trak.Client.Portable;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using Plugin.Geolocator;

namespace Trak.Client.UI
{
	public partial class SingleTaskPage : ContentPage
	{
		public TaskItem Context
		{
			get { return BindingContext as TaskItem; }
		}

		readonly TaskItemViewModel viewModel;

		public SingleTaskPage(TaskItemViewModel viewModel, TaskItem task)
		{
			InitializeComponent();

			this.viewModel = viewModel;

			App.NavPage.BarBackgroundColor = Styles.ColorBlue;
			App.NavPage.BarTextColor = Color.White;

			BackgroundColor = Color.White;
			BindingContext = task;

			//initRoutes();

		}
		bool started = false;
		void OnStart()
		{
			started = true;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (!started)
			{
				OnStart();
			}
		}

		protected override void OnDisappearing()
		{
			App.NavPage.BarTextColor = Color.Black;
			base.OnDisappearing();
		}

		protected async override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			if (BindingContext != null)
			{
				//MoveToUserLocation();
				//Task.Run(() => MoveToUserLocation());

				Title = Context.Title;
				//header.BackgroundColor = taskColor;
				//lblSystId.TextColor = taskColor;
				//App.NavPage.Title = Context.Title;

				lblTitle.Text = Context.Title;
				lblUserCreated.Text = "@" + Context.UserId + " • " + Context.CreatedDT.Humanize();
				lblDescription.Text = Context.Description;
				//lblSystId.Text = Context.SystId;
				//lblDueDT.Text = "Delivery is due " + Context.DueDT.Humanize();
				//attachmentStack.IsVisible = true; //Context.SystId.Equals("Prism");

				initRoutes(Context.RouteItems);

				ParseDetails(Context.Details);

				await MoveToUserLocation();
			}
		}

		static double lblFontSizeMedium = Device.GetNamedSize(NamedSize.Small, typeof(Label));
		static double lblFontSizeSmall = Device.GetNamedSize(NamedSize.Micro, typeof(Label));

		void ParseDetails(string details) {

			if (details != null)
			{
				string[] pairs = details.Split(';');

				foreach (string pair in pairs)
				{
					string[] kv = pair.Split(':');

					detailStack.Children.Add(new Label()
					{
						Text = kv[0],
						FontSize = lblFontSizeSmall,
						FontAttributes = FontAttributes.Bold,
						TextColor = Color.Silver
					});
					detailStack.Children.Add(new Label()
					{
						Text = kv[1],
						FontSize = lblFontSizeMedium
					});
				}
			}
		}

		async Task MoveToUserLocation()
		{
			try
			{
				var locator = CrossGeolocator.Current;
				locator.DesiredAccuracy = 200;

				Plugin.Geolocator.Abstractions.Position posse = await locator.GetPositionAsync(timeoutMilliseconds: 20000);
				if (posse == null)
					return;

				// capitol towers
				//Position position = new Position(1.278150, 103.847611);

				mapView.MoveToRegion(MapSpan.FromCenterAndRadius(
					new Xamarin.Forms.Maps.Position(posse.Latitude, posse.Longitude), 
					Distance.FromMiles(20)).WithZoom(10));

				//var pin = new Pin()
				//{
				//	Position = position,
				//	Type = PinType.SavedPin,
				//	Label = "Cargo"
				//};
				//mapView.Pins.Add(pin);

				return;
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine("Unable to get location, may need to increase timeout: " + ex);
			}
		}

		void initRoutes(RouteItem[] routeItems)
		{
			if (routeItems != null)
			{
				List<RouteItem> items = new List<RouteItem>(routeItems);
				items.Sort((x, y) => y.Order.CompareTo(x.Order));
				listView.ItemsSource = items;
				listView.ItemSelected += OnItemSelectedListener;
				listView.ItemTapped += OnItemTappedListener;
				
			}
		}

		void OnItemSelectedListener(object sender, SelectedItemChangedEventArgs e)
		{
			listView.SelectedItem = null;
		}


		void OnItemTappedListener(object sender, ItemTappedEventArgs e)
		{
			//System.Diagnostics.Debug.WriteLine(sender);
			Navigation.PushAsync(new ContentPage());
		}
	}

}
