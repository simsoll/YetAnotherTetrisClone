namespace YetAnotherTetrisClone

open System
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

open YetAnotherTetrisClone.CommonTypes

module Player =
    type Direction =
        | Up
        | Down
        | Left
        | Right

    type Figur =
        {
            Position: Vector2
            Facing: Direction
            DirectionToTileMap: (Direction * TileMap) list
        }    

    let randomFigur =
        let random = Random()
        fun (list : Figur list) -> list.[random.Next(list.Length)]

    let figurs = [ {
                     Position = Vector2.Zero
                     Facing = Up 
                     DirectionToTileMap = [ 
                                            (Up, 
                                                 [
                                                    Tile.create 1 2 Color.Blue
                                                    Tile.create 2 1 Color.Blue
                                                    Tile.create 2 2 Color.Blue
                                                    Tile.create 3 2 Color.Blue
                                                 ])
                                            (Down, 
                                                 [
                                                    Tile.create 1 1 Color.Blue
                                                    Tile.create 2 1 Color.Blue
                                                    Tile.create 2 2 Color.Blue
                                                    Tile.create 3 1 Color.Blue
                                                 ])
                                            (Left, 
                                                 [
                                                    Tile.create 2 1 Color.Blue
                                                    Tile.create 1 2 Color.Blue
                                                    Tile.create 2 2 Color.Blue
                                                    Tile.create 2 3 Color.Blue
                                                 ])
                                            (Right, 
                                                 [
                                                    Tile.create 1 1 Color.Blue
                                                    Tile.create 1 2 Color.Blue
                                                    Tile.create 2 2 Color.Blue
                                                    Tile.create 1 3 Color.Blue
                                                 ])
                                          ]
                   } ]
                   
    let spawn atPosition =
        let figur = randomFigur figurs
        {figur with Position = atPosition}

    let move figur direction =
        let deltaPosition = match direction with
                            | Up -> Vector2.Zero
                            | Left -> new Vector2(-1.0f, 0.0f)
                            | Down -> new Vector2(1.0f, 0.0f)
                            | Right -> new Vector2(1.0f, 0.0f)
        let newPosition = figur.Position + deltaPosition
        {figur with Position = newPosition}
        

    let rotate figur =
        let newFacing = match figur.Facing with
                        | Up -> Left
                        | Left -> Down
                        | Down -> Right
                        | Right -> Up
        {figur with Facing = newFacing}

    //collision detection should be kept elsewhere 
    //as the player should not know about other stuff
