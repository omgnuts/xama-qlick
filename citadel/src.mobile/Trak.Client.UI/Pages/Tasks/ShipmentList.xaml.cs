using System;
using Trak.Client.Portable.Models;
using Trak.Client.UI.Theme;
using Xamarin.Forms;

namespace Trak.Client.UI.Pages.Tasks
{
    public partial class ShipmentList : ContentPage
    {
        public ShipmentViewModel ViewModel
        {
            get { return BindingContext as ShipmentViewModel; }
        }

        public ShipmentList()
        {
            InitializeComponent();

            BindingContext = new ShipmentViewModel();

            listView.ItemTapped += OnItemTappedListener;
            listView.ItemSelected += OnItemSelectedListener;
        }

        bool started;
        void OnStart()
        {
            started = true;
            segmentControl.TintColor = Styles.ThemeColor;
            segmentControl.SelectedSegment = 1;

            ViewModel.RefreshCommand.Execute(null);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!started)
            {
                OnStart();
            }
        }

        void OnItemSelectedListener(object sender, SelectedItemChangedEventArgs e)
        {
            listView.SelectedItem = null;
        }

        void OnItemTappedListener(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new ShipmentPage((Shipment)e.Item));
        }

        void OnSegmentControlSelected(object o, EventArgs e)
        {
            switch (segmentControl.SelectedSegment)
            {
                case 0:
                    //ViewModel.PrioritySelected = Priority.High;
                    break;
                case 1:
                    //ViewModel.PrioritySelected = Priority.Normal;
                    break;
            }
        }

    }
}
