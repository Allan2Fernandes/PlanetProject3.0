using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace PlanetProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Planet Mars;
        Planet Venus;
        Planet Earth;
        bool usingDispatcherTimer = false;
        private static System.Timers.Timer aTimer;
        public MainWindow()
        {
            InitializeComponent();
            Mars = new Planet(10, 70, MyCanvas, Colors.Brown);
            Venus = new Planet(20, 120, MyCanvas, Colors.Orange);
            Earth = new Planet(25, 170, MyCanvas, Colors.Green);

            /*
             * dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0,0,1);
                dispatcherTimer.Start();
             */

            if (usingDispatcherTimer)
            {
      
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(1);
                timer.Tick += MoveMars;
                timer.Tick += MoveVenus;
                timer.Tick += MoveEarth;
                timer.Start();
         
            
            }
            else
            {
                aTimer = new System.Timers.Timer();
                // Hook up the Elapsed event for the timer. 
                aTimer.Elapsed += MoveMarsTimer;
                aTimer.Elapsed += MoveVenusTimer;
                aTimer.Elapsed += MoveEarthTimer;
                aTimer.Interval = 1;
      
                aTimer.Enabled = true;
            }
        }

        public void TestMethod(object source, ElapsedEventArgs e)
        {
            Debug.WriteLine("Ticking");
        }

        public void MoveMars(object sender, EventArgs e)
        {
            Mars.MovePlanet();
        }
        public void MoveVenus(object sender, EventArgs e)
        {
            Venus.MovePlanet();
        }
        public void MoveEarth(object sender, EventArgs e)
        {
            Earth.MovePlanet();
        }

        public void MoveMarsTimer(object source, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                // your code here.
                Mars.MovePlanet();
            });
         }

        public void MoveVenusTimer(object source, ElapsedEventArgs e)
        {
            
            this.Dispatcher.Invoke(() =>
            {
                // your code here.
                Venus.MovePlanet();
            });
        }
        public void MoveEarthTimer(object source, ElapsedEventArgs e)
        {
            
            this.Dispatcher.Invoke(() =>
            {
                // your code here.
                Earth.MovePlanet();
            });
        }
    }
}
