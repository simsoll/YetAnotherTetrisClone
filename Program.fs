﻿namespace YetAnotherTetrisClone

module Program =
 
    [<EntryPoint>]
    let main argv =
        use g = new Game1()
        g.Run()
        0