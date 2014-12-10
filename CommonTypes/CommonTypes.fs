namespace YetAnotherTetrisClone.CommonTypes

open System
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

type Tile = 
    {
        Position: Vector2
        Color: Color
    }

type Tile with
    static member create x y color = {Position = new Vector2(float32 x, float32 y); Color = color}
    
type TileMap = Tile list  