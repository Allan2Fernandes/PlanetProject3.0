
using System;

using System.Diagnostics;
using System.Threading;
using System.Timers;
using System.Windows;

using System.Windows.Media;

using System.Windows.Threading;

namespace PlanetProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Planet Mercury;
        Planet Venus;
        Planet Earth;
        bool usingDispatcherTimer = false;
        bool useAnotherTimer = false;
        bool useYetAnotherTime = true;
        //private static Timer AnotherTimer;
        private static System.Threading.Timer YetAnotherTimer;
        public MainWindow()
        {
            InitializeComponent();
            Mercury = new Planet(10, 70, MyCanvas, Colors.GreenYellow);
            Venus = new Planet(20, 120, MyCanvas, Colors.Orange);
            Earth = new Planet(25, 170, MyCanvas, Colors.Green);

            if (usingDispatcherTimer)
            {
      
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(1);
                timer.Tick += MoveMars;
                timer.Tick += MoveVenus;
                timer.Tick += MoveEarth;
                timer.Start();
         
            
            }
            else if(useAnotherTimer)
            {
                /*
                AnotherTimer = new System.Timers.Timer();
                // Hook up the Elapsed event for the timer. 
                AnotherTimer.Elapsed += MoveMarsTimer;
                AnotherTimer.Elapsed += MoveVenusTimer;
                AnotherTimer.Elapsed += MoveEarthTimer;
                AnotherTimer.Interval = 1;
      
                AnotherTimer.Enabled = true;
                */
                Debug.WriteLine("Temporarily disabled");
            }else if (useYetAnotherTime)
            {
                YetAnotherTimer = new System.Threading.Timer(Callback, null, 1, Timeout.Infinite);
            }
        }

        private void Callback(object state)
        {
            //Debug.WriteLine("Callback");
            
            this.Dispatcher.Invoke(() =>
            {
                Mercury.MovePlanet();
                Venus.MovePlanet();
                Earth.MovePlanet();
            });
            YetAnotherTimer.Change(1, Timeout.Infinite);
        }

        public void TestMethod(object source, ElapsedEventArgs e)
        {
            Debug.WriteLine("Ticking");
        }

        public void MoveMars(object sender, EventArgs e)
        {
            Mercury.MovePlanet();
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
                Mercury.MovePlanet();
            });
         }

        public void MoveVenusTimer(object source, ElapsedEventArgs e)
        {
            
            this.Dispatcher.Invoke(() =>
            {
                Venus.MovePlanet();
            });
        }
        public void MoveEarthTimer(object source, ElapsedEventArgs e)
        {
            
            this.Dispatcher.Invoke(() =>
            {
                Earth.MovePlanet();
            });
        }
    }
}
