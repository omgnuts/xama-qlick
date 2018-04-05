using Trak.Client.Portable.Models;
using Xamarin.Forms;

namespace Trak.Client.UI.Cells
{
    public partial class StageCell : ViewCell
    {
        public static readonly BindableProperty SelfProperty =
            BindableProperty.Create("Self", typeof(Stage), typeof(StageCell), null);

        public Stage Self
        {
            get { return (Stage)GetValue(SelfProperty); }
            set { SetValue(SelfProperty, value); }
        }

        public StageCell()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null && Self != null)
            {
                lblTitle.Text = Self.Title;
                lblSubtitle.Text = Self.SubTitle;

                roView.Route = new Views.RouteView.RouteValues
                {
                    Status = Self.Status,
                    Point = Self.Position(4),
                };
            }
        }
    }
}
