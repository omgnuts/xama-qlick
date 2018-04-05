using Humanizer;
using Trak.Client.Portable.Models;
using Trak.Client.UI.Views;
using Xamarin.Forms;

namespace Trak.Client.UI.Cells
{
    public partial class ShipmentCell : ViewCell
    {
        public static readonly BindableProperty SelfProperty =
            BindableProperty.Create("Self", typeof(Shipment), typeof(ShipmentCell), null);

        public Shipment Self
        {
            get { return (Shipment)GetValue(SelfProperty); }
            set { SetValue(SelfProperty, value); }
        }

        public ShipmentCell()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null && Self != null)
            {
                lblTitle.Text = Self.Title;
                lblUserCreated.Text = "@" + Self.CreatorId + " • " + Self.CreatedDT.Humanize();
                //lblDescription.Text = Self.Description;

                //lblDueDTTime.TextColor = Styles.ColorGreen;
                //lblDueDT.BackgroundColor = Styles.ColorGreen;
                //lblDueDT.Text = Self.CreatedDT.ToString("dd MMM").ToLower();
                //lblDueDTTime.Text = Self.CreatedDT.ToString("HH:mm");

                joView.Journey = new JourneyView.JourneyValues
                {
                    PathIndx = Self.CurrentStage,
                    PathSize = Self.TotalStages
                };

            }
        }
    }
}
