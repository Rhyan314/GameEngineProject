using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Hud
{
    private SpriteFont _mainFont;
    private String _scoreUI;
    private Vector2 _scoreUIPosition;

    public Hud(SpriteFont font)
    {
        _mainFont = font;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        _scoreUIPosition.X = 320;
        _scoreUIPosition.Y = 10;
        _scoreUI = "SCORE " + Globals.PLAYER_POINTS.ToString();


        spriteBatch.DrawString(_mainFont,_scoreUI,_scoreUIPosition,Color.White);
    }
}