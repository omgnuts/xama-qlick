using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Trak.Client.UI;
using Trak.Client.UI.Views;
using Trak.iOS.Renderers;
using CoreGraphics;
using UIKit;
using Foundation;

[assembly: ExportRenderer(typeof(JourneyView), typeof(JourneyViewRenderer))]

namespace Trak.iOS.Renderers
{
	public class JourneyViewRenderer : ViewRenderer<JourneyView, UIView>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<JourneyView> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				if (Control == null)
				{
					SetNativeControl(new UIView());
				}
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (Control == null || Element == null)
			{
				return;
			}

			if (e.PropertyName == "Renderer")
			{
				if (Jvalues == null || !Jvalues.IsEqual(Element.Journey)) {
					Jvalues = Element.Journey;
					SetNeedsDisplay();
				}
			}

			//else if (e.PropertyName == JourneyView.JourneyProperty.PropertyName)
			//{

			//}
		}

		JourneyView.JourneyValues Jvalues;

		public override void Draw(CGRect rect)
		{
			JourneyView.JourneyValues values = Element.Journey;

			nfloat width = (Bounds.Width - gapSz * (values.PathSize - 1)) / values.PathSize;
			nfloat height = Bounds.Height;
			nfloat widthGap = width + gapSz;

			using (var context = UIGraphics.GetCurrentContext())
			{
				for (int c = 0; c < values.PathSize; c++)
				{
					CGColor color;
					if (c < values.PathIndx)
					{
						color = COLOR_PREV;
					}
					else if (c == values.PathIndx)
					{
						color = COLOR_CURR;
					}
					else
					{
						color = COLOR_NEXT;
					}

					context.SetFillColor(color);
					context.AddPath(CGPath.FromRect(new CGRect(widthGap * c, 0, width, height)));
					context.DrawPath(CGPathDrawingMode.Fill);
				}


			}
		}

		static readonly nfloat gapSz = 2.0f;

		static readonly CGColor COLOR_PREV = Styles.ColorBlue.ToCGColor();
		static readonly CGColor COLOR_CURR = Styles.ColorGreen.ToCGColor();
		static readonly CGColor COLOR_NEXT = Styles.ColorGray.ToCGColor();
	}
}
