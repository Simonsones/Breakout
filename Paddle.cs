using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace breakout;

public class Paddle
{
    public Sprite sprite;
    public Vector2f size = new Vector2f();
    public const float PaddleW = 80f;
    public const float HalfPaddleW = PaddleW * 0.5f;
    public const float PaddleH = 20f;
    

    public Paddle()
    {
        sprite = new Sprite();
        sprite.Texture = new Texture("assets/paddle.png");
        sprite.Position = new Vector2f(250, 600);
        Vector2f paddleTextureSize = (Vector2f)sprite.Texture.Size;
        sprite.Origin = 0.5f * paddleTextureSize;
        sprite.Scale = new Vector2f(PaddleW / paddleTextureSize.X, PaddleH / paddleTextureSize.Y);
        
        size = new Vector2f(
            sprite.GetGlobalBounds().Width,
            sprite.GetGlobalBounds().Height
        );
    }

    public void Update(Ball ball, float deltaTime)
    {
        var newPos = sprite.Position;
        if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
        {
            newPos.X += deltaTime * 300.0f;
        }

        if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
        {
            newPos.X -= deltaTime * 300.0f;
        }

        if (newPos.X > Program.ScreenW - HalfPaddleW)
        {
            newPos.X = Program.ScreenW - HalfPaddleW;
        }

        if (newPos.X < 0 + HalfPaddleW)
        {
            newPos.X = 0 + HalfPaddleW;
        }

        sprite.Position = newPos;

        if (Collision.CircleRectangle(
                ball.sprite.Position, Ball.Radius,
                this.sprite.Position, size, out Vector2f hit))
        {
            ball.sprite.Position += hit;
            ball.Reflect(hit.Normalized());
        }
    }

    public void Draw(RenderTarget target)
    {
        target.Draw(sprite);
    }
}