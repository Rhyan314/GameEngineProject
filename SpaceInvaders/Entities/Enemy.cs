using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Enemy
{
    private Texture2D _enemyOneImage;
    private Texture2D _enemyTwoImage;
    private Texture2D _enemyThreeImage;
    private Texture2D _enemyExplosionImage;
    private Texture2D _enemyExplosionEndImage;

    private Rectangle[] _enemyOneFrames;
    private Rectangle[] _enemyTwoFrames;
    private Rectangle[] _enemyThreeFrames;

    private Vector2[,] _enemyPositions;
    private bool[,] _enemyDestroyed;
    private double[,] _destroyTime;

    private double _time;
    private int _index;

    private float _speed;
    private int _direction;

    private Player _player;

    public Enemy(Texture2D enemyOneImage, Texture2D enemyTwoImage, Texture2D enemyThreeImage, Texture2D enemyExplosionEndImage, Player player)
    {
        _enemyOneImage = enemyOneImage;
        _enemyTwoImage = enemyTwoImage;
        _enemyThreeImage = enemyThreeImage;
        _enemyExplosionEndImage = enemyExplosionEndImage;
        _player = player;

        Initialize();
    }

    public void Initialize()
    {
        _enemyOneFrames = new Rectangle[2]
        {
            new Rectangle(0, 0, 24, 16), 
            new Rectangle(0, 20, 24, 16)
        };

        _enemyTwoFrames = new Rectangle[2]
        {
            new Rectangle(0, 0, 22, 16),
            new Rectangle(0, 20, 22, 16)
        };

        _enemyThreeFrames = new Rectangle[2]
        {
            new Rectangle(0, 0, 16, 16),
            new Rectangle(0, 20, 16, 16)
        };

        _enemyPositions = new Vector2[5, 12];
        _enemyDestroyed = new bool[5, 12];
        _destroyTime = new double[5, 12];

        for (int row = 0; row < 5; row++)
        {
            for (int col = 0; col < 12; col++)
            {
                int posX = 100 + col * 34;
                int posY = 100 + row * 25;

                _enemyPositions[row, col] = new Vector2(posX, posY);
                _enemyDestroyed[row, col] = false;
                _destroyTime[row, col] = 0.0;
            }
        }

        _index = 0;
        _time = 0.0;

        _speed = 1.0f;
        _direction = 1;
    }

    public void Update(float deltaTime)
    {
        _time += 0.05;

        for (int row = 0; row < 5; row++)
        {
            for (int col = 0; col < 12; col++)
            {
                if (!_enemyDestroyed[row, col])
                {

                    _enemyPositions[row, col].X += _speed * _direction;

                    if (_enemyPositions[row, col].X <= 100)
                    {
                        _direction = 1;
                    }
                    else if (_enemyPositions[row, col].X >= Globals.SCREEN_WIDTH - 100)
                    {
                        _direction = -1;
                    }

                    if (_time >= 0.5)
                    {
                        _index = (_index + 1) % 2;
                        _time = 0; 

                    }

                    foreach (var bullet in _player._playerBullets)
                    {
                        if (bullet.Bounds.Intersects(GetEnemyBounds(row, col)))
                        {
                            _enemyDestroyed[row, col] = true;
                            _destroyTime[row, col] = _time;
                            Globals.PLAYER_POINTS += 10;
                            _speed += 0.05f;  
                            bullet.Destroy();
                            break;
                        }
                    }
                }
            }
        }

        for (int row = 0; row < 5; row++)
        {
            for (int col = 0; col < 12; col++)
            {
                if (_enemyDestroyed[row, col] && _time - _destroyTime[row, col] > 1.0) 
                {
                    _enemyDestroyed[row, col] = true;
                    
                }
            }
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        
        for (int row = 0; row < 5; row++)
        {
            for (int col = 0; col < 12; col++)
            {
                if (!_enemyDestroyed[row, col])
                {
                    Rectangle frame;
                    Texture2D texture;

                    if (row < 2)
                    {
                        texture = _enemyThreeImage;
                        frame = _enemyThreeFrames[_index];
                    }
                    else if (row < 4)
                    {
                        texture = _enemyTwoImage;
                        frame = _enemyTwoFrames[_index];
                    }
                    else
                    {
                        texture = _enemyOneImage;
                        frame = _enemyOneFrames[_index];
                    }

                    spriteBatch.Draw(texture, _enemyPositions[row, col], frame, Color.White);
                }
                else
                {
                    spriteBatch.Draw(_enemyExplosionEndImage, _enemyPositions[row, col], Color.White);      
                }
            }
        }

        
    }

    private Rectangle GetEnemyBounds(int row, int col)
    {
        Rectangle bounds;
        if (row < 2)
        {
            bounds = new Rectangle((int)_enemyPositions[row, col].X, (int)_enemyPositions[row, col].Y, 16, 16);
        }
        else if (row < 4)
        {
            bounds = new Rectangle((int)_enemyPositions[row, col].X, (int)_enemyPositions[row, col].Y, 22, 16);
        }
        else
        {
            bounds = new Rectangle((int)_enemyPositions[row, col].X, (int)_enemyPositions[row, col].Y, 24, 16);
        }
        return bounds;
    }

    private void EndGame()
    {
        Globals.GameInstance.ChangeScreen(EScreen.GameOver);
    }

}



