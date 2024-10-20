using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using KBEHtool;
using MessageBox = System.Windows.Forms.MessageBox;

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
            KeyAction.AddKeyDownListener((kc) => MyKeyDown(kc));
            KeyAction.AddKeyUpListener((kc) => MyKeyUp(kc));
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

    }
}
