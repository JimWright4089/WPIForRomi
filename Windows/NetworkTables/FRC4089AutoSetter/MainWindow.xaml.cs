using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FRC4089AutoSetter
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    Timer mDisplay;
    Thread mThread;
    bool mRunThread = true;
    int mCount = 0;
    public MainWindow()
    {
      InitializeComponent();
      lStatus.Content = "Test";
      mThread = new Thread(RunThread);
      mThread.Start();

      mDisplay = new Timer(Display, new AutoResetEvent(true), 0, 1000);
    }

    public void Display(Object stateInfo)
    {
      lStatus.Content = mCount.ToString();
    }

    public void RunThread()
    {
      while (true == mRunThread)
      {
        mCount++;
        Thread.Sleep(100);
      }

    }
  }
}
