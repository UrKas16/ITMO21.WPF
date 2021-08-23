using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace ITMO21.WPF.Lab07.ex1_2
{
    /// <summary>
    /// Логика взаимодействия для MyWindow.xaml
    /// </summary>
    public partial class MyWindow : Window
    {
        private bool _close;

        MainWindow wdn1 = null;
        public MyWindow()
        {
            InitializeComponent();
        }

        public new void Close()
        {
            _close = true;
            base.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_close)
            {
                return;
            }
            e.Cancel = true;
            Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            wdn1 = Owner as MainWindow;
            if (wdn1 != null)
            {
                wdn1.setText.Text = textBox.Text;
                PrintLogFile();
                if (textBox.Text != "")
                {
                    Close();
                }
            }
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (wdn1.myWin != null)
            {
                try
                {
                    wdn1.myWin = null;
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }          
        }

        private void PrintLogFile()
        {
            using (StreamWriter writer = new StreamWriter("C:\\Users\\kasyu\\source\\repos\\ITMO21.WPF\\ITMO21.WPF\\log.txt", true))
            {
                int count = 0;
                count += 1;
                writer.WriteLine("{0}. Внесено: {1} - {2}", count + 1, textBox.Text, DateTime.Now.ToShortDateString() + ", время: " + DateTime.Now.ToLongTimeString());
                writer.Flush();
            }
        }
    }
}
