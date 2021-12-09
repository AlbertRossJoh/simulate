// open Simulate
open System

type Drone (startPos : int * int, destPos : int * int, speed : int) =
    let (ssPos1, ssPos2) = startPos
    let mutable (sPos1, sPos2) = (float ssPos1, float ssPos2)
    let (ddPos1, ddPos2) = destPos
    let (dPos1, dPos2) = (float ddPos1, float ddPos2)
    let mutable cms = speed
    let mutable isFlying = true
    member this.Position = (sPos1, sPos2)
    member this.Speed = speed
    member this.Destination = destPos
    member this.Fly (n : int) = 
        let (a, b) = 
            (dPos1 - sPos1, dPos2 - sPos2)
        let lenVec =
            (a**2. + b**2.)
            |> sqrt
        let unitVec (len : float) = 
            ((a/len),(b/len))
        let speedXY (c : int) =
            let (x1, y1) = unitVec lenVec
            (x1 * float c, y1 * float c)
        sPos1 <- fst (speedXY n)
        sPos2 <- snd (speedXY n)


        // if sPos1 < dPos1 && sPos2 < dPos2 then
        //     sPos1 <- sPos1 + cms 
        //     sPos2 <- sPos2 + cms
        // elif sPos1 > dPos1 && sPos2 > dPos2 then 
        //     sPos1 <- sPos1 - cms 
        //     sPos2 <- sPos2 - cms
        // elif sPos1 < dPos1 && sPos2 > dPos2 then 
        //     sPos1 <- sPos1 + cms 
        //     sPos2 <- sPos2 - cms
        // else
        //     sPos1 <- sPos1 - cms 
        //     sPos2 <- sPos2 + cms
    member this.AtDestination =
        isFlying <- not((sPos1, sPos2) = (dPos1, dPos2))
        (sPos1, sPos2) = (dPos1, dPos2)

// let Drone1 = Drone((1, 2), (5, 5), 3)
// let Drone2 = Drone((3, 54), (2, 9), 5)
// let Drone3 = Drone((17, 12), (26, 21), 9)

// printfn "%A" Drone3.Position
// printfn "%A" Drone3.Fly
// printfn "%A" Drone3.Position
// printfn "%b" Drone3.AtDestination
type Airspace () =
    let mutable newArr =
        [|
            Drone((1, 2), (5, 5), 3)
            Drone((3, 54), (2, 9), 5)
            Drone((17, 12), (26, 21), 9)
        |]
    member this.Drones = newArr
    member this.DroneDist (a : Drone) (b : Drone) = 
        let (x1, y1) = a.Position 
        let (x2, y2) = b.Position
        Math.Abs (x1 - x2) * Math.Abs (x1 - x2) + Math.Abs (y1-y2) * Math.Abs (y1-y2)
        |> float
        |> sqrt
        |> int
    member this.FlyDrones (allDrones : Drone array)=
        Array.map (fun (x : Drone) -> x.Fly x.Speed ) allDrones
    member this.AddDrone (x : int*int, y : int * int, n : int) =
        newArr <- Array.append newArr [|Drone (x, y, n)|]



let aDrone = Airspace ()
printfn "Drone 1 : %A" aDrone.Drones.[0].Position
printfn "Drone 2 : %A" aDrone.Drones.[1].Position
printfn "Drone 3 : %A" aDrone.Drones.[2].Position
aDrone.FlyDrones aDrone.Drones
printfn "Drone 1 : %A" aDrone.Drones.[0].Position
printfn "Drone 2 : %A" aDrone.Drones.[1].Position
printfn "Drone 3 : %A" aDrone.Drones.[2].Position
aDrone.AddDrone ((324, 435), (34, -213), 34)
printfn "Drone 4 : %A" aDrone.Drones.[3].Position
aDrone.FlyDrones aDrone.Drones
printfn "Drone 1 : %A" aDrone.Drones.[0].Position
printfn "Drone 2 : %A" aDrone.Drones.[1].Position
printfn "Drone 3 : %A" aDrone.Drones.[2].Position
printfn "Drone 4 : %A" aDrone.Drones.[3].Position
// printfn "%A" (Array.length aDrone.Drones)
// aDrone.AddDrone ((23, 4), (2354, 45), 300)
// printfn "%A" (Array.length aDrone.Drones)
// printfn "%A" (aDrone.DroneDist aDrone.Drones.[0] aDrone.Drones.[1])
// printfn "%A" (aDrone.DroneDist aDrone.Drones.[0] aDrone.Drones.[3])
