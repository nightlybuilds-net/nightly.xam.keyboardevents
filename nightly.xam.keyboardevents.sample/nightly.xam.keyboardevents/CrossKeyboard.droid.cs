using System;
using System.Diagnostics;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Views.InputMethods;

namespace nightly.xam.keyboardevents
{
    public partial class CrossCrossKeyboard : ICrossKeyboard
    {
        private readonly InputMethodManager _inputMethodManager;
        private bool _wasShown;
        private readonly View _mainView;


        public event EventHandler OnKeyboardShow;
        public event EventHandler OnKeyboardHide;

        public static Lazy<ICrossKeyboard> Instance { get; } = new Lazy<ICrossKeyboard>(() => new CrossCrossKeyboard());

        // ReSharper disable once MemberCanBePrivate.Global
        public static Activity Activity;

        private CrossCrossKeyboard()
        {
            var context = Application.Context;
            this._inputMethodManager = (InputMethodManager) context.GetSystemService(Context.InputMethodService);

            if (Activity == null)
                throw new Exception(
                    "Activity is NULL, please set CrossKeyboard.Activity = this in your Android project MainActivity");
            
            var window = Activity.Window;
            if (window?.DecorView?.ViewTreeObserver == null)
            {
                Console.WriteLine("Expression window?.DecorView?.ViewTreeObserver is NULL cannot subscribe");
                return;
            }

            window.DecorView.ViewTreeObserver.GlobalLayout += this.OnGlobalLayout;
            this._mainView = window.DecorView;
        }

        private void OnGlobalLayout(object sender, EventArgs e)
        {
            var r = new Rect();
            this._mainView.GetWindowVisibleDisplayFrame(r);
            var height = this._mainView.Height;
            var keypadHeight = height - r.Bottom;

            if (keypadHeight > height * 0.15)
            {
                // 0.15 ratio is perhaps enough to determine keypad height.
                // keyboard is opened
                if (this._wasShown) return;
                this._wasShown = true;
                this.OnKeyboardShow?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                // keyboard is closed
                if (!this._wasShown) return;
                this._wasShown = false;
                this.OnKeyboardHide?.Invoke(this, EventArgs.Empty);
            }

        }
    }
}