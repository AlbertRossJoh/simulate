module Simulate
open System

type Drone (startPos : int * int, destPos : int * int, speed : int) = //speed is in cm pr 
    let mutable (sPos1, sPos2) = startPos //startpo, but mutable
    let (dPos1, dPos2) = destPos //destpos, but not
    let mutable isFlying = true
    member this.IsFlying = isFlying
    member this.Position = (sPos1, sPos2)
    member this.Speed = speed
    member this.Destination = destPos
    member this.Fly (n : int) = 
        if not (this.AtDestination ()) then
            let (a, b) = 
                (dPos1 - sPos1, dPos2 - sPos2)
            let lenVec =
                (float a**2. + float b**2.)
                |> sqrt
            let unitVec (len : float) = 
                ((float a/len),(float b/len))
            let speedXY (c : int) =
                let (x1, y1) = unitVec lenVec
                (x1 * (float c), y1 * (float c))
            sPos1 <- sPos1 + int ((fst (speedXY n))*0.01)
            sPos2 <- sPos2 + int ((snd (speedXY n))*0.01)
        else
            sPos1 <- dPos1
            sPos2 <- dPos2
    member this.AtDestination () =
        let dist =
            Math.Abs (sPos1 - dPos1) * Math.Abs (sPos1 - dPos1) + Math.Abs (sPos2 - dPos2) * Math.Abs (sPos2 - dPos2)
            |> float
            |> sqrt
            |> int
        if dist * 100 <= int (float this.Speed) && startPos <> (sPos1, sPos2) then //distance is in cm bc. speed is in cm/s
            isFlying <- if sPos1 = dPos1 && sPos2 = dPos2 then false else true
            true
        else 
            (sPos1, sPos2) = (dPos1, dPos2)

type Airspace () =
    let mutable droneList = []
    member this.Drones = droneList
    member this.DroneDist (a : Drone) (b : Drone) = 
        let (x1, y1) = a.Position 
        let (x2, y2) = b.Position
        Math.Abs (x1 - x2) * Math.Abs (x1 - x2) + Math.Abs (y1-y2) * Math.Abs (y1-y2) // distance can't be negative
        |> float
        |> sqrt
    member this.FlyDrones (allDrones : Drone list)=
        List.iter (fun (x : Drone) -> x.Fly (int ((float x.Speed)))) allDrones
    member this.AddDrone (x : Drone) =
        droneList <- List.append droneList [x]
    member this.WillCollide (a : Drone list) (n : int) : (Drone * Drone) list= //one drone gets lucky and escapes
        let mutable crashed = []
        for h = 0 to n * 60 do
            this.FlyDrones this.Drones
            for i = 0 to a.Length - 1 do
                for j = 0 to a.Length - 1 do
                    if i <> j then
                        if this.DroneDist this.Drones.[i] this.Drones.[j] <= 5. then
                            crashed <- (this.Drones.[i], this.Drones.[j]) :: crashed
        crashed                 
        // for k = 0 to (List.length crashed) - 1 do
        //     let removeI (x : Drone) = x <> fst crashed.[k]
        //     let removeJ (x : Drone) = x <> snd crashed.[k]
        //     for l = 0 to (List.length this.Drones) - 1 do
        //         droneList <- List.filter removeI this.Drones
        //         droneList <- List.filter removeJ this.Drones
