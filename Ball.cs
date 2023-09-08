using SFML.Graphics;
using SFML.System;

namespace breakout
{
    public class Ball
    {
        public Sprite sprite;
        public const float Diameter = 20.0f;
        public const float Radius = Diameter * .5f;
        public Vector2f direction = new Vector2f(1, 1) / MathF.Sqrt(2.0f);
        public int Health;
        public int Score;
        public Text gui;


        public Ball()
        {
            sprite = new Sprite();
            sprite.Texture = new Texture("assets/ball.png");
            sprite.Position = new Vector2f(200, 200);
            Vector2f ballTextureSize = (Vector2f)sprite.Texture.Size;
            sprite.Origin = 0.5f * ballTextureSize;
            sprite.Scale = new Vector2f(Diameter / ballTextureSize.X, Diameter / ballTextureSize.Y);

            Health = 3;
            Score = 0;
            
            gui = new Text();
            gui.CharacterSize = 24;
            gui.Font = new Font("assets/future.ttf");
            
        }

        public void Update(Paddle paddle, float deltaTime)
        {
            var newPos = sprite.Position;
            newPos += direction * deltaTime * 500.0f;
            if (newPos.X > Program.ScreenW - Radius)
            {
                newPos.X = Program.ScreenW - Radius;
                Reflect(new Vector2f(-1,0));
            }
            if (newPos.X < 0 + Radius)
            {
                newPos.X = 0 + Radius;
                Reflect(new Vector2f(1,0));
            }
            if (newPos.Y > Program.ScreenH - Radius)
            {
                newPos.Y = paddle.sprite.Position.Y - Paddle.PaddleH / 2 - Radius;
                newPos.X = paddle.sprite.Position.X;
                Health--;
                //direction = new Vector2f(new Random().Next() % 2, new Random().Next() % 2) / MathF.Sqrt(2.0f);
                //HJÄLP "multiply the vector w the length????????????
            }
            if (newPos.Y < 0 + Radius)
            {
                newPos.Y = 0 + Radius;
                Reflect(new Vector2f(0,1));
            }
            sprite.Position = newPos;
        }

        public void Draw(RenderTarget target)
        {
            target.Draw(sprite);
            gui.DisplayedString = $"Health: {Health}";
            gui.Position = new Vector2f(12, 8);
            target.Draw(gui);

            gui.DisplayedString = $"Score: {Score}";
            gui.Position = new Vector2f(Program.ScreenW - gui.GetGlobalBounds().Width - 12, 8);
            target.Draw(gui);
        }

        public void Reflect(Vector2f normal)
        {
            direction -= normal * (2 * (direction.X * normal.X + direction.Y * normal.Y));
        }
    }
    
}
