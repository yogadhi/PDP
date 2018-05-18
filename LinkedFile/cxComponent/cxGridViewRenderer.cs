using System;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using Xamarin.Forms;
using Shared.Services.Logs;
using Shared.Classes.Components;
#if __ANDROID__
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
#endif
#if __IOS__
using Foundation;
using UIKit;
using CoreGraphics;
using Xamarin.Forms.Platform.iOS;
#endif

[assembly: ExportRenderer(typeof(cxGridView), typeof(cxGridViewRenderer))]
#if __ANDROID__
public class cxGridViewRenderer : ViewRenderer<cxGridView, Android.Widget.GridView>
{
	private readonly Android.Content.Res.Orientation _orientation = Android.Content.Res.Orientation.Undefined;
	public cxGridViewRenderer()
	{
	}

	protected override void OnConfigurationChanged(Configuration newConfig)
	{
		try{
			base.OnConfigurationChanged(newConfig);
			if (newConfig.Orientation != _orientation)
				OnElementChanged(new ElementChangedEventArgs<cxGridView>(this.Element, this.Element));
		}
		catch (System.Exception ex)
		{
			Insights.Send("OnConfigurationChanged", ex);
		}
	}

	protected override void OnElementChanged(ElementChangedEventArgs<cxGridView> e)
	{
		try{
			base.OnElementChanged(e);

			var collectionView = new Android.Widget.GridView(Xamarin.Forms.Forms.Context);
			collectionView.SetGravity(GravityFlags.Center);
			collectionView.SetColumnWidth(Convert.ToInt32(Element.ItemWidth));
			collectionView.StretchMode = StretchMode.StretchColumnWidth;

			var metrics = Resources.DisplayMetrics;
			var spacing = (int)e.NewElement.ColumnSpacing;
			var width = metrics.WidthPixels;
			var itemWidth = (int)e.NewElement.ItemWidth;

			int noOfColumns = width / (itemWidth + spacing);
			// If possible add another row without spacing (because the number of columns will be one less than the number of spacings)
			if (width - (noOfColumns * (itemWidth + spacing)) >= itemWidth)
				noOfColumns++;

			collectionView.SetNumColumns(noOfColumns);
			collectionView.SetPadding(Convert.ToInt32(Element.Padding.Left), Convert.ToInt32(Element.Padding.Top), Convert.ToInt32(Element.Padding.Right), Convert.ToInt32(Element.Padding.Bottom));

			collectionView.SetBackgroundColor(Element.BackgroundColor.ToAndroid());
			collectionView.SetHorizontalSpacing(Convert.ToInt32(Element.RowSpacing));
			collectionView.SetVerticalSpacing(Convert.ToInt32(Element.ColumnSpacing));

			this.Unbind(e.OldElement);
			this.Bind(e.NewElement);

			collectionView.Adapter = this.DataSource;

			collectionView.ItemClick += CollectionViewItemClick;

			base.SetNativeControl(collectionView);
		}
		catch (System.Exception ex)
		{
			Insights.Send("OnElementChanged", ex);
		}

	}

	void CollectionViewItemClick(object sender, AdapterView.ItemClickEventArgs e)
	{
		try{
			var item = this.Element.ItemsSource.Cast<object>().ElementAt(e.Position);
			this.Element.InvokeItemSelectedEvent(this, item);
		}
		catch (System.Exception ex)
		{
			Insights.Send("CollectionViewItemClick", ex);
		}
	}

	private void Unbind(cxGridView oldElement)
	{
		try{
			if (oldElement != null)
			{
				oldElement.PropertyChanging += ElementPropertyChanging;
				oldElement.PropertyChanged -= ElementPropertyChanged;
				if (oldElement.ItemsSource is INotifyCollectionChanged)
				{
					(oldElement.ItemsSource as INotifyCollectionChanged).CollectionChanged -= DataCollectionChanged;
				}
			}
		}
		catch (System.Exception ex)
		{
			Insights.Send("Unbind", ex);
		}
	}

