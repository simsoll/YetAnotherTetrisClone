namespace YetAnotherTetrisClone.Common

open System
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

module Types =
    type Tile = 
        {
            Position: Vector2
            Color: Color
        }

    type Tile with
        static member create x y color = {Position = new Vector2(float32 x, float32 y); Color = color}
    
        member this.draw         
            (spriteBatch:SpriteBatch) 
            (texture:Texture2D)
            (tileSize:int) =
                spriteBatch.Draw(
                    texture,
                    new Rectangle(int this.Position.X * tileSize, int this.Position.Y * tileSize, tileSize, tileSize),
                    System.Nullable(new Rectangle(0, 0, tileSize, tileSize)),
                    this.Color)
        member this.addPosition position =
            {this with Position = this.Position + position}
            

//    type TileMap = 
//        {
//            Tiles: Tile list
//        }
//
//    type TileMap with
//        member this.draw
//            (spriteBatch:SpriteBatch) 
//            (texture:Texture2D)
//            (tileSize:int) =
//                this.Tiles
//                |> List.iter (fun tile -> tile.draw spriteBatch texture tileSize)
//
//        member this.append
//            (tileMap:TileMap) =
//                let tiles = this.Tiles
//                            |> List.append tileMap.Tiles
//
//                {Tiles = tiles}