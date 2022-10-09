using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PlanetProject
{
    public class Planet
    {
        int radius;
        int OrbitalRadius;
        double CanvasWidth;
        double CanvasHeight;
        Ellipse ellipse;
        Canvas TheCanvas;
        double angle;
        double xPos;
        double yPos;


        public Planet(int PlanetRadius, int OrbitalRadius, Canvas TheCanvas, Color color)
        {
            this.radius = PlanetRadius;
            this.OrbitalRadius = OrbitalRadius;
            ellipse = new Ellipse();
            ellipse.Width = this.radius*2;
            ellipse.Height = this.radius*2;
            this.TheCanvas = TheCanvas;
            this.CanvasWidth = this.TheCanvas.Width;
            this.CanvasHeight = TheCanvas.Height;
            this.angle = 0; //This angle is in radians

            SolidColorBrush FillColor = new SolidColorBrush(color);
            SolidColorBrush StrokeColor = new SolidColorBrush(Colors.Black);
            ellipse.Fill = FillColor;
            ellipse.Stroke = StrokeColor;
            TheCanvas.Children.Add(ellipse);
            //Initialise the starting angle
            Random rnd = new Random();
            angle = rnd.NextDouble()*10;
            Debug.WriteLine(angle);
        }

        public void DrawPlanet()
        {
            xPos = CanvasWidth/2 - OrbitalRadius*Math.Cos(angle) - radius;
            yPos = CanvasHeight/2 - OrbitalRadius * Math.Sin(angle) - radius;
            Canvas.SetLeft(ellipse, xPos);
            Canvas.SetTop(ellipse, yPos);
        }

        public void MovePlanet()
        {
            //Increment the angle
            angle += 1/(OrbitalRadius + 0.01);
            DrawPlanet();
        }
    }
}
