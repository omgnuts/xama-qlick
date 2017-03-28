using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Trak.Client.UI.Views;
using Trak.iOS.Renderers;
using CoreGraphics;

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
					//UIColor color;

					//if (Element.PathCount <= 1)
					//{
					//	color = UIColor.Red;
					//}
					//else
					//{
					//	color = UIColor.Green;
					//}

					var progress = new UIView
					{
						//BackgroundColor = color
					};

					SetNativeControl(progress);
				}
			}

		}
		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			//if (Control == null || Element == null)
			//{
			//	System.Diagnostics.Debug.WriteLine(".... soemthign was null");
			//	System.Diagnostics.Debug.WriteLine(".... control = " + Control);
			//	System.Diagnostics.Debug.WriteLine(".... element = " + Element);
			//	return;
			//}

			//System.Diagnostics.Debug.WriteLine(".... e.PropertyName = " + e.PropertyName);
			//System.Diagnostics.Debug.WriteLine(".... JourneyView.PathCountProperty.PropertyName = " + JourneyView.PathCountProperty.PropertyName);

			//System.Diagnostics.Debug.WriteLine(".... Element.Garbage = " + Element.Garbage);

			if (e.PropertyName == JourneyView.PathCountProperty.PropertyName)
			{
				
				//Control.BackgroundColor = Element.PathCount == 0 ? UIColor.Red : UIColor.Green;
				//Control.BackgroundColor = UIColor.Red;
				//Control.BackgroundColor = Element.PathCount == 0 ? UIColor.Red : UIColor.Green;
			}
			//else if (e.PropertyName == JourneyView.PathCountProperty.PropertyName)
			//{
			//	Control.BackgroundColor = UIColor.Green;
			//}


			//if (Element.PathCount <= 1)
			//{
			//	Control.BackgroundColor = UIColor.Red;
			//}
			//else
			//{
			//	Control.BackgroundColor = UIColor.Green;
			//}


			//Control.BackgroundColor = UIColor.Green;

   			if (e.PropertyName == "Renderer")
				SetNeedsDisplay();
		}

		public override void Draw(CGRect rect)
		{
			UIColor color = (Element.PathCount <= 1) ? UIColor.Red : UIColor.Yellow;

			using (var context = UIGraphics.GetCurrentContext())
			{
				context.SetFillColor(color.CGColor);
				context.AddPath(CGPath.FromRect(Bounds));
				context.DrawPath(CGPathDrawingMode.FillStroke);
			}
		}
	}
}
