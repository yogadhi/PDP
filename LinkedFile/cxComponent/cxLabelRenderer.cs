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

[assembly: ExportRenderer(typeof(cxLabel), typeof(cxLabelRenderer))]
public class cxLabelRenderer : LabelRenderer
{
#if __ANDROID__
    private Typeface fontLaneNarrow = Typeface.CreateFromAsset(Forms.Context.Assets, "fonts/OpenSans-Light.ttf");
    private Typeface fontLaneNarrows = Typeface.Create("sans-serif-light", TypefaceStyle.Normal);

    protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Label> e)
    {
		try{
	        base.OnElementChanged(e);

	        //if (this.Control == null) return;

	        //Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
	        //Control.SetTextColor (global::Android.Graphics.Color.Gray);
	        //Control.SetTextSize (ComplexUnitType.Sp, 18);
	        //Control.SetTypeface (fontLaneNarrow, TypefaceStyle.Normal);

	        var view = (cxLabel)Element;
	        var control = Control;
	        UpdateUi(view, control);
		}
		catch (System.Exception ex)
		{
			Insights.Send("OnElementChanged", ex);
		}
    }

    void UpdateUi(cxLabel view, TextView control)
    {
		try{
	        if (!string.IsNullOrEmpty(view.FontFamily))
	        {
	            string filename = view.FontFamily;

	            if (filename.LastIndexOf(".", System.StringComparison.Ordinal) != filename.Length - 4)
	            {
	                filename = string.Format("{0}.ttf", filename);
	            }

	            control.Typeface = TrySetFont(filename);
	        }

	        if (view.FontSize > 0)
	        {
	            control.TextSize = (float)view.FontSize;
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

        catch (Exception ex)
        {
            Console.WriteLine("not found in assets. Exception: {0}", ex);
            try
            {
                return Typeface.CreateFromFile("fonts/" + fontName);
            }

            catch (Exception ex1)
            {
                Console.WriteLine("not found by file. Exception: {0}", ex1);
                return Typeface.Default;
            }
        }
    }
#endif

#if __IOS__
    protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
    {
		try{
	        base.OnElementChanged(e);

	        var view = e.NewElement as cxLabel;

	        //UpdateUi(view, this.Control);
	        if (view != null)
	        {
	            SetView(view);
	        }
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

	        var view = Element as cxLabel;

	        if (view != null &&
	            e.PropertyName == cxLabel.FontFamilyProperty.PropertyName ||
	            e.PropertyName == cxLabel.FontSizeProperty.PropertyName)
	        {
	            SetView(view);
	        }
		}
		catch (System.Exception ex)
		{
			Insights.Send("OnElementPropertyChanged", ex);
		}
    }

    private void UpdateUi(cxLabel view)
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

	        this.Control.AttributedText = new NSMutableAttributedString(view.Text, this.Control.Font);
		}
		catch (System.Exception ex)
		{
			Insights.Send("UpdateUi", ex);
		}
    }

    private void SetView(cxLabel view)
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
		catch (System.Exception ex)
		{
			Insights.Send("SetView", ex);
		}
    }
#endif

}
