using System.Text;
using System.Windows;
using System.Windows.Interop;
using KBEHtool;

namespace Demo1
{
    public partial class MainWindow : Window
    {
        List<string> keyList = new List<string>();
        
        public MainWindow()
        {
            IntPtr handle = new WindowInteropHelper(this).Handle;
            KBEH.StartKBEH(handle);
            InitializeComponent();
            KeyAction.AddKeyDownListener((keycode) => MyKeyDown(keycode));
            KeyAction.AddKeyUpListener((keycode) => MyKeyUp(keycode));
        }

        private void MyKeyDown(KeyCode key)
        {
            if (!keyList.Contains(key.ToString()))
            {
                keyList.Add(key.ToString());
            }

            StringBuilder stringBuilder = new StringBuilder();
            keyList.ForEach((s) =>
            {
                stringBuilder.Append(s);
                stringBuilder.Append(" ");
            });
            ds.Text = stringBuilder.ToString();
        }

        public void MyKeyUp(KeyCode key)
        {
            keyList.Remove(key.ToString());
            StringBuilder stringBuilder = new StringBuilder();
            keyList.ForEach((s) => { stringBuilder.Append(s); stringBuilder.Append(" "); });
            ds.Text = stringBuilder.ToString();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            keyList.ForEach((s) => { stringBuilder.Append(s); stringBuilder.Append(" "); });
            ds.Text = stringBuilder.ToString();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            KBEH.StopKBEH();
        }

        private void PressVBK(object sender, RoutedEventArgs e)
        {
            //KeyAction.PressKey(KeyCode.A,1000);
            KeyAction.PressKey(new [] { KeyCode.LeftControl , KeyCode.Space},1000);
        }
    }
}