	private void Bind(cxGridView newElement)
	{
		try{
			if (newElement != null)
			{
				newElement.PropertyChanging += ElementPropertyChanging;
				newElement.PropertyChanged += ElementPropertyChanged;
				if (newElement.ItemsSource is INotifyCollectionChanged)
				{
					(newElement.ItemsSource as INotifyCollectionChanged).CollectionChanged += DataCollectionChanged;
				}
			}
		}
		catch (System.Exception ex)
		{
			Insights.Send("Bind", ex);
		}
	}

	private void ElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
	{
		try{
			if (e.PropertyName == "ItemsSource")
			{
				if (this.Element.ItemsSource is INotifyCollectionChanged)
				{
					(this.Element.ItemsSource as INotifyCollectionChanged).CollectionChanged -= DataCollectionChanged;
				}
			}
		}
		catch (System.Exception ex)
		{
			Insights.Send("ElementPropertyChanged", ex);
		}
	}

	private void ElementPropertyChanging(object sender, PropertyChangingEventArgs e)
	{
		try{
			if (e.PropertyName == "ItemsSource")
			{
				if (this.Element.ItemsSource is INotifyCollectionChanged)
				{
					(this.Element.ItemsSource as INotifyCollectionChanged).CollectionChanged += DataCollectionChanged;
				}
			}
		}
		catch (System.Exception ex)
		{
			Insights.Send("ElementPropertyChanging", ex);
		}
	}

	private void DataCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
	{
		//  Control.ReloadData();
	}

	private GridDataSource _dataSource;
	private GridDataSource DataSource
	{
		get
		{
			return _dataSource ??
				(_dataSource =
					new GridDataSource(this.GetCell, this.RowsInSection));
		}
	}

	public int RowsInSection()
	{
		return (this.Element.ItemsSource as ICollection).Count;
	}

	public global::Android.Views.View GetCell(int position, global::Android.Views.View convertView, ViewGroup parent)
	{
		try{
			var item = this.Element.ItemsSource.Cast<object>().ElementAt(position);
			var viewCellBinded = (Element.ItemTemplate.CreateContent() as ViewCell);
			viewCellBinded.BindingContext = item;
			var view = RendererFactory.GetRenderer(viewCellBinded.View);
			view.ViewGroup.LayoutParameters = new Android.Widget.GridView.LayoutParams(Convert.ToInt32(this.Element.ItemWidth), Convert.ToInt32(this.Element.ItemHeight));
			view.ViewGroup.SetBackgroundColor(global::Android.Graphics.Color.LightGray);
			return view.ViewGroup;
		}
		catch (System.Exception ex)
		{
			Insights.Send("SetMaxLength", ex);
			return null;
		}

	}

	private Bitmap GetImageBitmapFromUrl(string url)
	{
		try{
			Bitmap imageBitmap = null;

			using (var webClient = new WebClient())
			{
				var imageBytes = webClient.DownloadData(url);
				if (imageBytes != null && imageBytes.Length > 0)
				{
					imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
				}
			}

			return imageBitmap;
		}
		catch (System.Exception ex)
		{
			Insights.Send("SetMaxLength", ex);
			return null;
		}
	}
}

public class GridDataSource : BaseAdapter
{
	Context _context;

	public delegate global::Android.Views.View OnGetCell(int position, global::Android.Views.View convertView, ViewGroup parent);
	public delegate int OnRowsInSection();

	private readonly OnGetCell _onGetCell;
	private readonly OnRowsInSection _onRowsInSection;

	public GridDataSource(OnGetCell onGetCell, OnRowsInSection onRowsInSection)
	{
		this._onGetCell = onGetCell;
		this._onRowsInSection = onRowsInSection;
	}

	public GridDataSource(Context c)
	{
		_context = c;
	}

	public override int Count
	{
		get { return _onRowsInSection(); }
	}

	public override Java.Lang.Object GetItem(int position)
	{
		return null;
	}

	public override long GetItemId(int position)
	{
		return 0;
	}

	public override global::Android.Views.View GetView(int position, global::Android.Views.View convertView, ViewGroup parent)
	{
		return _onGetCell(position, convertView, parent);
	}

}

