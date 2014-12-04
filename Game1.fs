module YetAnotherTetrisClone
 
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

type Game1 () as x =
    inherit Game()
 
    do x.Content.RootDirectory <- "Content"
    let graphics = new GraphicsDeviceManager(x)
    let mutable spriteBatch = Unchecked.defaultof<_>
    
    override x.Initialize() =       
        x.IsMouseVisible <- true

        do base.Initialize()
        ()
 
    override x.LoadContent() =
        spriteBatch <- new SpriteBatch(x.GraphicsDevice)

        do base.LoadContent()
        ()
 
    override x.Update (gameTime) =

        do base.Update (gameTime)
        ()
 
    override x.Draw (gameTime) =
        do x.GraphicsDevice.Clear Color.LightGray

        spriteBatch.Begin()

        spriteBatch.End()

        do base.Draw (gameTime)