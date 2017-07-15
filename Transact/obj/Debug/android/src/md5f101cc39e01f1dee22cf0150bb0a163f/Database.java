package md5f101cc39e01f1dee22cf0150bb0a163f;


public class Database
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer,
		java.io.Serializable
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Transact.Database, Transact, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Database.class, __md_methods);
	}


	public Database () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Database.class)
			mono.android.TypeManager.Activate ("Transact.Database, Transact, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

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
