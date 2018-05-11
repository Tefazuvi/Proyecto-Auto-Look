package md507f625f62cafec6e81efe0279defe3bb;


public class VerticalViewPager_VerticalPageTransformer
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.v4.view.ViewPager.PageTransformer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_transformPage:(Landroid/view/View;F)V:GetTransformPage_Landroid_view_View_FHandler:Android.Support.V4.View.ViewPager/IPageTransformerInvoker, Xamarin.Android.Support.Core.UI\n" +
			"";
		mono.android.Runtime.register ("CarouselView.FormsPlugin.Android.VerticalViewPager+VerticalPageTransformer, CarouselView.FormsPlugin.Android", VerticalViewPager_VerticalPageTransformer.class, __md_methods);
	}


	public VerticalViewPager_VerticalPageTransformer ()
	{
		super ();
		if (getClass () == VerticalViewPager_VerticalPageTransformer.class)
			mono.android.TypeManager.Activate ("CarouselView.FormsPlugin.Android.VerticalViewPager+VerticalPageTransformer, CarouselView.FormsPlugin.Android", "", this, new java.lang.Object[] {  });
	}


	public void transformPage (android.view.View p0, float p1)
	{
		n_transformPage (p0, p1);
	}

	private native void n_transformPage (android.view.View p0, float p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
