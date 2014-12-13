namespace YetAnotherTetrisClone

open System
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

open YetAnotherTetrisClone.Common.Types

type Movement =
    | Left
    | Right
    | Down
    | Rotate

type Direction =
    | Up
    | Down
    | Left
    | Right

type Figur =
    {
        Position: Vector2
        Facing: Direction
        DirectionToTilesMap: Map<Direction, Tile list>
    } 

module Player =   

    let randomFigur =
        let random = Random()
        fun (list : Figur list) -> list.[random.Next(list.Length)]

    let figurs = [ {
                     Position = Vector2.Zero
                     Facing = Up 
                     DirectionToTilesMap = Map [ 
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

    let applyMovement figur movement =    
        let deltaPosition = match movement with
                            | Movement.Left -> new Vector2(-1.0f, 0.0f)
                            | Movement.Down -> new Vector2(0.0f, 1.0f)
                            | Movement.Right -> new Vector2(1.0f, 0.0f)
                            | _ -> Vector2.Zero
        let newPosition = figur.Position + deltaPosition
        {figur with Position = newPosition}
        

    let applyRotation figur =
        let newFacing = match figur.Facing with
                        | Up -> Left
                        | Left -> Down
                        | Down -> Right
                        | Right -> Up
        {figur with Facing = newFacing}

    let applyMovements (figur:Figur) (movements: Movement list) =

        let rec applyMovementsRec (figur:Figur) (movements:Movement list) =
            match movements with
            | [] -> figur
            | head::tail -> let figur = if head.Equals(Movement.Rotate) then applyRotation figur
                                        else applyMovement figur head
                            applyMovementsRec figur tail
        
        applyMovementsRec figur movements

    let draw         
        (spriteBatch:SpriteBatch) 
        (texture:Texture2D)
        (tileSize:int) 
        (figur:Figur) =
        figur.DirectionToTilesMap 
        |> Map.find figur.Facing
        |> List.map (fun tile -> tile.addPosition figur.Position)
        |> List.iter (fun tile -> tile.draw spriteBatch texture tileSize)
        ()