using System;

namespace nightly.xam.keyboardevents
{
    public partial class Keyboard : IKeyboard
    {
        public event EventHandler OnKeyboardShow;
        public event EventHandler OnKeyboardHide;
        
        public static Lazy<IKeyboard> Instance { get; } = new Lazy<IKeyboard>(() => new Keyboard());

    }
}