using System;
using System.Drawing;
using System.ComponentModel;
using Xamarin.Forms;
using Shared.Services.Logs;
using Shared.Classes.Components;
#if __ANDROID__
using System.Timers;
using System.Reflection;
using Xamarin.Forms.Platform.Android;
using Java.Lang;
using Android.Widget;
using Android.Views;
using Android.Graphics;
using Android.Support.V4.View;
#endif
#if __IOS__
using Xamarin.Forms.Platform.iOS;
using Foundation;
using UIKit;
#endif

[assembly:ExportRenderer(typeof(cxCarouselView), typeof(cxCarouselViewRenderer))]

public class cxCarouselViewRenderer : ScrollViewRenderer
{
#if __ANDROID__
        int _prevScrollX;
        int _deltaX;
        bool _motionDown;
        Timer _deltaXResetTimer;
        Timer _scrollStopTimer;
        HorizontalScrollView _scrollView;

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			try{
		        base.OnElementChanged(e);
		        if (e.NewElement == null) return;

		        _deltaXResetTimer = new Timer(100) { AutoReset = false };
		        _deltaXResetTimer.Elapsed += (object sender, ElapsedEventArgs args) => _deltaX = 0;

		        _scrollStopTimer = new Timer(200) { AutoReset = false };
		        _scrollStopTimer.Elapsed += (object sender, ElapsedEventArgs args2) => UpdateSelectedIndex();

		        e.NewElement.PropertyChanged += ElementPropertyChanged;
			}
			catch (System.Exception ex)
			{
				Insights.Send("OnElementChanged", ex);
			}
        }

        void ElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
			try{
	            if (e.PropertyName == "Renderer")
	            {
	                _scrollView = (HorizontalScrollView)typeof(ScrollViewRenderer)
	                    .GetField("hScrollView", BindingFlags.NonPublic | BindingFlags.Instance)
	                    .GetValue(this);

	                _scrollView.HorizontalScrollBarEnabled = false;
	                _scrollView.Touch += HScrollViewTouch;
	            }
	            if (e.PropertyName == cxCarouselView.SelectedIndexProperty.PropertyName && !_motionDown)
	            {
	                ScrollToIndex(((cxCarouselView)this.Element).SelectedIndex);
	            }
			}
			catch (System.Exception ex)
			{
				Insights.Send("ElementPropertyChanged", ex);
			}
        }

        void HScrollViewTouch(object sender, TouchEventArgs e)
        {
			try{
				e.Handled = false;

	            switch (e.Event.Action)
	            {
	                case MotionEventActions.Move:
	                    _deltaXResetTimer.Stop();
	                    _deltaX = _scrollView.ScrollX - _prevScrollX;
	                    _prevScrollX = _scrollView.ScrollX;

	                    UpdateSelectedIndex();

	                    _deltaXResetTimer.Start();
	                    break;
	                case MotionEventActions.Down:
	                    _motionDown = true;
	                    _scrollStopTimer.Stop();
	                    break;
	                case MotionEventActions.Up:
	                    _motionDown = false;
	                    SnapScroll();
	                    _scrollStopTimer.Start();
	                    break;
	            }
			}
			catch (System.Exception ex)
			{
				Insights.Send("HScrollViewTouch", ex);
			}
        }

        void UpdateSelectedIndex()
        {
			try{
	            var center = _scrollView.ScrollX + (_scrollView.Width / 2);
	            var cxCarouselView = (cxCarouselView)this.Element;
	            cxCarouselView.SelectedIndex = (center / _scrollView.Width);
			}
			catch (System.Exception ex)
			{
				Insights.Send("UpdateSelectedIndex", ex);
			}
        }

        void SnapScroll()
        {
			try{
	            var roughIndex = (float)_scrollView.ScrollX / _scrollView.Width;

	            var targetIndex =
	                _deltaX < 0 ? Java.Lang.Math.Floor(roughIndex)
	                : _deltaX > 0 ? Java.Lang.Math.Ceil(roughIndex)
	                : Java.Lang.Math.Round(roughIndex);

	            ScrollToIndex((int)targetIndex);
			}
			catch (System.Exception ex)
			{
				Insights.Send("SnapScroll", ex);
			}
        }

        void ScrollToIndex(int targetIndex)
        {
			try{
	            var targetX = targetIndex * _scrollView.Width;
	            _scrollView.Post(new Runnable(() =>
	            {
	                _scrollView.SmoothScrollTo(targetX, 0);
	            }));
			}
			catch (System.Exception ex)
			{
				Insights.Send("ScrollToIndex", ex);
			}
        }

        bool _initialized = false;
        public override void Draw(Canvas canvas)
        {
			try{
	            base.Draw(canvas);
	            if (_initialized) return;
	            _initialized = true;
	            var cxCarouselView = (cxCarouselView)this.Element;
	            _scrollView.ScrollTo(cxCarouselView.SelectedIndex * Width, 0);
			}
			catch (System.Exception ex)
			{
				Insights.Send("Draw", ex);
			}
        }

        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
			try{
	            if (_initialized && (w != oldw))
	            {
	                _initialized = false;
	            }
	            base.OnSizeChanged(w, h, oldw, oldh);
			}
			catch (System.Exception ex)
			{
				Insights.Send("OnSizeChanged", ex);
			}
        }
#endif

#if __IOS__
    UIScrollView _native;

    public cxCarouselViewRenderer()
    {
        try
        {
            PagingEnabled = true;
            ShowsHorizontalScrollIndicator = false;
        }
        catch (System.Exception ex)
        {
            Insights.Send("cxCarouselViewRenderer", ex);
        }
    }

    protected override void OnElementChanged(VisualElementChangedEventArgs e)
    {
        try
        {
            base.OnElementChanged(e);

            if (e.OldElement != null) return;

            _native = (UIScrollView)NativeView;
            _native.Scrolled += NativeScrolled;
            e.NewElement.PropertyChanged += ElementPropertyChanged;
        }
        catch (System.Exception ex)
        {
            Insights.Send("OnElementChanged", ex);
        }
    }

    void NativeScrolled(object sender, EventArgs e)
    {
        try
        {
            var center = _native.ContentOffset.X + (_native.Bounds.Width / 2);
            ((cxCarouselView)Element).SelectedIndex = ((int)center) / ((int)_native.Bounds.Width);
        }
        catch (System.Exception ex)
        {
            Insights.Send("NativeScrolled", ex);
        }
    }

    void ElementPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        try
        {
            if (e.PropertyName == cxCarouselView.SelectedIndexProperty.PropertyName && !Dragging)
            {
                ScrollToSelection(false);
            }
        }
        catch (System.Exception ex)
        {
            Insights.Send("ElementPropertyChanged", ex);
        }
    }

    void ScrollToSelection(bool animate)
    {
        try
        {
            if (Element == null) return;

            _native.SetContentOffset(new CoreGraphics.CGPoint
                (_native.Bounds.Width *
                    Math.Max(0, ((cxCarouselView)Element).SelectedIndex),
                    _native.ContentOffset.Y),
                animate);
        }
        catch (System.Exception ex)
        {
            Insights.Send("ScrollToSelection", ex);
        }
    }

    public override void Draw(CoreGraphics.CGRect rect)
    {
        try
        {
            base.Draw(rect);
            ScrollToSelection(false);
        }
        catch (System.Exception ex)
        {
            Insights.Send("Draw", ex);
        }
    }
#endif
}