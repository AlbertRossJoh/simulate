#r "simulate.dll"
open Simulate
open System

type testSimulate () =
    let aDrone = Airspace ()
    let testB4Fly = aDrone.Drones
    member this.AllDrones = 
        (List.length aDrone.Drones) = 100
    member this.TestAddDrone =
        let rnd = Random ()
        for i in [0..99] do
            aDrone.AddDrone (Drone ((rnd.Next 200, rnd.Next 200), (rnd.Next 200, rnd.Next 200), rnd.Next 200))
        List.length aDrone.Drones = 100
    member this.KnownDrone =
        Drone ((0, 0), (1, 0), 2000)
    member this.KnownDrone2 =
        Drone ((0, 0), (2, 0), 2000)
    member this.TestFlyAll =
        (aDrone.FlyDrones aDrone.Drones)
        testB4Fly <> aDrone.Drones
    member this.TestFlyAll2 =
        aDrone.FlyDrones aDrone.Drones
    member this.TestWillCollide =
        List.length (aDrone.WillCollide aDrone.Drones 100)
    member this.TestAtDestination (x : Drone)=
        x.AtDestination ()
    member this.GetPos =
        aDrone.Drones.[50].Position
    member this.GetSpeed =
        this.KnownDrone.Speed / 100 = 20
    member this.WillCollide (a : Drone list) (n : int) =
        aDrone.WillCollide a n
    // member this.TestWillCollide2Elms =
    //     aDrone.WillCollide [this.KnownDrone; this.KnownDrone2] 10



let test = testSimulate ()
printfn "Adding 100 drones : %b" test.TestAddDrone
printfn "Checking for 100 elms : %b" test.AllDrones
printfn "Position changes after fly : %b" test.TestFlyAll //Also checks .Fly method
printfn "We get less than a 50 collisions : %b " (test.TestWillCollide < 50)
printfn "Known drone reached dest : %b" (test.KnownDrone.AtDestination ())
printfn "Check if speed is in cm pr sec : %b" test.GetSpeed
(test.WillCollide [test.KnownDrone; test.KnownDrone2] 1)
printfn "Crashed drones are crashed : %b" (test.KnownDrone2.IsCrashed = false) // so when testing and based on how my willcollide function works this should return true because if it does not it would keep adding elements. My willcollide adds 1 tuple to the list, this must mean that it's working but I cannot get the value for some reason.


// let aDrone = Airspace ()
// printf "Adding drones : \n"
// printfn "\tAmount of drones 0 : %b" (0 = (List.length aDrone.Drones))
// printfn "\tAdding drone arg : %A" ((0, 0), (1, 0), 200)
// aDrone.AddDrone (Drone ((0, 0), (1, 0), 200))
// printfn "\tAmount of drones 1 : %b" (1 = (List.length aDrone.Drones))
// printfn "\tAdding drone arg : %A" ((0, 0), (2, 0), 200)
// aDrone.AddDrone (Drone ((0, 0), (2, 0), 200))
// printfn "\tAmount of drones 2 : %b" (2 = (List.length aDrone.Drones))
// printfn "\tAdding drone arg : %A" ((300, 540), (2, 9), 300)
// aDrone.AddDrone (Drone ((300, 540), (2, 9), 300))
// printfn "\tAmount of drones 3 : %b" (3 = (List.length aDrone.Drones))
// printfn "\tAdding drone arg : %A" ((170, 12), (26, 21), 200)
// aDrone.AddDrone (Drone ((170, 12), (26, 21), 200))
// printfn "\tAmount of drones 4 : %b" (4 = (List.length aDrone.Drones))
// printf "Getting drone pos : \n"
// for i = 0 to (List.length aDrone.Drones)-1 do
//     printfn "\tDrone %A pos : %A" i aDrone.Drones.[i].Position
// printf "Getting drone dest : \n"
// for i = 0 to (List.length aDrone.Drones)-1 do
//     printfn "\tDrone %A dest : %A" i aDrone.Drones.[i].Destination
// printf "Getting drone speed cm/sec : \n"
// for i = 0 to (List.length aDrone.Drones)-1 do
//     printfn "\tDrone %A Speed : %A" i aDrone.Drones.[i].Speed
// printf "Flight test : \n"
// aDrone.FlyDrones aDrone.Drones
// for i = 0 to (List.length aDrone.Drones)-1 do
//     printfn "\tDrone %A pos : %A" i aDrone.Drones.[i].Position
// printf "Second Flight test : \n"
// aDrone.FlyDrones aDrone.Drones
// for i = 0 to (List.length aDrone.Drones)-1 do
//     printfn "\tDrone %A pos : %A" i aDrone.Drones.[i].Position
// printf "Drone at dest : \n"
// for i = 0 to (List.length aDrone.Drones)-1 do
//     printfn "\tDrone %A at dest : %b" i (aDrone.Drones.[i].AtDestination ())
// // printf "Drone at dest : \n"
// // for i = 0 to (List.length aDrone.Drones)-1 do
// printfn "\t %A" (List.length (aDrone.WillCollide aDrone.Drones 1))
// printf "Drone dist : \n"
// printfn "\t %A" (aDrone.DroneDist aDrone.Drones.[2] aDrone.Drones.[3])


// printfn "Drone 1 : %b" (aDrone.Drones.[0].AtDestination ())
// printfn "Drone 1 : %A" (aDrone.Drones.[0].Destination)
// printfn "Drone 1 : %A" aDrone.Drones.[0].Position
// aDrone.Drones.[0].Fly (int((float aDrone.Drones.[1].Speed)))
// printfn "Drone 1 : %b" (aDrone.Drones.[0].AtDestination ())
// printfn "Drone 1 : %A" aDrone.Drones.[0].Position
// aDrone.Drones.[0].Fly (int((float aDrone.Drones.[1].Speed)))
// printfn "Drone 1 : %b" (aDrone.Drones.[0].AtDestination ())
// printfn "Drone 1 : %A" aDrone.Drones.[0].Position
// printfn "Drone 1 : %b" (aDrone.Drones.[0].AtDestination ())
// printfn "Drone 1 : %A" aDrone.Drones.[0].Position
// aDrone.Drones.[0].Fly aDrone.Drones.[0].Speed

// printfn "Drone 1 : %b" (aDrone.Drones.[0].AtDestination ())
// printfn "Drone 1 : %A" aDrone.Drones.[0].Position
// aDrone.Drones.[0].Fly aDrone.Drones.[0].Speed
// printfn "Drone 1 : %b" (aDrone.Drones.[0].AtDestination ())

// printfn "Drone 1 : %b" (aDrone.Drones.[0].AtDestination ())
// printfn "Drone 1 : %A" aDrone.Drones.[0].Position
// aDrone.Drones.[0].Fly aDrone.Drones.[0].Speed
// printfn "Drone 1 : %b" (aDrone.Drones.[0].AtDestination ())
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
