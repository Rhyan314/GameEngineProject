using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Player : GameObject
{
    private const float SPEED_X = 5;
    private Rectangle _previousBounds;

    public List<PlayerBullet> _playerBullets = new List<PlayerBullet>();
    private Texture2D _playerBulletImage;

    public Player(Texture2D playerImage, Texture2D playerBullet) : base(playerImage)
    {
        _playerBulletImage = playerBullet;
    }

    public override void Initialize()
    {
        _bounds.X = Globals.SCREEN_WIDTH/2 - 8;
        _bounds.Y = Globals.SCREEN_HEIGHT - 32;
    }

    public override void Update(float deltaTime)
    {
        _previousBounds = _bounds;

        float direction = 0;
        if (Input.GetKey(Keys.A))
        {
            direction = -1;
        }
        if (Input.GetKey(Keys.D))
        {
            direction = 1;
        }

        if (direction != 0)
        {
            int nextX = _bounds.X + (int)(direction * SPEED_X);

            if (nextX >= 100 && nextX + _bounds.Width <= Globals.SCREEN_WIDTH - 100)
            {
                _bounds.X = nextX;
            }
        }

        if (Input.GetKeyDown(Keys.Space))
        {
            Shoot();
        }

        // Atualizar o estado das balas
        foreach (var playerBullet in _playerBullets)
        {
            playerBullet.Update(deltaTime);
        }

        // Remover balas mortas
        _playerBullets.RemoveAll(bullet => !bullet.IsAlive);


    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_image, _bounds, Color.White);

        // Desenhar as balas
        foreach (var bullet in _playerBullets)
        {
            bullet.Draw(spriteBatch);
        }

    }

    private void Shoot()
    {
        // Disparar uma nova bala a partir da posição do jogador
        PlayerBullet playerBullet = new PlayerBullet(_playerBulletImage,new Vector2(_bounds.X + _bounds.Width / 2, _bounds.Y));
        _playerBullets.Add(playerBullet);
    }

}
