using System.Collections.Specialized;
using System.Windows.Input;
using Android.App;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.BindingContext;

namespace TripleMCalc.Droid
{
    // This class is never actually executed, but when Xamarin linking is enabled it does how to ensure types and properties
    // are preserved in the deployed app
    public class LinkerPleaseInclude
    {
        public static void Include(Button button)
        {
            button.Click += (s, e) => button.Text = button.Text + "";
        }

        public static void Include(CheckBox checkBox)
        {
            checkBox.CheckedChange += (sender, args) => checkBox.Checked = !checkBox.Checked;
        }

        public static void Include(Switch @switch)
        {
            @switch.CheckedChange += (sender, args) => @switch.Checked = !@switch.Checked;
        }

        public static void Include(View view)
        {
            view.Click += (s, e) => view.ContentDescription = view.ContentDescription + "";
        }

        public static void Include(TextView text)
        {
            text.AfterTextChanged += (sender, args) => text.Text = "" + text.Text;
            text.Hint = "" + text.Hint;
        }

        public static void Include(CheckedTextView text)
        {
            text.AfterTextChanged += (sender, args) => text.Text = "" + text.Text;
            text.Hint = "" + text.Hint;
        }

        public static void Include(CompoundButton cb)
        {
            cb.CheckedChange += (sender, args) => cb.Checked = !cb.Checked;
        }

        public static void Include(SeekBar sb)
        {
            sb.ProgressChanged += (sender, args) => sb.Progress = sb.Progress + 1;
        }

        public static void Include(RadioGroup radioGroup)
        {
            radioGroup.CheckedChange += (sender, args) => radioGroup.Check(args.CheckedId);
        }

        public static void Include(RadioButton radioButton)
        {
            radioButton.CheckedChange += (sender, args) => radioButton.Checked = args.IsChecked;
        }

        public static void Include(RatingBar ratingBar)
        {
            ratingBar.RatingBarChange += (sender, args) => ratingBar.Rating = 0 + ratingBar.Rating;
        }

        public static void Include(Activity act)
        {
            act.Title = act.Title + "";
        }

        public static void Include(INotifyCollectionChanged changed)
        {
            changed.CollectionChanged += (s, e) => { var test = $"{e.Action}{e.NewItems}{e.NewStartingIndex}{e.OldItems}{e.OldStartingIndex}"; };
        }
        public static void Include(ICommand command)
        {
            command.CanExecuteChanged += (s, e) => { if (command.CanExecute(null)) command.Execute(null); };
        }

        public static void Include(MvvmCross.Platform.IoC.MvxPropertyInjector injector)
        {
            injector = new MvvmCross.Platform.IoC.MvxPropertyInjector();
        }
        public static void Include(System.ComponentModel.INotifyPropertyChanged changed)
        {
            changed.PropertyChanged += (sender, e) =>
            {
                var test = e.PropertyName;
            };
        }

        public static void Include(MvxTaskBasedBindingContext context)
        {
            context.Dispose();
            var context2 = new MvxTaskBasedBindingContext();
            context2.Dispose();
        }
    }
}
