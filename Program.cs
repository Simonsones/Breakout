using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace breakout
{
    class Program
    {
        public const int ScreenW = 500;
        public const int ScreenH = 700;
        
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            Ball ball = new Ball();
            Paddle paddle = new Paddle();
            Tiles tiles = new Tiles();
            
            using (RenderWindow window = new RenderWindow(new VideoMode(ScreenW, ScreenH), "Breakout"))
            {
                window.Closed += (s, e) => window.Close();

                while (window.IsOpen)
                {
                    float deltaTime = clock.Restart().AsSeconds();
                    window.DispatchEvents();
                    ball.Update(paddle, deltaTime);
                    paddle.Update(ball, deltaTime);
                    window.Clear(new Color(131, 197, 235));
                    ball.Draw(window);
                    paddle.Draw(window);
                    tiles.Draw(window);
                    
                    window.Display();
                    if (ball.Health <= 0)
                    {
                        ball = new Ball();
                        paddle = new Paddle();
                    }
                }
            }
            
        }
    }
}