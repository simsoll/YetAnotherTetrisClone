namespace YetAnotherTetrisClone
 
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

open Level
open Player

type Game1 () as this =
    inherit Game()
 
    do this.Content.RootDirectory <- "Content"
    let graphics = new GraphicsDeviceManager(this)
    let mutable spriteBatch = Unchecked.defaultof<_>
    let mutable texture = Unchecked.defaultof<_>    

    do graphics.PreferredBackBufferWidth <- 520
    do graphics.PreferredBackBufferHeight <- 520
                       
    let drawWall spritebatch _ =
        Level.draw spritebatch texture
    
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

        do base.Update (gameTime)
        ()
 
    override this.Draw (gameTime) =
        do this.GraphicsDevice.Clear Color.LightGray

        spriteBatch.Begin()

        drawWall spriteBatch gameTime

        spriteBatch.End()

        do base.Draw (gameTime)