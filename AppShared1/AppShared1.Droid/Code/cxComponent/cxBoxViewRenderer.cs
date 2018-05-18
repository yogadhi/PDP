using System;
using Xamarin.Forms;
using Shared.Services.Logs;
using Shared.Classes.Components;
#if __ANDROID__
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
#endif
#if __IOS__
using Xamarin.Forms.Platform.iOS;
using UIKit;
using CoreGraphics;
using CoreLocation;
using System.Drawing;
#endif

[assembly: ExportRendererAttribute(typeof(cxBoxView), typeof(cxBoxViewRenderer))]
#if __ANDROID__
public class cxBoxViewRenderer : BoxRenderer
{
    public cxBoxViewRenderer()
    {
        this.SetWillNotDraw(false);
    }

    public override void Draw(Canvas canvas)
    {
        cxBoxView boxv = (cxBoxView)this.Element;

        Rect rc = new Rect();
        GetDrawingRect(rc);

        Rect interior = rc;
        interior.Inset((int)boxv.StrokeThickness, (int)boxv.StrokeThickness);

        Paint p = new Paint()
        {
            Color = boxv.Color.ToAndroid(),
            AntiAlias = true,
        };

        canvas.DrawRoundRect(new RectF(interior), (float)boxv.CornerRadius, (float)boxv.CornerRadius, p);

        p.Color = boxv.Stroke.ToAndroid();
        p.StrokeWidth = (float)boxv.StrokeThickness;
        p.SetStyle(Paint.Style.Stroke);

        canvas.DrawRoundRect(new RectF(rc), (float)boxv.CornerRadius, (float)boxv.CornerRadius, p);
    }
}
#endif

#if __IOS__
public class cxBoxViewRenderer : ViewRenderer<cxBoxView, UIView>
	{
		UIView childView;

        protected override void OnElementChanged(ElementChangedEventArgs<cxBoxView> e)
		{
			base.OnElementChanged(e);

			var boxv = e.NewElement;
			if (boxv != null) {
				var shadowView = new UIView();

				childView = new UIView() {
					BackgroundColor = boxv.Color.ToUIColor(),
					Layer = {
						CornerRadius = (float)boxv.CornerRadius,
						BorderColor = boxv.Stroke.ToCGColor(),
						BorderWidth = (float)boxv.StrokeThickness,
						MasksToBounds = true
					},
					AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight
				};

				shadowView.Add(childView);

				if (boxv.HasShadow) {
					shadowView.Layer.ShadowColor = UIColor.Black.CGColor;
					shadowView.Layer.ShadowOffset = new SizeF(3, 3);
					shadowView.Layer.ShadowOpacity = 1;
					shadowView.Layer.ShadowRadius = 5;
				}

				SetNativeControl(shadowView);
			}
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == cxBoxView.CornerRadiusProperty.PropertyName)
				childView.Layer.CornerRadius = (float)this.Element.CornerRadius;
            else if (e.PropertyName == cxBoxView.StrokeProperty.PropertyName)
				childView.Layer.BorderColor = this.Element.Stroke.ToCGColor();
            else if (e.PropertyName == cxBoxView.StrokeThicknessProperty.PropertyName)
				childView.Layer.BorderWidth = (float)this.Element.StrokeThickness;
			else if (e.PropertyName == BoxView.ColorProperty.PropertyName)
				childView.BackgroundColor = this.Element.Color.ToUIColor();
            else if (e.PropertyName == cxBoxView.HasShadowProperty.PropertyName)
            {
				if (Element.HasShadow) {
					NativeView.Layer.ShadowColor = UIColor.Black.CGColor;
					NativeView.Layer.ShadowOffset = new SizeF(3, 3);
					NativeView.Layer.ShadowOpacity = 1;
					NativeView.Layer.ShadowRadius = 5;
				}
				else {
					NativeView.Layer.ShadowColor = UIColor.Clear.CGColor;
					NativeView.Layer.ShadowOffset = new SizeF();
					NativeView.Layer.ShadowOpacity = 0;
					NativeView.Layer.ShadowRadius = 0;
				}
			}
		}

	}

	public class RoundedBoxViewRendererV1 : BoxRenderer
    {
		public override void Draw(System.Drawing.RectangleF rect)
		{
            cxBoxView boxv = (cxBoxView)this.Element;

			using (var context = UIGraphics.GetCurrentContext()) {

				context.SetFillColor(boxv.Color.ToCGColor());
				context.SetStrokeColor(boxv.Stroke.ToCGColor());
				context.SetLineWidth((float)boxv.StrokeThickness);

				var rc = this.Bounds.Inset((int)boxv.StrokeThickness, (int)boxv.StrokeThickness);

				float radius = (float)boxv.CornerRadius;
				radius = (float)Math.Max(0, Math.Min(radius, Math.Max(rc.Height / 2, rc.Width / 2)));

				var path = CGPath.FromRoundedRect(rc, radius, radius);
				context.AddPath(path);
				context.DrawPath(CGPathDrawingMode.FillStroke);
			}
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == cxBoxView.CornerRadiusProperty.PropertyName
                || e.PropertyName == cxBoxView.StrokeProperty.PropertyName
                || e.PropertyName == cxBoxView.StrokeThicknessProperty.PropertyName)
				this.SetNeedsDisplay();
		}
    }
#endif
