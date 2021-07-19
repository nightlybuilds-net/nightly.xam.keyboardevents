using System;
using System.Diagnostics;
using Android.App;
using Android.Content;
using Android.Views.InputMethods;

namespace nightly.xam.keyboardevents
{
    public partial class Keyboard : IKeyboard
    {
        private readonly InputMethodManager _inputMethodManager;
        private bool _wasShown;

        public event EventHandler OnKeyboardShow;
        public event EventHandler OnKeyboardHide;

        public static Lazy<IKeyboard> Instance { get; } = new Lazy<IKeyboard>(() => new Keyboard());

        public static Activity Activity;

        private Keyboard()
        {
            var context = Application.Context;
            this._inputMethodManager = (InputMethodManager)context.GetSystemService(Context.InputMethodService);

            if (Activity == null)
                throw new Exception("Activity is NULL, please set Keyboard.Activity = this in your Android project MainActivity");
            
            var window = Activity.Window;
            if (window?.DecorView?.ViewTreeObserver == null)
            {
                Console.WriteLine("Expression window?.DecorView?.ViewTreeObserver is NULL cannot subscribe");
                return;
            }
            window.DecorView.ViewTreeObserver.GlobalLayout += this.OnGlobalLayout;
        }

        private void OnGlobalLayout(object sender, EventArgs e)
        {
            if(!this._wasShown && this.IsKeyboardVisible())
            {
                this.OnKeyboardShow?.Invoke(this, EventArgs.Empty);
                this._wasShown = true;
            }
            else if(this._wasShown && !this.IsKeyboardVisible())
            {
                this.OnKeyboardHide?.Invoke(this, EventArgs.Empty);
                this._wasShown = false;
            }
        }

        private bool IsKeyboardVisible()
        {
            return this._inputMethodManager.IsAcceptingText;
        }
    }
}