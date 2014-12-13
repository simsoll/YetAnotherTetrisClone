namespace YetAnotherTetrisClone
 
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input

open LevelManager
open Player

type Game1 () as this =
    inherit Game()
 
    do this.Content.RootDirectory <- "Content"
    let graphics = new GraphicsDeviceManager(this)
    let mutable spriteBatch = Unchecked.defaultof<_>
    let mutable texture = Unchecked.defaultof<_>    

    do graphics.PreferredBackBufferWidth <- 520
    do graphics.PreferredBackBufferHeight <- 520
                 
    let level = 
        {
            Position = new Vector2(5.0f, 5.0f)
            Width = 30
            Height = 50
            TileSize = 8
            WallColor = Color.Gray
            Tiles = []
            Difficulty = 0
        }
        |> addWalls

    let mutable player = Player.spawn Vector2.Zero
                       
    override this.Initialize() =       
        this.IsMouseVisible <- true

        do base.Initialize()
        ()
 
    override this.LoadContent() =
        spriteBatch <- new SpriteBatch(this.GraphicsDevice)
        texture <- this.Content.Load<Microsoft.Xna.Framework.Graphics.Texture2D>("particle")


        do base.LoadContent()
        ()
 
    override this.Update (gameTime) =
        
        player <- Keyboard.GetState()
                  |> InputManager.movements
                  |> Player.applyMovements player

        do base.Update (gameTime)
        ()
    override this.Draw (gameTime) = 

        do this.GraphicsDevice.Clear Color.LightGray

        spriteBatch.Begin()

        LevelManager.draw spriteBatch texture level
        Player.draw spriteBatch texture level.TileSize player

        spriteBatch.End()

        do base.Draw (gameTime)