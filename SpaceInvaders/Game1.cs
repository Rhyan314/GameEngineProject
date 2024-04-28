using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceInvaders;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private SpriteFont _mainFont;

    private IScreen _currentScreen;
    private IScreen _homeScreen;
    private IScreen _creditsScreen;
    private IScreen _gameScreen;
    private IScreen _gameoverScreen;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _graphics.PreferredBackBufferWidth  = 800;
        _graphics.PreferredBackBufferHeight = 600;

    }

    protected override void Initialize()
    {
        base.Initialize();

        Globals.SCREEN_WIDTH = _graphics.PreferredBackBufferWidth;
        Globals.SCREEN_HEIGHT = _graphics.PreferredBackBufferHeight;
        Globals.MAIN_FONT = _mainFont;
        Globals.GameInstance = this;

        _currentScreen.Initialize();

    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _mainFont = Content.Load<SpriteFont>("mainFont");

        _homeScreen = new HomeScreen();
        _homeScreen.LoadContent(Content);

        _creditsScreen = new CreditsScreen();
        _creditsScreen.LoadContent(Content);

        _gameScreen = new GameScreen();
        _gameScreen.LoadContent(Content);

        _gameoverScreen = new Gameover();
        _gameoverScreen.LoadContent(Content);


        _currentScreen = _homeScreen;
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _currentScreen.Update((int)gameTime.ElapsedGameTime.TotalSeconds);
        
        Input.Update();
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin();
        _currentScreen.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }

    public void ChangeScreen(EScreen screenType)
    {
        switch (screenType)
        {
            case EScreen.Home:
                _currentScreen = _homeScreen;
                break;
            case EScreen.Credits:
                _currentScreen = _creditsScreen;
                break;
            case EScreen.Game:
                _currentScreen = _gameScreen;
                break;
            case EScreen.GameOver:
                _currentScreen = _gameoverScreen;
                break;
            
        }

        _currentScreen.Initialize();
    }
}
