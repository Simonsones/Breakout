using SFML.Graphics;
using SFML.System;
namespace breakout;

public class Tiles
{
    public Sprite sprite;
    public const float TileW = 48;
    public const float TileH = 24;
    public List<Vector2f> Positions;

    public Tiles()
    {
        sprite = new Sprite();
        sprite.Texture = new Texture("assets/tileBlue.png");
        sprite.Position = new Vector2f(250, 250);
        Vector2f tileTextureSize = (Vector2f)sprite.Texture.Size;
        sprite.Origin = 0.5f * tileTextureSize;
        sprite.Scale = new Vector2f(TileW / tileTextureSize.X, TileH / tileTextureSize.Y);

        Positions = new List<Vector2f>();
        for (int i = -2; i <= 2 ; i++)
        {
            for (int j = -2; j <= 2; j++)
            {
                var pos = new Vector2f(Program.ScreenW * 0.5f + i * TileW * 2, Program.ScreenH * 0.3f + j * TileH * 2);
                Positions.Add(pos);
            }
        }
        
        for (int i = -2; i <= 1; i++)
        {
            for (int j = 0; j <= 3; j++)
            {
                var pos = new Vector2f(Program.ScreenW * 0.6f + i * TileW * 2, Program.ScreenH * 0.2f + j * TileH * 2);
                Positions.Add(pos);
            }
        }

    }

    public void Draw(RenderTarget target)
    {
        for (int i = 0; i < Positions.Count; i++)
        {
            sprite.Position = Positions[i];
            target.Draw(sprite);
        }
    }
    
}