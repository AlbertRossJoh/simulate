module Simulate
open System

type Drone (startPos : int * int, destPos : int * int, speed : int) = //speed is in cm pr 
    let mutable (sPos1, sPos2) = startPos //startpos, but mutable
    let (dPos1, dPos2) = destPos //destpos, but not
    // let mutable isFlying = true
    let mutable isCrashed = false
    member this.IsCrashed 
        with get () = isCrashed
        and set (a) = isCrashed <- a
    member this.IsFlying = isCrashed
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
            sPos1 <- sPos1 + (((fst (speedXY n))*0.01) |> ceil |> int)
            sPos2 <- sPos2 + (((snd (speedXY n))*0.01) |> ceil |> int)
        else
            sPos1 <- dPos1
            sPos2 <- dPos2
    member this.AtDestination () =
        let dist =
            Math.Abs (sPos1 - dPos1) * Math.Abs (sPos1 - dPos1) + Math.Abs (sPos2 - dPos2) * Math.Abs (sPos2 - dPos2)
            |> float
            |> sqrt
            |> int
        if dist * 100 <= int (float this.Speed) (*&& startPos <> (sPos1, sPos2)*) then //distance is in cm bc. speed is in cm/s
            // isFlying <- false 
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
        List.iter (fun (x : Drone) -> x.Fly (int (float x.Speed))) allDrones
    member this.AddDrone (x : Drone) =
        droneList <- List.append droneList [x]
    member this.WillCollide (a : Drone list) (n : int) : (Drone * Drone) list = //one drone gets lucky and escapes
        let mutable crashed = []
        for _ in [0..(n*60)] do
            this.FlyDrones this.Drones
            for droneI : Drone in a do
                for droneJ : Drone in a do
                    if this.DroneDist droneI droneJ < 5. then
                        if not droneI.IsCrashed && not droneJ.IsCrashed then
                            if droneI <> droneJ && crashed |> List.contains (droneI, droneJ) |> not && crashed |> List.contains (droneJ, droneI) |> not then
                                crashed <- (droneI, droneJ) :: crashed
                                droneI.IsCrashed <- true
                                droneJ.IsCrashed <- true
                        else
                            crashed <- crashed
                    else
                        crashed <- crashed
        crashed                 