public class cxGridViewCellRenderer : CellRenderer
{
	protected override global::Android.Views.View GetCellCore(Cell item, global::Android.Views.View convertView, ViewGroup parent, Context context)
	{
		ViewCell viewCell = (ViewCell)item;
		cxGridViewCellRenderer.ViewCellContainer viewCellContainer = convertView as cxGridViewCellRenderer.ViewCellContainer;
		if (viewCellContainer != null)
		{
			viewCellContainer.Update(viewCell);
			return viewCellContainer;
		}

		IVisualElementRenderer renderer = RendererFactory.GetRenderer(viewCell.View);
		return new cxGridViewCellRenderer.ViewCellContainer(context, renderer, viewCell, parent);
	}

	private class ViewCellContainer : ViewGroup
	{

		IVisualElementRenderer _view;
		global::Android.Views.View _parent;
		ViewCell _viewCell;
		public ViewCellContainer(Context context, IVisualElementRenderer view, ViewCell viewCell, global::Android.Views.View parent)
			: base(context)
		{

			this._view = view;
			this._parent = parent;
			//                this.unevenRows = unevenRows;
			//                this.rowHeight = rowHeight;
			this._viewCell = viewCell;
			this.AddView(view.ViewGroup);
		}

		public void Update(ViewCell cell)
		{
			IVisualElementRenderer visualElementRenderer = this.GetChildAt(0) as IVisualElementRenderer;
		}

		protected override void OnLayout(bool changed, int l, int t, int r, int b)
		{
			double width = base.Context.FromPixels((double)(r - l));
			double height = base.Context.FromPixels((double)(b - t));
			this._view.Element.Layout(new Rectangle(0, 0, width, height));
			this._view.UpdateLayout();
		}
	}
}
#endif

#if __IOS__
public class cxGridViewRenderer : ViewRenderer<cxGridView, cxGridCollectionView>
{
private cxGridDataSource _dataSource;

public cxGridViewRenderer()
{
}

public int RowsInSection(UICollectionView collectionView, nint section)
{
return ((ICollection)this.Element.ItemsSource).Count;
}

public void ItemSelected(UICollectionView tableView, NSIndexPath indexPath)
{
var item = this.Element.ItemsSource.Cast<object>().ElementAt(indexPath.Row);
this.Element.InvokeItemSelectedEvent(this, item);
}

public UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
{
var item = this.Element.ItemsSource.Cast<object>().ElementAt(indexPath.Row);
var viewCellBinded = (this.Element.ItemTemplate.CreateContent() as ViewCell);
if (viewCellBinded == null) return null;

viewCellBinded.BindingContext = item;
return this.GetCell(collectionView, viewCellBinded, indexPath);
}

protected virtual UICollectionViewCell GetCell(UICollectionView collectionView, ViewCell item, NSIndexPath indexPath)
{
var collectionCell = collectionView.DequeueReusableCell(new NSString(cxGridViewCellRenderer.Key), indexPath) as cxGridViewCellRenderer;

if (collectionCell == null) return null;

collectionCell.ViewCell = item;

return collectionCell;
}

protected override void OnElementChanged(ElementChangedEventArgs<cxGridView> e)
{
base.OnElementChanged(e);
if (e.OldElement != null)
{
Unbind(e.OldElement);
}
if (e.NewElement != null)
{
if (Control == null)
{
var collectionView = new cxGridCollectionView
{
AllowsMultipleSelection = false,
SelectionEnable = e.NewElement.SelectionEnabled,
ContentInset = new UIEdgeInsets((float)this.Element.Padding.Top, (float)this.Element.Padding.Left, (float)this.Element.Padding.Bottom, (float)this.Element.Padding.Right),
BackgroundColor = this.Element.BackgroundColor.ToUIColor(),
ItemSize = new CoreGraphics.CGSize((float)adjustthumbnail(), (float)adjustthumbnail()),
RowSpacing = this.Element.RowSpacing,
ColumnSpacing = this.Element.ColumnSpacing
};

Bind(e.NewElement);

collectionView.Source = this.DataSource;
//collectionView.Delegate = this.GridViewDelegate;

SetNativeControl(collectionView);
}
}
}

public double adjustthumbnail()
{

CGRect screen = UIScreen.MainScreen.Bounds;
var screenwidth = screen.Width * 0.31;

return screenwidth;
}

private void Unbind(cxGridView oldElement)
{
if (oldElement == null) return;

oldElement.PropertyChanging -= this.ElementPropertyChanging;
oldElement.PropertyChanged -= this.ElementPropertyChanged;

var itemsSource = oldElement.ItemsSource as INotifyCollectionChanged;
if (itemsSource != null)
{
itemsSource.CollectionChanged -= this.DataCollectionChanged;
}
}

private void Bind(cxGridView newElement)
{
if (newElement == null) return;

newElement.PropertyChanging += this.ElementPropertyChanging;
newElement.PropertyChanged += this.ElementPropertyChanged;

var source = newElement.ItemsSource as INotifyCollectionChanged;
if (source != null)
{
source.CollectionChanged += this.DataCollectionChanged;
}
}

private void ElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
{
if (e.PropertyName == "ItemsSource")
{
var itemsSource = this.Element.ItemsSource as INotifyCollectionChanged;
if (itemsSource != null)
{
itemsSource.CollectionChanged -= DataCollectionChanged;
}
}
}

private void ElementPropertyChanging(object sender, PropertyChangingEventArgs e)
{
if (e.PropertyName == "ItemsSource")
{
var itemsSource = this.Element.ItemsSource as INotifyCollectionChanged;
if (itemsSource != null)
{
itemsSource.CollectionChanged += DataCollectionChanged;
}
}
}

private void DataCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
{
try
{
if (this.Control != null) this.Control.ReloadData();
}
catch { } // todo: determine why we are hiding a possible exception here
}

private cxGridDataSource DataSource
{
get
{
return _dataSource ?? (_dataSource = new cxGridDataSource(GetCell, RowsInSection, ItemSelected));
}
}

protected override void Dispose(bool disposing)
{
base.Dispose(disposing);
if (disposing && _dataSource != null)
{
Unbind(Element);
_dataSource.Dispose();
_dataSource = null;
}
}
}

