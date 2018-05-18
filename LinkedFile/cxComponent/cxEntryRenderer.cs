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
using Android.Text;
using Xamarin.Forms.Platform.Android;
#endif
#if __IOS__
using System.IO;
using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
#endif

[assembly: ExportRenderer (typeof (cxEntry), typeof (cxEntryRenderer))]
public class cxEntryRenderer : EntryRenderer
{
#if __ANDROID__
		// Override the OnElementChanged method so we can tweak this renderer post-initial setup
	protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
	{
		try{
			base.OnElementChanged(e);

			if (this.Control == null) return;

			Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
			var view = (cxEntry)Element;
			UpdateUi(view);
			SetMaxLength (view);
		}
		catch (System.Exception ex)
		{
			Insights.Send("OnElementChanged", ex);
		}
	}

	void UpdateUi(cxEntry view)
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

			if(view.PlaceholderTextColor != Xamarin.Forms.Color.Default) 
				Control.SetHintTextColor(view.PlaceholderTextColor.ToAndroid());

	        if (view.HasBorder != false)
	        {
	            //return;   
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

	private void SetMaxLength(cxEntry view)
	{
		try{
			Control.SetFilters(new IInputFilter[] { new global::Android.Text.InputFilterLengthFilter(view.MaxLength) });
		}
		catch (System.Exception ex)
		{
			Insights.Send("SetMaxLength", ex);
		}
	}
#endif

#if __IOS__
    protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
    {
		try{
	        base.OnElementChanged(e);

	        var view = e.NewElement as cxEntry;

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

	        var view = Element as cxEntry;

	        if (view != null &&
	            e.PropertyName == cxEntry.TextProperty.PropertyName ||
	            e.PropertyName == cxEntry.FontFamilyProperty.PropertyName ||
	            e.PropertyName == cxEntry.FontSizeProperty.PropertyName ||
	            e.PropertyName == cxEntry.PlaceholderTextColorProperty.PropertyName ||
	            e.PropertyName == cxEntry.AlignmentProperty.PropertyName ||
	            e.PropertyName == cxEntry.MaxLengthProperty.PropertyName)
	        {
	            SetView(view);
	        }
		}
		catch (System.Exception ex)
		{
			Insights.Send("OnElementPropertyChanged", ex);
		}
    }

    private void UpdateUi(cxEntry view)
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

	        if (string.IsNullOrEmpty(view.Placeholder) == false && view.PlaceholderTextColor != Color.Default)
	        {
	            NSAttributedString placeholderString = new NSAttributedString(view.Placeholder, new UIStringAttributes() { ForegroundColor = view.PlaceholderTextColor.ToUIColor() });
	            this.Control.AttributedPlaceholder = placeholderString;
	        }

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

    private void SetView(cxEntry view)
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
	            this.SetMaxLength(view);
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

    private void SetBorder(cxEntry view)
    {
		try{
	        this.Control.BorderStyle = view.HasBorder ? UITextBorderStyle.RoundedRect : UITextBorderStyle.None;
		}
		catch (System.Exception ex)
		{
			Insights.Send("SetBorder", ex);
		}
    }

    private void SetMaxLength(cxEntry view)
    {
		try{
	        this.Control.ShouldChangeCharacters = (textField, range, replacementString) =>
	        {
	            var newLength = textField.Text.Length + replacementString.Length - range.Length;
	            return newLength <= view.MaxLength;
	        };
		}
		catch (System.Exception ex)
		{
			Insights.Send("SetMaxLength", ex);
		}
    }
#endif
}


