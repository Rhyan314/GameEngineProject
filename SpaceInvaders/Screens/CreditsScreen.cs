using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

public class CreditsScreen : IScreen
{
    private Texture2D _background;
    private SpriteFont _titleFont;
    private Button _returnButton;
    public void Initialize()
    {
        _returnButton.Position = new Point(Globals.SCREEN_WIDTH/2 - 66,510);
    }

    public void LoadContent(ContentManager content)
    {
        _background = content.Load<Texture2D>("Generics/Background");
        _titleFont = content.Load<SpriteFont>("titleFont");
        _returnButton = new Button(content.Load<Texture2D>("Buttons/Return"),Return);
    }

    public void Update(float deltaTime)
    {
        _returnButton.Update(deltaTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_background, new Rectangle(0, 0, 800, 600), Color.White);
        spriteBatch.DrawString(_titleFont,"Trabalho de Game Engine\n\n\n\n",new Vector2(25,10),Color.LimeGreen);
        spriteBatch.DrawString(_titleFont,"Breno Almeida    01527793\n\nLucas Benicio     01506393\n\nLuis Gustavo     01515839\n\nLuiz Eduardo     01224564\n\nMarcus Eduardo     01533942\n\nRhyan Carlos    01539352\n\nZaque Mateus    01529166", new Vector2(25,100), Color.White);
        _returnButton.Draw(spriteBatch);
    }

    private void Return()
    {
        Globals.GameInstance.ChangeScreen(EScreen.Home);
    }
}