public class cxGridCollectionView : UICollectionView
{
public bool SelectionEnable
{
get;
set;
}

public cxGridCollectionView()
: this(default(CGRect))
{
}

public cxGridCollectionView(CGRect frm)
: base(default(CGRect), new UICollectionViewFlowLayout() { })
{
AutoresizingMask = UIViewAutoresizing.All;
ContentMode = UIViewContentMode.ScaleToFill;
RegisterClassForCell(typeof(cxGridViewCellRenderer), new NSString(cxGridViewCellRenderer.Key));

}

public override UICollectionViewCell CellForItem(NSIndexPath indexPath)
{
if (indexPath == null)
{
return null;
}
return base.CellForItem(indexPath);
}

public override void Draw(CGRect rect)
{
CollectionViewLayout.InvalidateLayout();

base.Draw(rect);
}

public double RowSpacing
{
get
{
return (double)(CollectionViewLayout as UICollectionViewFlowLayout).MinimumLineSpacing;
}
set
{
(CollectionViewLayout as UICollectionViewFlowLayout).MinimumLineSpacing = (float)value;
}
}

public double ColumnSpacing
{
get
{
return (double)(CollectionViewLayout as UICollectionViewFlowLayout).MinimumInteritemSpacing;
}
set
{
(CollectionViewLayout as UICollectionViewFlowLayout).MinimumInteritemSpacing = (float)value;
}
}

public CGSize ItemSize
{
get
{
return (CollectionViewLayout as UICollectionViewFlowLayout).ItemSize;
}
set
{
(CollectionViewLayout as UICollectionViewFlowLayout).ItemSize = value;
}
}
}

