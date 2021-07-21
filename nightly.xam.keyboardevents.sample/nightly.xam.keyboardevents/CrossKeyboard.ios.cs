using System;
using UIKit;

namespace nightly.xam.keyboardevents
{
    public partial class CrossCrossKeyboard : ICrossKeyboard
    {
        private bool _isShowed;
        
        public event EventHandler OnKeyboardShow;
        public event EventHandler OnKeyboardHide;

        public static Lazy<ICrossKeyboard> Instance { get; } = new Lazy<ICrossKeyboard>(() => new CrossCrossKeyboard());

        private CrossCrossKeyboard()
        {
            UIKeyboard.Notifications.ObserveDidShow(this.KeyboardShow);
            UIKeyboard.Notifications.ObserveDidHide(this.KeyboardHide);
        }

        private void KeyboardHide(object sender, UIKeyboardEventArgs e)
        {
            if(!this._isShowed) return;
            this.OnKeyboardHide?.Invoke(this, EventArgs.Empty);
            this._isShowed = false;
        }

        private void KeyboardShow(object sender, UIKeyboardEventArgs e)
        {
            if (this._isShowed) return;
            this.OnKeyboardShow?.Invoke(this, EventArgs.Empty);
            this._isShowed = true;
        }
    }
}