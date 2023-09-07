using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace breakout
{
    class Program
    {
        // Test Git
        public const int ScreenW = 500;
        public const int ScreenH = 700;
        
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            Ball ball = new Ball();
            using (RenderWindow window = new RenderWindow(new VideoMode(ScreenW, ScreenH), "Breakout"))
            {
                window.Closed += (s, e) => window.Close();

                while (window.IsOpen)
                {
                    float deltaTime = clock.Restart().AsSeconds();
                    window.DispatchEvents();
                    ball.Update(deltaTime);
                    window.Clear(new Color(131, 197, 235));
                    ball.Draw(window);
                    window.Display();
                }
            }
            
        }
    }
}