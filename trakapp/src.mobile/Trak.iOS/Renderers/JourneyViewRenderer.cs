using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Trak.Client.UI.Views;

using Trak.iOS.Renderers;
		  
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
					var progress = new UIView
					{
						BackgroundColor = UIColor.Blue
					};

					SetNativeControl(progress);

					System.Diagnostics.Debug.WriteLine("... Element changed");
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

			System.Diagnostics.Debug.WriteLine(".... e.PropertyName = " + e.PropertyName);
			////System.Diagnostics.Debug.WriteLine(".... JourneyView.PathCountProperty.PropertyName = " + JourneyView.PathCountProperty.PropertyName);

			//System.Diagnostics.Debug.WriteLine(".... Element.Garbage = " + Element.Garbage);

			if (e.PropertyName == JourneyView.PathCountProperty.PropertyName)
			{
				Control.BackgroundColor = UIColor.Red;
				//Control.BackgroundColor = Element.PathCount == 0 ? UIColor.Red : UIColor.Green;
			}
			//else if (e.PropertyName == JourneyView.PathCountProperty.PropertyName)
			//{
			//	Control.BackgroundColor = UIColor.Green;
			//}

			//Control.BackgroundColor = UIColor.Green;
		}

	}
}
