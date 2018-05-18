using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Xamarin.Forms;

namespace Shared.Classes.Components
{
    #region cxRootPage
    public class cxRootPage : MasterDetailPage
    {
        public static readonly BindableProperty DrawerWidthProperty = BindableProperty.Create<cxRootPage, int>(p => p.DrawerWidth, default(int));

        public int DrawerWidth
        {
            get { return (int)GetValue(DrawerWidthProperty); }
            set { SetValue(DrawerWidthProperty, value); }
        }
    }
    #endregion

    #region cxButton
    public class cxButton : Button
    {
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create<cxButton, string>(p => p.FontFamily, string.Empty);
        public static readonly BindableProperty AlignmentProperty = BindableProperty.Create("Alignment", typeof(TextAlignment), typeof(cxButton), TextAlignment.Center);

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public TextAlignment Alignment
        {
            get { return (TextAlignment)GetValue(AlignmentProperty); }
            set { SetValue(AlignmentProperty, value); }
        }
    }
    #endregion

    #region cxLabel
    public class cxLabel : Label
    {
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create<cxLabel, string>(p => p.FontFamily, string.Empty);
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create<cxLabel, double>(p => p.FontSize, -1);

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }
    }
    #endregion

    #region cxEntry
    public class cxEntry : Entry
    {

        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create<cxEntry, string>(p => p.FontFamily, string.Empty);
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create<cxEntry, double>(p => p.FontSize, -1);
        public static readonly BindableProperty PlaceholderTextColorProperty = BindableProperty.Create("PlaceholderTextColor", typeof(Color), typeof(cxEntry), Color.Default);
        public static readonly BindableProperty AlignmentProperty = BindableProperty.Create("Alignment", typeof(TextAlignment), typeof(cxEntry), TextAlignment.Start);
        public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create("MaxLength", typeof(int), typeof(cxEntry), int.MaxValue);
        public static readonly BindableProperty HasBorderProperty = BindableProperty.Create("HasBorder", typeof(bool), typeof(cxEntry), false);

        public int MaxLength
        {
            get { return (int)this.GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public Color PlaceholderTextColor
        {
            get { return (Color)GetValue(PlaceholderTextColorProperty); }
            set { SetValue(PlaceholderTextColorProperty, value); }
        }

        public TextAlignment Alignment
        {
            get { return (TextAlignment)GetValue(AlignmentProperty); }
            set { SetValue(AlignmentProperty, value); }
        }

        public bool HasBorder
        {
            get { return (bool)GetValue(HasBorderProperty); }
            set { SetValue(HasBorderProperty, value); }
        }
    }
    #endregion

    #region cxEditor
    public class cxEditor : Editor
    {
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create<cxEditor, string>(p => p.FontFamily, string.Empty);
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create<cxEditor, double>(p => p.FontSize, -1);
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create("TextColor", typeof(Color), typeof(cxEditor), Color.Default);
        public static readonly BindableProperty AlignmentProperty = BindableProperty.Create("Alignment", typeof(TextAlignment), typeof(cxEditor), TextAlignment.Start);

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public TextAlignment Alignment
        {
            get { return (TextAlignment)GetValue(AlignmentProperty); }
            set { SetValue(AlignmentProperty, value); }
        }
    }
    #endregion

    #region cxPicker
    public class cxPicker : Picker
    {
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create<cxPicker, string>(p => p.FontFamily, string.Empty);
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create<cxPicker, double>(p => p.FontSize, -1);
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create("TextColor", typeof(Color), typeof(cxPicker), Color.Default);
        public static readonly BindableProperty AlignmentProperty = BindableProperty.Create("Alignment", typeof(TextAlignment), typeof(cxPicker), TextAlignment.Start);
        public static readonly BindableProperty HasBorderProperty = BindableProperty.Create("HasBorder", typeof(bool), typeof(cxEntry), false);

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public TextAlignment Alignment
        {
            get { return (TextAlignment)GetValue(AlignmentProperty); }
            set { SetValue(AlignmentProperty, value); }
        }

        public bool HasBorder
        {
            get { return (bool)GetValue(HasBorderProperty); }
            set { SetValue(HasBorderProperty, value); }
        }
    }
    #endregion

    #region cxDatePicker
    public class cxDatePicker : DatePicker
    {
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create<cxDatePicker, string>(p => p.FontFamily, string.Empty);
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create<cxDatePicker, double>(p => p.FontSize, -1);
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create("TextColor", typeof(Color), typeof(cxDatePicker), Color.Default);
        public static readonly BindableProperty AlignmentProperty = BindableProperty.Create("Alignment", typeof(TextAlignment), typeof(cxDatePicker), TextAlignment.Start);
        public static readonly BindableProperty HasBorderProperty = BindableProperty.Create("HasBorder", typeof(bool), typeof(cxEntry), false);

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public TextAlignment Alignment
        {
            get { return (TextAlignment)GetValue(AlignmentProperty); }
            set { SetValue(AlignmentProperty, value); }
        }

        public bool HasBorder
        {
            get { return (bool)GetValue(HasBorderProperty); }
            set { SetValue(HasBorderProperty, value); }
        }
    }
    #endregion

    #region cxTimePicker
    public class cxTimePicker : TimePicker
    {
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create<cxTimePicker, string>(p => p.FontFamily, string.Empty);
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create<cxTimePicker, double>(p => p.FontSize, -1);
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create("TextColor", typeof(Color), typeof(cxTimePicker), Color.Default);
        public static readonly BindableProperty AlignmentProperty = BindableProperty.Create("Alignment", typeof(TextAlignment), typeof(cxTimePicker), TextAlignment.Start);
        public static readonly BindableProperty HasBorderProperty = BindableProperty.Create("HasBorder", typeof(bool), typeof(cxEntry), false);

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public TextAlignment Alignment
        {
            get { return (TextAlignment)GetValue(AlignmentProperty); }
            set { SetValue(AlignmentProperty, value); }
        }

        public bool HasBorder
        {
            get { return (bool)GetValue(HasBorderProperty); }
            set { SetValue(HasBorderProperty, value); }
        }
    }
    #endregion

    #region cxCarouselView
    public class cxCarouselView : ScrollView
    {
        public enum IndicatorStyleEnum
        {
            None,
            Dots,
            Tabs
        }

        public enum CarouselPageEnum
        {
            Home,
            Gallery,
            Detail
        }

        public enum HomeSearchEnum
        {
            Nothing,
            Normal,
            Advance,
        }

        public enum DetailPageEnum
        {
            Dishes,
            Exterior,
            Interior,
            About
        }

        readonly StackLayout _stack;
        Timer _selectedItemTimer;

        int _selectedIndex;

        public cxCarouselView()
        {
            Orientation = ScrollOrientation.Horizontal;

            _stack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 0
            };

            Content = _stack;

            _selectedItemTimer = new Timer
            {
                AutoReset = false,
                Interval = 300
            };

            _selectedItemTimer.Elapsed += SelectedItemTimerElapsed;
        }

        public IndicatorStyleEnum IndicatorStyle { get; set; }

        public IList<View> Children
        {
            get
            {
                return _stack.Children;
            }
        }

        private bool _layingOutChildren;
        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            base.LayoutChildren(x, y, width, height);
            if (_layingOutChildren) return;

            _layingOutChildren = true;
            foreach (var child in Children) child.WidthRequest = width;
            _layingOutChildren = false;
        }

        public static readonly BindableProperty SelectedIndexProperty =
            BindableProperty.Create<cxCarouselView, int>(
                carousel => carousel.SelectedIndex,
                0,
                BindingMode.TwoWay,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    ((cxCarouselView)bindable).UpdateSelectedItem();
                }
            );

        public int SelectedIndex
        {
            get
            {
                return (int)GetValue(SelectedIndexProperty);
            }
            set
            {
                SetValue(SelectedIndexProperty, value);
            }
        }

        void UpdateSelectedItem()
        {
            _selectedItemTimer.Stop();
            _selectedItemTimer.Start();
        }

        void SelectedItemTimerElapsed(object sender, ElapsedEventArgs e)
        {
            SelectedItem = SelectedIndex > -1 ? Children[SelectedIndex].BindingContext : null;
        }

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create<cxCarouselView, IList>(
                view => view.ItemsSource,
                null,
                propertyChanging: (bindableObject, oldValue, newValue) =>
                {
                    ((cxCarouselView)bindableObject).ItemsSourceChanging();
                },
                propertyChanged: (bindableObject, oldValue, newValue) =>
                {
                    ((cxCarouselView)bindableObject).ItemsSourceChanged();
                }
            );

        public IList ItemsSource
        {
            get
            {
                return (IList)GetValue(ItemsSourceProperty);
            }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }

        void ItemsSourceChanging()
        {
            if (ItemsSource == null) return;
            _selectedIndex = ItemsSource.IndexOf(SelectedItem);
        }

        void ItemsSourceChanged()
        {
            _stack.Children.Clear();
            foreach (var item in ItemsSource)
            {
                var view = (View)ItemTemplate.CreateContent();
                var bindableObject = view as BindableObject;
                if (bindableObject != null)
                    bindableObject.BindingContext = item;
                _stack.Children.Add(view);
            }

            if (_selectedIndex >= 0) SelectedIndex = _selectedIndex;
        }

        public DataTemplate ItemTemplate
        {
            get;
            set;
        }

        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create<cxCarouselView, object>(
                view => view.SelectedItem,
                null,
                BindingMode.TwoWay,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    ((cxCarouselView)bindable).UpdateSelectedIndex();
                }
            );

        public object SelectedItem
        {
            get
            {
                return GetValue(SelectedItemProperty);
            }
            set
            {
                SetValue(SelectedItemProperty, value);
            }
        }

        void UpdateSelectedIndex()
        {
            if (SelectedItem == BindingContext) return;

            SelectedIndex = Children
                .Select(c => c.BindingContext)
                .ToList()
                .IndexOf(SelectedItem);
        }
    }
    #endregion

    #region cxGridView
    public class cxGridView : ContentView
    {
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create("ItemsSource", typeof(IEnumerable), typeof(cxGridView), null, BindingMode.OneWay, null, null, null, null);
        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create("ItemTemplate", typeof(DataTemplate), typeof(cxGridView), null, BindingMode.OneWay, null, null, null, null);
        public static readonly BindableProperty RowSpacingProperty = BindableProperty.Create("RowSpacing", typeof(double), typeof(cxGridView), (double)0, BindingMode.OneWay, null, null, null, null);
        public static readonly BindableProperty ColumnSpacingProperty = BindableProperty.Create("ColumnSpacing", typeof(double), typeof(cxGridView), (double)0, BindingMode.OneWay, null, null, null, null);
        public static readonly BindableProperty ItemWidthProperty = BindableProperty.Create("ItemWidth", typeof(double), typeof(cxGridView), (double)100, BindingMode.OneWay, null, null, null, null);
        public static readonly BindableProperty ItemHeightProperty = BindableProperty.Create("ItemHeight", typeof(double), typeof(cxGridView), (double)100, BindingMode.OneWay, null, null, null, null);

        public cxGridView()
        {
            SelectionEnabled = true;
        }

        public IEnumerable ItemsSource
        {
            get
            {
                return (IEnumerable)base.GetValue(cxGridView.ItemsSourceProperty);
            }
            set
            {
                base.SetValue(cxGridView.ItemsSourceProperty, value);
            }
        }

        public DataTemplate ItemTemplate
        {
            get
            {
                return (DataTemplate)base.GetValue(cxGridView.ItemTemplateProperty);
            }
            set
            {
                base.SetValue(cxGridView.ItemTemplateProperty, value);
            }
        }

        public double RowSpacing
        {
            get
            {
                return (double)base.GetValue(cxGridView.RowSpacingProperty);
            }
            set
            {
                base.SetValue(cxGridView.RowSpacingProperty, value);
            }
        }

        public double ColumnSpacing
        {
            get
            {
                return (double)base.GetValue(cxGridView.ColumnSpacingProperty);
            }
            set
            {
                base.SetValue(cxGridView.ColumnSpacingProperty, value);
            }
        }

        public double ItemWidth
        {
            get
            {
                return (double)base.GetValue(cxGridView.ItemWidthProperty);
            }
            set
            {
                base.SetValue(cxGridView.ItemWidthProperty, value);
            }
        }

        public double ItemHeight
        {
            get
            {
                return (double)base.GetValue(cxGridView.ItemHeightProperty);
            }
            set
            {
                base.SetValue(cxGridView.ItemHeightProperty, value);
            }
        }

        public event EventHandler<EventArgs<object>> ItemSelected;

        public void InvokeItemSelectedEvent(object sender, object item)
        {
            if (this.ItemSelected != null)
            {
                this.ItemSelected.Invoke(sender, new EventArgs<object>(item));
            }
        }

        public bool SelectionEnabled
        {
            get;
            set;
        }
    }

    public class EventArgs<T> : EventArgs
    {
        public EventArgs(T value)
        {
            this.Value = value;
        }
        public T Value { get; private set; }
    }
    #endregion

	#region cxBoxView
	public class cxBoxView : BoxView
	{
		public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create<cxBoxView, double>(p => p.CornerRadius, 0);
		public static readonly BindableProperty StrokeProperty = BindableProperty.Create<cxBoxView, Color>(p => p.Stroke, Color.Transparent);
		public static readonly BindableProperty StrokeThicknessProperty = BindableProperty.Create<cxBoxView, double>(p => p.StrokeThickness, default(double));
		public static readonly BindableProperty HasShadowProperty = BindableProperty.Create<cxBoxView, bool>(p => p.HasShadow, default(bool));

		public double CornerRadius
		{
			get { return (double)base.GetValue(CornerRadiusProperty); }
			set { base.SetValue(CornerRadiusProperty, value); }
		}

		public Color Stroke
		{
			get { return (Color)GetValue(StrokeProperty); }
			set { SetValue(StrokeProperty, value); }
		}

		public double StrokeThickness
		{
			get { return (double)GetValue(StrokeThicknessProperty); }
			set { SetValue(StrokeThicknessProperty, value); }
		}

		public bool HasShadow
		{
			get { return (bool)GetValue(HasShadowProperty); }
			set { SetValue(HasShadowProperty, value); }
		}
	}
	#endregion

	#region cxPopupLayout
	public class cxPopupLayout : ContentView
	{
		public enum PopupLocation
		{
			Top,
			Bottom
			//Left,
			//Right
		}
		private View content;
		private View popup;

		private readonly RelativeLayout layout;

		private BoxView mask;

		public cxPopupLayout()
		{
			mask = new BoxView()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.Black.MultiplyAlpha (.7f),
				GestureRecognizers = { new TapGestureRecognizer() }
			};
			base.Content = this.layout = new RelativeLayout();
		}

		public new View Content
		{
			get { return this.content; }
			set
			{
				if (this.content != null)
				{
					this.layout.Children.Remove(this.content);
				}

				this.content = value;
				this.layout.Children.Add(this.content, () => this.Bounds);
			}
		}

		public bool IsPopupActive
		{
			get { return this.popup != null; }
		}

		public void ShowPopup(View popupView)
		{
			this.ShowPopup(
				popupView,
				Constraint.RelativeToParent(p => (this.Width - this.popup.WidthRequest) / 2),
				Constraint.RelativeToParent(p => (this.Height - this.popup.HeightRequest) / 2)
			);
		}

		public async void ShowPopup(View popupView, Constraint xConstraint, Constraint yConstraint, Constraint widthConstraint = null, Constraint heightConstraint = null)
		{
			DismissPopup();
			this.popup = popupView;

			this.layout.InputTransparent = true;
			this.content.InputTransparent = true;
			this.layout.Children.Add(this.mask, Constraint.Constant(0), Constraint.Constant(0), Constraint.RelativeToParent((parent) => { return parent.Width; }), Constraint.RelativeToParent((parent) => { return parent.Height; }));
			this.layout.Children.Add(this.popup, xConstraint, yConstraint, widthConstraint, heightConstraint);

			this.layout.ForceLayout();
			await System.Threading.Tasks.Task.WhenAll(mask.FadeTo(1), popup.FadeTo(1));
		}

		public void ShowPopup(View popupView, View presenter, PopupLocation location, float paddingX = 0, float paddingY = 0)
		{
			DismissPopup();
			this.popup = popupView;

			Constraint constraintX = null, constraintY = null;

			switch (location)
			{
			case PopupLocation.Bottom:
				constraintX = Constraint.RelativeToParent(parent => presenter.X + (presenter.Width - this.popup.WidthRequest) / 2);
				constraintY = Constraint.RelativeToParent(parent => parent.Y + presenter.Y + presenter.Height + paddingY);
				break;
			case PopupLocation.Top:
				constraintX = Constraint.RelativeToParent(parent => presenter.X + (presenter.Width - this.popup.WidthRequest) / 2);
				constraintY = Constraint.RelativeToParent(parent =>
					parent.Y + presenter.Y - this.popup.HeightRequest / 2 - paddingY);
				break;
				//case PopupLocation.Left:
				//    constraintX = Constraint.RelativeToView(presenter, (parent, view) => ((view.X + view.Height / 2) - parent.X) + this.popup.HeightRequest / 2);
				//    constraintY = Constraint.RelativeToView(presenter, (parent, view) => parent.Y + view.Y + view.Width + paddingY);
				//    break;
				//case PopupLocation.Right:
				//    constraintX = Constraint.RelativeToView(presenter, (parent, view) => ((view.X + view.Height / 2) - parent.X) + this.popup.HeightRequest / 2);
				//    constraintY = Constraint.RelativeToView(presenter, (parent, view) => parent.Y + view.Y - this.popup.WidthRequest - paddingY);
				//    break;
			}

			this.ShowPopup(popupView, constraintX, constraintY);
		}

		public async void DismissPopup()
		{
			if (this.popup != null)
			{
				await System.Threading.Tasks.Task.WhenAll(mask.FadeTo(0), popup.FadeTo(0));
				this.layout.Children.Remove(this.mask);
				this.layout.Children.Remove(this.popup);
				this.popup = null;
			}

			this.layout.InputTransparent = false;

			if (this.content != null)
			{
				this.content.InputTransparent = false;
			}
		}
	}
	#endregion

	#region cxRoundLayout
	public class cxRoundLayout
	{
		public static RelativeLayout Inflate(StackLayout content, double Width, double Height, double CornerRadius, double OutlineThickness, Color OutlineColor, Color BackgroundColor)
		{
			var outline = new cxBoxView()
			{
				Stroke = OutlineColor,
				StrokeThickness = OutlineThickness,
				CornerRadius = CornerRadius,
				Color = BackgroundColor,
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};

			var _layout = new RelativeLayout()
			{
				WidthRequest = Width,
				HeightRequest = Height,
				BackgroundColor = Color.Transparent,
			};

			_layout.Children.Add(outline, Constraint.Constant(0), Constraint.Constant(0), Constraint.RelativeToParent((parent) => { return parent.Width; }), Constraint.RelativeToParent((parent) => { return parent.Height; }));
			_layout.Children.Add(content, Constraint.Constant(0), Constraint.Constant(0), Constraint.RelativeToParent((parent) => { return parent.Width; }), Constraint.RelativeToParent((parent) => { return parent.Height; }));

			return _layout;
		}
	}
	#endregion
}
