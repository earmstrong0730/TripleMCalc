package mono.android.app;

public class ApplicationRegistration {

	public static void registerApplications ()
	{
				// Application and Instrumentation ACWs must be registered first.
		mono.android.Runtime.register ("TripleMCalc.Droid.MainApplication, TripleMCalc.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", md5b3a9374873cf101dd6569caa26673257.MainApplication.class, md5b3a9374873cf101dd6569caa26673257.MainApplication.__md_methods);
		mono.android.Runtime.register ("MvvmCross.Droid.Views.MvxAndroidApplication, MvvmCross.Droid, Version=5.2.1.0, Culture=neutral, PublicKeyToken=null", md5574c1700f54c1af9f21719cde6491b73.MvxAndroidApplication.class, md5574c1700f54c1af9f21719cde6491b73.MvxAndroidApplication.__md_methods);
		
	}
}
