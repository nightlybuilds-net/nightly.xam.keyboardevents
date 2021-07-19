using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace nightly.xam.keyboardevents.sample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Keyboard.Instance.Value.OnKeyboardShow += (sender, args) =>
            {
                this.KeyBoardStatus.Text = "OPEN";
                Console.WriteLine("OPEN");
            };
            
            Keyboard.Instance.Value.OnKeyboardHide += (sender, args) =>
            {
                this.KeyBoardStatus.Text = "CLOSED";
                Console.WriteLine("CLOSED");
            };
        }
    }
}