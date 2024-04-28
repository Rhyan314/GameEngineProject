using System.Drawing;
using System.Numerics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class GameScreen : IScreen
{

    private Player _player;
    private Enemy _enemy;
    private Hud _hud;
    private Wall _wall;

    public void LoadContent(ContentManager content)
    {   
        Texture2D playerBulletImage = content.Load<Texture2D>("Sprites/PlayerBullet");
        Texture2D playerImage = content.Load<Texture2D>("Sprites/Player");
        _player = new Player(playerImage,playerBulletImage);

        Texture2D enemyOneImage = content.Load<Texture2D>("Sprites/EnemyOne");
        Texture2D enemyTwoImage = content.Load<Texture2D>("Sprites/EnemyTwo");
        Texture2D enemyThreeImage = content.Load<Texture2D>("Sprites/EnemyThree");
        Texture2D enemyExplosionEndImage = content.Load<Texture2D>("Sprites/EnemyExplosionEnd");
        _enemy = new Enemy(enemyOneImage,enemyTwoImage,enemyThreeImage,enemyExplosionEndImage, _player);

        Texture2D wallImage = content.Load<Texture2D>("Sprites/Wall");
        _wall = new Wall(wallImage);

        SpriteFont font = content.Load<SpriteFont>("titleFont");
        _hud = new Hud(font);

    }

    public void Initialize()
    {
        _player.Initialize();
        _enemy.Initialize();

        Globals.PLAYER_POINTS = 0;
    }

    public void Update(float deltaTime)
    {
        Input.Update();

        _player.Update(deltaTime);
        _enemy.Update(deltaTime);

        if (Globals.PLAYER_POINTS == 600)
        {
            EndGame();
        }

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        _player.Draw(spriteBatch);
        _enemy.Draw(spriteBatch);
        _hud.Draw(spriteBatch);
        _wall.Draw(spriteBatch);

    }

    private void EndGame()
    {
        Globals.GameInstance.ChangeScreen(EScreen.GameOver);
    }
}