// open Simulate
open System

type Drone (startPos : int * int, destPos : int * int, speed : int) =
    // let (ssPos1, ssPos2) = startPos
    let mutable (sPos1, sPos2) = startPos
    // let (ddPos1, ddPos2) = destPos
    let (dPos1, dPos2) = destPos
    //let mutable cms = speed
    let mutable isFlying = true
    member this.IsFlying = isFlying
    member this.Position = (sPos1, sPos2)
    member this.Speed = speed * 100
    member this.Destination = destPos
    member this.Fly (n : int) = 
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
    member this.AtDestination =
        isFlying <- if sPos1 = dPos1 && sPos2 = dPos2 then false else true
        (sPos1, sPos2) = (dPos1, dPos2)

// let Drone1 = Drone((1, 2), (5, 5), 3)
// let Drone2 = Drone((3, 54), (2, 9), 5)
// let Drone3 = Drone((17, 12), (26, 21), 9)

// printfn "%A" Drone3.Position
// printfn "%A" Drone3.Fly
// printfn "%A" Drone3.Position
// printfn "%b" Drone3.AtDestination
type Airspace () =
    let mutable droneArr =
        [
            Drone((1, 2), (5, 5), 3)
            Drone((300, 540), (2, 9), 5) // remove 
            Drone((170, 12), (26, 21), 9)
        ]
    member this.Drones = droneArr
    member this.DroneDist (a : Drone) (b : Drone) = 
        let (x1, y1) = a.Position 
        let (x2, y2) = b.Position
        Math.Abs (x1 - x2) * Math.Abs (x1 - x2) + Math.Abs (y1-y2) * Math.Abs (y1-y2)
        |> float
        |> sqrt
    member this.FlyDrones (allDrones : Drone list)=
        List.iter (fun (x : Drone) -> x.Fly (int ((float x.Speed) * 0.01)) ) allDrones
    member this.AddDrone (x : Drone) =
        droneArr <- List.append droneArr [x]
    member this.WillCollide (a : Drone array) (n : int): (Drone * Drone) list=
        let mutable crashed = []
        for h = 0 to n * 60 do
            this.FlyDrones this.Drones
            for i = 0 to a.Length - 1 do
                for j = 0 to a.Length - 1 do
                    if i <> j then
                        if this.DroneDist this.Drones.[i] this.Drones.[j] <= 5. then
                            crashed <- (this.Drones.[i], this.Drones.[j]) :: crashed
        crashed 
                // else
                //     this.DroneDist this.Drones.[i] this.Drones.[j+1]
                //     crashed <- (this.Drones.[i], this.Drones.[j]) :: crashed
        




let aDrone = Airspace ()
printfn "Drone 1 : %A" aDrone.WillCollide

printfn "Drone 1 : %b" aDrone.Drones.[0].AtDestination
printfn "Drone 1 : %A" aDrone.Drones.[0].Position
aDrone.Drones.[0].Fly aDrone.Drones.[0].Speed

printfn "Drone 1 : %b" aDrone.Drones.[0].AtDestination
printfn "Drone 1 : %A" aDrone.Drones.[0].Position
aDrone.Drones.[0].Fly aDrone.Drones.[0].Speed

printfn "Drone 1 : %b" aDrone.Drones.[0].AtDestination
printfn "Drone 1 : %A" aDrone.Drones.[0].Position
aDrone.Drones.[0].Fly aDrone.Drones.[0].Speed
printfn "Drone 1 : %b" aDrone.Drones.[0].AtDestination

    
// printfn "Drone 1 : %A" aDrone.Drones.[0].Position
// printfn "Drone 2 : %A" aDrone.Drones.[1].Position
// printfn "Drone 3 : %A" aDrone.Drones.[2].Position
// aDrone.FlyDrones aDrone.Drones
// printfn "Drone 1 : %A" aDrone.Drones.[0].Position
// printfn "Drone 2 : %A" aDrone.Drones.[1].Position
// printfn "Drone 3 : %A" aDrone.Drones.[2].Position
// aDrone.AddDrone ((324, 435), (34, -213), 34)
// printfn "Drone 4 : %A" aDrone.Drones.[3].Position
// aDrone.FlyDrones aDrone.Drones
// printfn "Drone 1 : %A" aDrone.Drones.[0].Position
// printfn "Drone 1 : %A" aDrone.Drones.[0].IsFlying
// printfn "Drone 2 : %A" aDrone.Drones.[1].Position
// printfn "Drone 3 : %A" aDrone.Drones.[2].Position
// printfn "Drone 4 : %A" aDrone.Drones.[3].Position
// aDrone.FlyDrones aDrone.Drones
// printfn "Drone 1 : %A" aDrone.Drones.[0].Position
// printfn "Drone 2 : %A" aDrone.Drones.[1].Position
// printfn "Drone 3 : %A" aDrone.Drones.[2].Position
// printfn "Drone 4 : %A" aDrone.Drones.[3].Position
// printfn "%A" (Array.length aDrone.Drones)
// aDrone.AddDrone ((23, 4), (2354, 45), 300)
// printfn "%A" (Array.length aDrone.Drones)
// printfn "%A" (aDrone.DroneDist aDrone.Drones.[0] aDrone.Drones.[1])
// printfn "%A" (aDrone.DroneDist aDrone.Drones.[0] aDrone.Drones.[3])
