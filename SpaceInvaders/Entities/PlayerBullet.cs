using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class PlayerBullet : GameObject
{
    private const float SPEED_Y = 5;
    private bool _isAlive = true;

    public bool IsAlive
    {
        get { return _isAlive; }
    }

    public PlayerBullet(Texture2D image, Vector2 position) : base(image)
    {
        _bounds.Location = position.ToPoint();
    }

    public override void Update(float deltaTime)
    {
        _bounds.Y -= (int)(SPEED_Y);

        if (_bounds.Y <= 100 || WallColision(_bounds.Y))
        {
            _isAlive = false;
        }

    }

    public void Destroy()
    {
        _isAlive = false;
    }

    public bool WallColision(int y)
    {
        if(_bounds.X >= 144 && _bounds.X <= 188 && _bounds.Y <= 510)
        {
            return true;
        }
        else if(_bounds.X >= 261 && _bounds.X <= 305 && _bounds.Y <= 510)
        {
            return true;
        }
        else if (_bounds.X >= 378 && _bounds.X <= 422 && _bounds.Y <= 510)
        {
            return true;
        }
        else if (_bounds.X >= 495 && _bounds.X <= 539 && _bounds.Y <= 510)
        {
            return true;
        }
        else if (_bounds.X >= 612 && _bounds.X <= 656 && _bounds.Y <= 510)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}