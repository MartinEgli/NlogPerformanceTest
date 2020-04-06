using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using NLog;
using NLog.Config;

namespace NlogPerformanceTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public override string ToString()
        {
            return "MainWindow";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var logger = LogManager.GetCurrentClassLogger();
            logger.Log(LogLevel.Debug, "Start");
            var loops = 10000;
            int i;
            var watch = new Stopwatch();
            watch.Start();
            for (i = 0; i < loops; i++)
            {
                logger.Log(LogLevel.Debug, "Index {0} {1}", i, this);
                logger.Log(LogLevel.Info, "Info Index {0}", this);
            }
            watch.Stop();
            var milliseconds = watch.ElapsedMilliseconds;
            logger.Log(LogLevel.Debug, "milliseconds {0}", milliseconds);
            Debug.WriteLine("milliseconds {0}", milliseconds);
            watch.Reset();


            watch.Start();
            for (i = 0; i < loops; i++)
            {
                logger.Log(LogLevel.Debug, $"Index {i} {this}");
                logger.Log(LogLevel.Info, $"Info Index  {this}");
            }
            watch.Stop();
            milliseconds = watch.ElapsedMilliseconds;
            logger.Log(LogLevel.Debug, "milliseconds {0}", milliseconds);
            Debug.WriteLine("milliseconds {0}", milliseconds);
            watch.Reset();


            watch.Start();
            for (i = 0; i < loops; i++)
            {
                logger.Log(LogLevel.Debug, "Index " + i + this);
                logger.Log(LogLevel.Info, "Info Index " + this);
            }
            watch.Stop();
            milliseconds = watch.ElapsedMilliseconds;
            logger.Log(LogLevel.Debug, "milliseconds {0}", milliseconds);
            Debug.WriteLine("milliseconds {0}", milliseconds);
            watch.Reset();

            watch.Start();
            for (i = 0; i < loops; i++)
            {
                logger.Log(LogLevel.Debug, String.Format("Index {0} {1}", i, this));
                logger.Log(LogLevel.Info, String.Format("Info Index {0}", this));
            }
            watch.Stop();
            milliseconds = watch.ElapsedMilliseconds;
            logger.Log(LogLevel.Debug, "milliseconds {0}", milliseconds);
            Debug.WriteLine("milliseconds {0}", milliseconds);
            watch.Reset();

        }
    }
}
