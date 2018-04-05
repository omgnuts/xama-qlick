using System;
using System.ComponentModel;
using CoreGraphics;
using Trak.Client.UI.Theme;
using Trak.Client.UI.Views;
using Trak.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(RouteView), typeof(RouteViewRenderer))]

namespace Trak.iOS.Renderers
{
	public class RouteViewRenderer : ViewRenderer<RouteView, UIView>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<RouteView> e)
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
				if (Rvalues == null || !Rvalues.IsEqual(Element.Route)) {
					Rvalues = Element.Route;
					SetNeedsDisplay();
				}
			}

			//else if (e.PropertyName == JourneyView.JourneyProperty.PropertyName)
			//{

			//}
		}

		RouteView.RouteValues Rvalues;

		public override void Draw(CGRect rect)
		{
			CGColor color;
			if (Rvalues.Status < 0)
			{
				color = COLOR_PREV;
			}
			else if (Rvalues.Status == 0)
			{
				color = COLOR_CURR;
			}
			else // Rvalues.Status > 0
			{
				color = COLOR_NEXT;
			}

			using (var context = UIGraphics.GetCurrentContext())
			{
				nfloat left = (Bounds.Width - barWidth) * 0.5f;
				nfloat height = (Rvalues.Point == 0) ? Bounds.Height : Bounds.Height * 0.5f;
				nfloat top = (Rvalues.Point >= 0) ? 0 : Bounds.Height * 0.5f;

				nfloat circle = (Rvalues.Point == 0) ? circleSmall : circleLarge;
				nfloat cLeft = (Bounds.Width - circle) * 0.5f;
				nfloat cTop = (Bounds.Height - circle) * 0.5f;

				context.SetFillColor(color);
				context.AddPath(CGPath.FromRect(new CGRect(left, top, barWidth, height)));
				context.AddEllipseInRect(new CGRect(cLeft, cTop, circle, circle));
				context.DrawPath(CGPathDrawingMode.Fill);

			}
		}

		static readonly nfloat barWidth = 5.0f;
		static readonly nfloat circleSmall = 25.0f;
		static readonly nfloat circleLarge = 40.0f;

		static readonly CGColor COLOR_PREV = Styles.ColorBlue.ToCGColor();
		static readonly CGColor COLOR_CURR = Styles.ColorGreen.ToCGColor();
		static readonly CGColor COLOR_NEXT = Styles.ColorGray.ToCGColor();
	}
}
