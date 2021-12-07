module Simulate
open System


type Drone (startPos : int * int, destPos : int * int, speed : int) = // the coords are actually in cm, easier when using speed in cm pr. sec
    let mutable (sPos1, sPos2) = startPos //unpacking1, but mutable 
    let (dPos1, dPos2) = destPos // unpacking2, but not
    let mutable cms = speed // in cm pr second
    member this.Position = (sPos1, sPos2)
    member this.Speed = speed
    member this.Destination = destPos
    member this.Fly = //shitty implimentation, prolly looking into better algo
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
        (sPos1, sPos2) = destPos // self explainatory

type Airspace () =
    let mutable newArr = //the actual drone array
        [|
            Drone((1, 2), (5, 5), 3)
            Drone((3, 54), (2, 9), 5)
            Drone((17, 12), (26, 21), 9)
        |]
    member this.Drones = 
        newArr
    member this.DroneDist (a : Drone) (b : Drone) = //pythagoras ftw, converts to float after so we don't get wierd results
        let (x1, y1) = a.Position 
        let (x2, y2) = b.Position
        Math.Abs (x1 - x2) * Math.Abs (x1 - x2) + Math.Abs (y1-y2) * Math.Abs (y1-y2)
        |> float
        |> sqrt
        |> int
    member this.FlyDrones =  // tells all drones to go towards their dest
        let all = Airspace ()
        Array.map (fun (x : Drone) -> x.Fly ) all.Drones
    member this.AddDrone = // adds another drone, and gives it random positive values lazily
        let all = Airspace ()
        let rnd = System.Random ()
        newArr <- Array.append newArr [|Drone ((rnd.Next 2000, rnd.Next 2000), (rnd.Next 2000, rnd.Next 2000), rnd.Next 2000)|]
