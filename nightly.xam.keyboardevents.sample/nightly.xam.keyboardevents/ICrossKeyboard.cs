using System;

namespace nightly.xam.keyboardevents
{
    public interface ICrossKeyboard
    {
        /// <summary>
        /// Raised when keyboard is show
        /// </summary>
        event EventHandler OnKeyboardShow;
        
        /// <summary>
        /// Raised when keyboard is hide
        /// </summary>
        event EventHandler OnKeyboardHide;
    }
}