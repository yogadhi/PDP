using System;
using Xamarin.Forms;
using Shared.Services.Logs;
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

[assembly: ExportRenderer (typeof (cxPicker), typeof (cxPickerRenderer))]
public class cxPickerRenderer : PickerRenderer
{
#if __ANDROID__
	protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Picker> e)
	{
		try{
			base.OnElementChanged(e);

			if (this.Control == null) return;

			Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);

			var view = (cxPicker)Element;
			UpdateUi(view);
		}
		catch (System.Exception ex)
		{
			Insights.Send("OnElementChanged", ex);
		}
	}

	void UpdateUi(cxPicker view)
	{
		try{
			if(!string.IsNullOrEmpty(view.FontFamily)) {
				string filename = view.FontFamily;

				if(filename.LastIndexOf(".", System.StringComparison.Ordinal) != filename.Length - 4) {
					filename = string.Format("{0}.ttf", filename);
				}

				Control.Typeface = TrySetFont(filename);
			}

			if(view.FontSize > 0) {
				Control.TextSize = (float)view.FontSize;
			}

			if(view.TextColor != Xamarin.Forms.Color.Default) 
				Control.SetTextColor(view.TextColor.ToAndroid());

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
		catch (System.Exception ex)
		{
			Insights.Send("UpdateUi", ex);
		}
	}

	private Typeface TrySetFont(string fontName)
	{
		try
		{                
			return Typeface.CreateFromAsset(Forms.Context.Assets, "fonts/" + fontName);
		} 

		catch(Exception ex) {
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
    protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Picker> e)
    {
		try{
	        base.OnElementChanged(e);

	        var view = e.NewElement as cxPicker;

	        SetView(view);
		}
		catch (System.Exception ex)
		{
			Insights.Send("OnElementChanged", ex);
		}
    }

    protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
		try{
	        base.OnElementPropertyChanged(sender, e);

	        var view = Element as cxPicker;

	        if (view != null &&
	            e.PropertyName == cxPicker.FontFamilyProperty.PropertyName ||
	            e.PropertyName == cxPicker.FontSizeProperty.PropertyName ||
	            e.PropertyName == cxPicker.AlignmentProperty.PropertyName ||
	            e.PropertyName == cxPicker.TextColorProperty.PropertyName)
	        {
	            SetView(view);
	        }
		}
		catch (System.Exception ex)
		{
			Insights.Send("OnElementPropertyChanged", ex);
		}
    }

    private void UpdateUi(cxPicker view)
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

	        if (view.TextColor != Xamarin.Forms.Color.Default)
	            Control.TextColor = view.TextColor.ToUIColor();

	        switch (view.Alignment)
	        {
	            case TextAlignment.Center:
	                Control.TextAlignment = UITextAlignment.Center;
	                break;
	            case TextAlignment.End:
	                Control.TextAlignment = UITextAlignment.Right;
	                break;
	            case TextAlignment.Start:
	                Control.TextAlignment = UITextAlignment.Left;
	                break;
	        }
		}
		catch (System.Exception ex)
		{
			Insights.Send("UpdateUi", ex);
		}
    }

    private void SetBorder(cxPicker view)
    {
		try{
	        this.Control.BorderStyle = view.HasBorder ? UITextBorderStyle.RoundedRect : UITextBorderStyle.None;
		}
		catch (System.Exception ex)
		{
			Insights.Send("SetBorder", ex);
		}
    }

    private void SetView(cxPicker view)
    {
		try{
	        if (view == null)
	        {
	            return;
	        }

	        if (view != null)
	        {
	            this.UpdateUi(view);
	            this.SetBorder(view);
	            LayoutSubviews();
	            return;
	        }
	        LayoutSubviews();
		}
		catch (System.Exception ex)
		{
			Insights.Send("SetView", ex);
		}
    }
#endif
}
