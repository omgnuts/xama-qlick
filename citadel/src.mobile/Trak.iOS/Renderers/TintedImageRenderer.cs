using System.ComponentModel;
using Trak.Client.UI;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Trak.iOS.Renderers;

[assembly: ExportRenderer(typeof(TintedImage), typeof(TintedImageRenderer))]
namespace Trak.iOS.Renderers
{
	public class TintedImageRenderer : ImageRenderer
	{
		protected new TintedImage Element => (TintedImage)base.Element;

		protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement == null) return;

			SetTint();
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			if (e.PropertyName == TintedImage.TintColorProperty.PropertyName)
				SetTint();
		}

		private void SetTint()
		{
			if (Element.TintColor == Color.Transparent)
			{
				if (Control.Image != null)
					Control.Image = Control.Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
				Control.TintColor = null;
			}
			else
			{
				if (Control.Image != null)
					Control.Image = Control.Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
				Control.TintColor = Element.TintColor.ToUIColor();
			}
		}
	}
}
