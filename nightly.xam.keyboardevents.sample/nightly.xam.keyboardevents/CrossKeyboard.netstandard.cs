using System;

namespace nightly.xam.keyboardevents
{
    public partial class CrossCrossKeyboard : ICrossKeyboard
    {
        public event EventHandler OnKeyboardShow;
        public event EventHandler OnKeyboardHide;
        
        public static Lazy<ICrossKeyboard> Instance { get; } = new Lazy<ICrossKeyboard>(() => new CrossCrossKeyboard());

    }
}