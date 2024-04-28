using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

public class Gameover : IScreen
{
    private Texture2D _gameover;
    private Texture2D _background;
    private Button _homeButton;
    public void Initialize()
    {
        _homeButton.Position = new Point(270,500);
    }

    public void LoadContent(ContentManager content)
    {
        _gameover = content.Load<Texture2D>("Generics/GameOverTwo");
        _background = content.Load<Texture2D>("Generics/Background");
        _homeButton = new Button(content.Load<Texture2D>("Buttons/Home"),Home);
    }

    public void Update(float deltaTime)
    {
        _homeButton.Update(deltaTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_background,new Rectangle(0, 0, 800, 600), Color.White);
        spriteBatch.Draw(_gameover,new Vector2(40,0),Color.White);
        _homeButton.Draw(spriteBatch);
    }

    private void Home()
    {
        Globals.GameInstance.ChangeScreen(EScreen.Home);
    }
}