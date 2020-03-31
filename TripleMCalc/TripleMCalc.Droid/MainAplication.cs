using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.CurrentActivity;

namespace TripleMCalc.Droid
{
#if DEBUG
    [Application(Debuggable = true)]
#else
	            [Application(Debuggable = false)]
#endif


    class MainApplication : Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer)
          : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            CrossCurrentActivity.Current.Init(this);

        }

        /// <summary>
        /// Gets or sets the activity.
        /// </summary>
        /// <value>The activity.</value>
        Activity Activity { get; set; }

        /// <summary>
        /// Gets the current Application Context.
        /// </summary>
        /// <value>The activity.</value>
        Context AppContext { get; }

        /// <summary>
        /// Fires when activity state events are fired
        /// </summary>
        event EventHandler<ActivityEventArgs> ActivityStateChanged;
    }
}