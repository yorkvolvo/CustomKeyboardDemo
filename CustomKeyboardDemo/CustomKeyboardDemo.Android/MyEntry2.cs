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
using Xamarin.Forms;
using CustomKeyboardDemo;
using CustomKeyboardDemo.Droid;
using Android.Views.InputMethods;
using static Android.Views.View;
using Xamarin.Forms.Platform.Android;
using Android.Support.Design.Widget;
using Android.Text;
using Android.Content.Res;
using Java.Lang;
using Android.Views.Animations;
using System.Threading.Tasks;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntry2Renderer))]
namespace CustomKeyboardDemo.Droid
{
    public class MyEntry2Renderer :  ViewRenderer<MyEntry, TextInputLayout>,
        ITextWatcher,
        TextView.IOnEditorActionListener
    {
        private bool _hasFocus;

        public CustomKeyboardView mKeyboardView;
        public Android.InputMethodServices.Keyboard mKeyboard;

        ViewGroup activityRootView;

        protected EditText EditText => Control.EditText;

        public bool OnEditorAction(TextView v, ImeAction actionId, KeyEvent e)
        {
            if ((actionId == ImeAction.Done) || ((actionId == ImeAction.ImeNull) && (e.KeyCode == Keycode.Enter)))
            {
                Control.ClearFocus();
                //HideKeyboard();
                ((IEntryController)Element).SendCompleted();
            }
            return true;
        }

        public virtual void AfterTextChanged(IEditable s)
        {
        }

        public virtual void BeforeTextChanged(ICharSequence s, int start, int count, int after)
        {
        }

        public virtual void OnTextChanged(ICharSequence s, int start, int before, int count)
        {
            if (string.IsNullOrWhiteSpace(Element.Text) && (s.Length() == 0)) return;
            ((IElementController)Element).SetValueFromRenderer(Entry.TextProperty, s.ToString());
        }

        protected override TextInputLayout CreateNativeControl()
        {
            var textInputLayout = new TextInputLayout(Context);
            var editText = new EditText(Context);

            #region Add the Keyboard in your Page
            var activity = Forms.Context as Activity;
            var rootView = activity.Window.DecorView.FindViewById(Android.Resource.Id.Content);

            activity.Window.SetSoftInputMode(SoftInput.StateAlwaysHidden);

            activityRootView = ((ViewGroup)rootView).GetChildAt(0) as ViewGroup;
            mKeyboardView = new CustomKeyboardView(Forms.Context, null);

            Android.Widget.RelativeLayout.LayoutParams layoutParams =
                new Android.Widget.RelativeLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.WrapContent); // or wrap_content
            layoutParams.AddRule(LayoutRules.AlignParentBottom);
            activityRootView.AddView(mKeyboardView, layoutParams);
            #endregion

            //First open the current page, hide the Keyboard
            mKeyboardView.Visibility = ViewStates.Gone;

            //Use the custom Keyboard
            mKeyboard = new Android.InputMethodServices.Keyboard(Context, Resource.Xml.keyboard);
            mKeyboardView.Keyboard = mKeyboard;

            mKeyboardView.Key += async (sender, e) =>
            {
                long eventTime = JavaSystem.CurrentTimeMillis();
                KeyEvent ev = new KeyEvent(eventTime, eventTime, KeyEventActions.Down, e.PrimaryCode, 0, 0, 0, 0, KeyEventFlags.SoftKeyboard | KeyEventFlags.KeepTouchMode);

                DispatchKeyEvent(ev);

                await Task.Delay(1);
            };

            textInputLayout.AddView(editText);
            return textInputLayout;
        }


        protected override void OnElementChanged(ElementChangedEventArgs<MyEntry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
                if (Control != null)
                    EditText.FocusChange -= ControlOnFocusChange;

            if (e.NewElement != null)
            {
                var ctrl = CreateNativeControl();
                SetNativeControl(ctrl);

                EditText.ShowSoftInputOnFocus = false;

                EditText.FocusChange += ControlOnFocusChange;
            }
        }

        private void ControlOnFocusChange(object sender, FocusChangeEventArgs args)
        {
            _hasFocus = args.HasFocus;
            if (_hasFocus)
            {
                EditText.Post(() =>
                {
                    EditText.RequestFocus();
                    ShowKeyboardWithAnimation();
                });
            }
            else
            {
                //Hide the Keyboard
                mKeyboardView.Visibility = ViewStates.Gone;
            }
        }

        public void ShowKeyboardWithAnimation()
        {
            if (mKeyboardView.Visibility == ViewStates.Gone)
            {
                mKeyboardView.Visibility = ViewStates.Visible;
                Android.Views.Animations.Animation animation = AnimationUtils.LoadAnimation(
                    Context,
                    Resource.Animation.slide_in_bottom
                );
                mKeyboardView.ShowWithAnimation(animation);
            }
        }
    }
}