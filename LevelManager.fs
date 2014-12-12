namespace YetAnotherTetrisClone

open System
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

open YetAnotherTetrisClone.Common.Types
open Player

module LevelManager =
    type Level =
        {
            Position: Vector2
            Width: int
            Height: int
            TileSize: int
            WallColor: Color
            Tiles: Tile list
            Difficulty: int
        }

    let addTiles level tiles =
        {level with Tiles = level.Tiles |> List.append tiles }

    let addWalls level =
        let bottomWall = seq {for i in 0..level.Width -> Tile.create i level.Height level.WallColor}
        let leftWall = seq {for i in 0..level.Height -> Tile.create 0 i level.WallColor}
        let rightWall = seq {for i in 0..level.Height -> Tile.create level.Width i level.WallColor}

        let walls = List.ofSeq(seq {yield! bottomWall; yield! leftWall; yield! rightWall})

        addTiles level walls

    let addObstacles level =
        //TODO
        level

    let draw
        (spriteBatch:SpriteBatch) 
        (texture:Texture2D)
        (level:Level) = 
            level.Tiles
            |> List.map (fun tile -> tile.addPosition level.Position)
            |> List.iter (fun tile -> tile.draw spriteBatch texture level.TileSize)
                        
            
            //let levelWall.draw spriteBatch texture tileSize