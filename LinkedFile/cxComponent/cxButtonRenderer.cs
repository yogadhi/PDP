using System;
using Xamarin.Forms;
using Shared.Classes.Components;
#if __ANDROID__
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Util;
using Xamarin.Forms.Platform.Android;
#endif
#if __IOS__
using System.IO;
using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
#endif

[assembly: ExportRenderer (typeof (cxButton), typeof (cxButtonRenderer))]
public class cxButtonRenderer : ButtonRenderer
{
#if __ANDROID__
	protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
	{
		try{
			base.OnElementChanged(e);

			if (this.Control == null) return;

			var view = (cxButton)Element;
			UpdateUi(view);
		}
		catch (Exception ex)
		{
			Shared.Services.Logs.Insights.Send("OnElementChanged", ex);
		}
	}

	void UpdateUi(cxButton view)
	{
		try{
			if(!string.IsNullOrEmpty(view.FontFamily)) {
				string filename = view.FontFamily;

				if(filename.LastIndexOf(".", System.StringComparison.Ordinal) != filename.Length - 4) {
					filename = string.Format("{0}.ttf", filename);
				}

				Control.Typeface = TrySetFont(filename);
			}

			switch (view.Alignment)
			{
			case Xamarin.Forms.TextAlignment.Center:
				Control.Gravity = GravityFlags.CenterHorizontal;
				break;
			case Xamarin.Forms.TextAlignment.End:
				Control.Gravity = GravityFlags.End;
				break;
			case Xamarin.Forms.TextAlignment.Start:
				Control.Gravity = GravityFlags.Start;
				break;
			}
		}
		catch (Exception ex)
		{
            Shared.Services.Logs.Insights.Send("UpdateUi", ex);
		}
	}

	private Typeface TrySetFont(string fontName)
	{
		try
		{                
			return Typeface.CreateFromAsset(Forms.Context.Assets, "fonts/" + fontName);
		} 

		catch(Exception ex) {
            Shared.Services.Logs.Insights.Send("TrySetFont", ex);
			Console.WriteLine("not found in assets. Exception: {0}", ex);
			try 
			{
				return Typeface.CreateFromFile("fonts/" + fontName);
			} 

			catch(Exception ex1)
			{
				Console.WriteLine("not found by file. Exception: {0}", ex1);
				return Typeface.Default;
			}
		}
    }
#endif

#if __IOS__
     protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
    {
		try{
	        base.OnElementChanged(e);

	        var view = e.NewElement as cxButton;

	        //UpdateUi(view, this.Control);
	        if (view != null)
	        {
	            SetView(view);
	        }
		}
		catch (Exception ex)
		{
			Shared.Services.Logs.Insights.Send("OnElementChanged", ex);
		}
    }

    protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
		try{
	        base.OnElementPropertyChanged(sender, e);

	        var view = Element as cxButton;

	        if (view != null &&
	            e.PropertyName == cxButton.TextProperty.PropertyName ||
	            e.PropertyName == cxButton.FontFamilyProperty.PropertyName ||
	            e.PropertyName == cxButton.FontSizeProperty.PropertyName)
	        {
	            SetView(view);
	        }
		}
		catch (Exception ex)
		{
			Shared.Services.Logs.Insights.Send("OnElementPropertyChanged", ex);
		}
    }

    private void UpdateUi(cxButton view)
    {
		try{
	        if (view.FontSize > 0)
	        {
	            this.Control.Font = UIFont.FromName(this.Control.Font.Name, (float)view.FontSize);
	        }

	        if (!string.IsNullOrEmpty(view.FontFamily))
	        {
	            var fontName = Path.GetFileNameWithoutExtension(view.FontFamily);

	            var font = UIFont.FromName(fontName, this.Control.Font.PointSize);

	            if (font != null)
	            {
	                this.Control.Font = font;
	            }
	        }

	        switch (view.Alignment)
			{
	            case Xamarin.Forms.TextAlignment.Center:
	                this.Control.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
	                break;
	            case Xamarin.Forms.TextAlignment.End:
	                this.Control.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
	                break;
	            case Xamarin.Forms.TextAlignment.Start:
	                this.Control.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
	                break;
			}
		}
		catch (Exception ex)
		{
			Shared.Services.Logs.Insights.Send("UpdateUi", ex);
		}
    }

    private void SetView(cxButton view)
    {
	try{
        if (view == null)
        {
            return;
        }

        if (!string.IsNullOrEmpty(view.Text))
        {
            this.UpdateUi(view);
            LayoutSubviews();
            return;
        }
        LayoutSubviews();
	}
	catch (Exception ex)
	{
		Shared.Services.Logs.Insights.Send("SetView", ex);
	}
    }
#endif
}

