using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Humanizer;
using Plugin.Geolocator;
using Trak.Client.Portable;
using Trak.Client.Portable.Models;
using Trak.Client.UI.Theme;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Trak.Client.UI.Pages.Tasks
{
    public partial class ShipmentPage : ContentPage
    {
        public Shipment Context
        {
            get { return BindingContext as Shipment; }
        }

        public ShipmentPage(Shipment shipment)
        {
            InitializeComponent();

            App.NavPage.BarBackgroundColor = Styles.ColorBlue;
            App.NavPage.BarTextColor = Color.White;

            BackgroundColor = Color.White;
            BindingContext = shipment;

        }

        bool started = false;
        void OnStart()
        {
            started = true;
        }

        protected override void OnAppearing()
        {
            App.NavPage.BarTextColor = Color.White;
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
                Title = Context.Title;

                lblTitle.Text = Context.Title;
                lblUserCreated.Text = "@" + Context.CreatorId + " • " + Context.CreatedDT.Humanize();
                //lblDescription.Text = Context.Description;


                List<Stage> stages = StageFactory.GenerateDefaults();
                initStages(stages);

                //ParseDetails(Context.Details);
                detailStack.IsVisible = false;

                //await MoveToUserLocation();
            }
        }

        static double lblFontSizeMedium = Device.GetNamedSize(NamedSize.Small, typeof(Label));
        static double lblFontSizeSmall = Device.GetNamedSize(NamedSize.Micro, typeof(Label));

        void ParseDetails(string details)
        {
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
                detailStack.IsVisible = true;
            }
            else
            {
                detailStack.IsVisible = false;
            }
        }

        async Task MoveToUserLocation()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 200;

                Plugin.Geolocator.Abstractions.Position posse = await locator.GetPositionAsync(TimeSpan.FromMilliseconds(20000));
                if (posse == null)
                    return;

                // capitol towers
                //Position position = new Position(1.278150, 103.847611);

                mapView.MoveToRegion(MapSpan.FromCenterAndRadius(
                    new Xamarin.Forms.Maps.Position(posse.Latitude, posse.Longitude),
                    Distance.FromMiles(20)).WithZoom(10));

                //var pin = new Pin()
                //{
                //  Position = position,
                //  Type = PinType.SavedPin,
                //  Label = "Cargo"
                //};
                //mapView.Pins.Add(pin);

                return;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Unable to get location, may need to increase timeout: " + ex);
            }
        }

        void initStages(List<Stage> stages)
        {
            if (stages != null)
            {
                listView.ItemsSource = stages;
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
            Stage stage = (Stage)e.Item;

            //Navigation.PushAsync(new DocumentListPage(stage));

            //if (route.BlockChain != 0)
            //{
            //  Navigation.PushAsync(new RouteDetailPage(route));
            //}
            //else
            //{
            //             DisplayAlert("No Blockchain Information", "There are no blockchain details for this waypoint, as the cargo has not yet reached this location.", "OK");
            //}
        }
    }
}
