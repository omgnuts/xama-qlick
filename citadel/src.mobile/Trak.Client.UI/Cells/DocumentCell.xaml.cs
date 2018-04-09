using Trak.Client.Portable;
using Trak.Client.Portable.Models;
using Trak.Client.UI.Theme;
using Xamarin.Forms;

namespace Trak.Client.UI
{
	public partial class DocumentCell : ViewCell
	{
		public static readonly BindableProperty SelfProperty =
			BindableProperty.Create("Self", typeof(StageItem), typeof(DocumentCell), null);

        public StageItem Self
		{
            get { return (StageItem)GetValue(SelfProperty); }
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
                lblDescription.Text = Self.StageItemTxn != null ? 
                    Self.StageItemTxn.TxnDT.ToString() : instruction;
			}

		}

        const string instruction = "Awaiting approval/document upload";
	}
}
