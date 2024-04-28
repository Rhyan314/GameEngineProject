using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Wall
{
    private Texture2D _wallImage;
    private Vector2 _wallPosition;
    public Wall(Texture2D wallImage) 
    {
        _wallImage = wallImage; 
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        int wallCount = 5;
        int wallWidth = 44;
        int availableWidth = Globals.SCREEN_WIDTH - 144 * 2 - wallWidth * wallCount; 
        int spacing = availableWidth / (wallCount - 1); 

        _wallPosition.Y = Globals.SCREEN_HEIGHT - 100; 

        for(int i = 0; i < wallCount; i++)
        {
            _wallPosition.X = 144 + i * (spacing + wallWidth); 
            spriteBatch.Draw(_wallImage, _wallPosition, Color.White);
        }  
        
    }
}
