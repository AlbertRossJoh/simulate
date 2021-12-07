module Simulate
open System


type Drone (startPos : int * int, destPos : int * int, speed : int) =
    let mutable (sPos1, sPos2) = startPos
    let (dPos1, dPos2) = destPos
    let mutable cms = speed
    member this.Position = (sPos1, sPos2)
    member this.Speed = speed
    member this.Destination = destPos
    member this.Fly = 
        if sPos1 < dPos1 && sPos2 < dPos2 then
            sPos1 <- sPos1 - cms 
            sPos2 <- sPos2 - cms
        elif sPos1 > dPos1 && sPos2 > dPos2 then 
            sPos1 <- sPos1 + cms 
            sPos2 <- sPos2 + cms
        elif sPos1 < dPos1 && sPos2 > dPos2 then 
            sPos1 <- sPos1 - cms 
            sPos2 <- sPos2 + cms
        else
            sPos1 <- sPos1 + cms 
            sPos2 <- sPos2 - cms
    member this.AtDestination =
        (sPos1, sPos2) = destPos

type Airspace () =
    let mutable newArr =
        [|
            Drone((1, 2), (5, 5), 3)
            Drone((3, 54), (2, 9), 5)
            Drone((17, 12), (26, 21), 9)
        |]
    member this.Drones = 
        newArr
    member this.DroneDist (a : Drone) (b : Drone) = 
        let (x1, y1) = a.Position 
        let (x2, y2) = b.Position
        Math.Abs (x1 - x2) * Math.Abs (x1 - x2) + Math.Abs (y1-y2) * Math.Abs (y1-y2)
        |> float
        |> sqrt
        |> int
    member this.FlyDrones = 
        let all = Airspace ()
        Array.map (fun (x : Drone) -> x.Fly ) all.Drones
    member this.AddDrone =
        let all = Airspace ()
        let rnd = System.Random ()
        newArr <- Array.append newArr [|Drone ((rnd.Next 2000, rnd.Next 2000), (rnd.Next 2000, rnd.Next 2000), rnd.Next 2000)|]
