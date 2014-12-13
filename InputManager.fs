namespace YetAnotherTetrisClone

open System
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input

open Player

module InputManager =

    let movements (keyboardState:KeyboardState) = 
        seq 
            {
                if keyboardState.IsKeyDown(Keys.Space) then yield Movement.Rotate
                if keyboardState.IsKeyDown(Keys.Down) then yield Movement.Down
                if keyboardState.IsKeyDown(Keys.Left) then yield Movement.Left
                if keyboardState.IsKeyDown(Keys.Right) then yield Movement.Right
            }
        |> List.ofSeq
    ()

