

namespace Alpha.Droid.Activities
{
	// An Android Activity storage bag
	public class ActivityStorageBag : Java.Lang.Object
	{
		public ActivityStorageBag ( string storageBag ) { StorageBag = storageBag; }
		public string StorageBag { get; set; }
	}
}