public class cxGridViewCellRenderer : UICollectionViewCell
{
public const string Key = "GridViewCell";

private ViewCell _viewCell;

private UIView _view;

public ViewCell ViewCell
{
get
{
return _viewCell;
}
set
{
if (_viewCell == value)
{
return;
}
UpdateCell(value);
}
}

[Export("initWithFrame:")]
public cxGridViewCellRenderer(CGRect frame)
: base(frame)
{
// SelectedBackgroundView = new cxGridItemSelectedViewOverlay (frame);
// this.BringSubviewToFront (SelectedBackgroundView);

}

private void UpdateCell(ViewCell cell)
{
if (_viewCell != null)
{
//this.viewCell.SendDisappearing ();
_viewCell.PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(HandlePropertyChanged);
}
_viewCell = cell;
_viewCell.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(HandlePropertyChanged);
//this.viewCell.SendAppearing ();
UpdateView();
}

private void HandlePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
{
UpdateView();
}

private void UpdateView()
{

if (_view != null)
{
_view.RemoveFromSuperview();
}
_view = RendererFactory.GetRenderer(_viewCell.View).NativeView;
_view.AutoresizingMask = UIViewAutoresizing.All;
_view.ContentMode = UIViewContentMode.ScaleToFill;

AddSubview(_view);
}

public override void LayoutSubviews()
{
base.LayoutSubviews();
CGRect frame = ContentView.Frame;
frame.X = (Bounds.Width - frame.Width) / 2;
frame.Y = (Bounds.Height - frame.Height) / 2;
ViewCell.View.Layout(frame.ToRectangle());
_view.Frame = frame;
}
}

public class cxGridItemSelectedViewOverlay : UIView
{

public cxGridItemSelectedViewOverlay(CGRect frame)
: base(frame)
{
BackgroundColor = UIColor.Clear;
}

public override void Draw(CGRect rect)
{
using (var g = UIGraphics.GetCurrentContext())
{
g.SetLineWidth(10);
UIColor.FromRGB(64, 30, 168).SetStroke();
UIColor.Clear.SetFill();

//create geometry
var path = new CGPath();
path.AddRect(rect);
path.CloseSubpath();

//add geometry to graphics context and draw it
g.AddPath(path);
g.DrawPath(CGPathDrawingMode.Stroke);
}
}
}

public class cxGridDataSource : UICollectionViewSource
{
public delegate UICollectionViewCell OnGetCell(UICollectionView collectionView, NSIndexPath indexPath);

public delegate int OnRowsInSection(UICollectionView collectionView, nint section);

public delegate void OnItemSelected(UICollectionView collectionView, NSIndexPath indexPath);

private readonly OnGetCell _onGetCell;

private readonly OnRowsInSection _onRowsInSection;

private readonly OnItemSelected _onItemSelected;

public cxGridDataSource(OnGetCell onGetCell, OnRowsInSection onRowsInSection, OnItemSelected onItemSelected)
{
_onGetCell = onGetCell;
_onRowsInSection = onRowsInSection;
_onItemSelected = onItemSelected;
}

#region implemented abstract members of UICollectionViewDataSource

public override nint GetItemsCount(UICollectionView collectionView, nint section)
{
return _onRowsInSection(collectionView, section);
}

public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
{
_onItemSelected(collectionView, indexPath);
}

public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
{
UICollectionViewCell cell = _onGetCell(collectionView, indexPath);
if ((collectionView as cxGridCollectionView).SelectionEnable)
{
cell.AddGestureRecognizer(new UITapGestureRecognizer((v) =>
{
ItemSelected(collectionView, indexPath);
}));
}
else
cell.SelectedBackgroundView = new UIView();

return cell;
}

#endregion
}

public class cxGridViewDelegate : UICollectionViewDelegate
{
public delegate void OnItemSelected(UICollectionView tableView, NSIndexPath indexPath);

private readonly OnItemSelected _onItemSelected;

public cxGridViewDelegate(OnItemSelected onItemSelected)
{
_onItemSelected = onItemSelected;
}

public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
{
_onItemSelected(collectionView, indexPath);
}

public override void ItemHighlighted(UICollectionView collectionView, NSIndexPath indexPath)
{
_onItemSelected.Invoke(collectionView, indexPath);
}

}
#endif

