namespace YetAnotherTetrisClone

open System
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

open YetAnotherTetrisClone.CommonTypes
open Player

module Level =  

    let levelWidth = 36
    let levelHeight = 56
    let tileSize = 8
    let wallColor = Color.Gray

    let bottomWall = seq {for i in 0..levelWidth -> Tile.create (i * tileSize) (levelHeight * tileSize) wallColor}
    let leftWall = seq {for i in 0..levelHeight -> Tile.create 0 (i * tileSize) wallColor}
    let rightWall = seq {for i in 0..levelHeight -> Tile.create (levelWidth * tileSize) (i * tileSize) wallColor}
    

    let levelWall =
        seq {yield! bottomWall; yield! leftWall; yield! rightWall}

    let draw 
        (spriteBatch:SpriteBatch) 
        (texture:Texture2D) =
        Seq.iter(fun (tile:Tile) ->
            spriteBatch.Draw(
                texture,
                new Rectangle(int tile.Position.X, int tile.Position.Y, tileSize, tileSize),
                System.Nullable(new Rectangle(0, 0, tileSize, tileSize)),
                tile.Color
            )
        ) levelWall