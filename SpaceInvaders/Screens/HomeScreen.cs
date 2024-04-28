using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

public class HomeScreen : IScreen
{

    private Texture2D _background;
    private Texture2D _homeLogo;

    private Button _playButton;
    private Button _creditsButton;
    public void Initialize()
    {
        _playButton.Position = new Point(210, 350);
        _creditsButton.Position = new Point(210,450);
    }

    public void LoadContent(ContentManager content)
    {
        _background = content.Load<Texture2D>("Generics/Background");
        _homeLogo = content.Load<Texture2D>("Generics/HomeLogo");

        _playButton = new Button(content.Load<Texture2D>("Buttons/Play"), Play);
        _creditsButton = new Button(content.Load<Texture2D>("Buttons/Credits"),Credits);
    }

    public void Update(float deltaTime)
    {
        _playButton.Update(deltaTime);
        _creditsButton.Update(deltaTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_background, new Rectangle(0, 0, 800, 600), Color.White);
        spriteBatch.Draw(_homeLogo, new Rectangle(250, 0, 300, 300), Color.White);
        _playButton.Draw(spriteBatch);
        _creditsButton.Draw(spriteBatch);
    }

    private void Play()
    {
        Globals.GameInstance.ChangeScreen(EScreen.Game);
    }
    private void Credits()
    {
        Globals.GameInstance.ChangeScreen(EScreen.Credits);
    }
}