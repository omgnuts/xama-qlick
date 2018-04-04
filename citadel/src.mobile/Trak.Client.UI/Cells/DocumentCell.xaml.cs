using Trak.Client.Portable;

using Xamarin.Forms;

namespace Trak.Client.UI
{
	public partial class DocumentCell : ViewCell
	{
		public static readonly BindableProperty SelfProperty =
			BindableProperty.Create("Self", typeof(Document), typeof(DocumentCell), null);

		public Document Self
		{
			get { return (Document)GetValue(SelfProperty); }
			set { SetValue(SelfProperty, value); }
		}

		public DocumentCell()
		{
			InitializeComponent();
			lblTitle.TextColor = Styles.ThemeColor;
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
