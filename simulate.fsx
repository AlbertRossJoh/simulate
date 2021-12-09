#r "simulate.dll"
open Simulate
open System


let aDrone = Airspace ()
printf "Adding drones : \n"
printfn "\tAmount of drones 0 : %b" (0 = (List.length aDrone.Drones))
printfn "\tAdding drone arg : %A" ((0, 0), (1, 0), 200)
aDrone.AddDrone (Drone ((0, 0), (1, 0), 200))
printfn "\tAdding drone arg : %A" ((0, 0), (1, 0), 200)
aDrone.AddDrone (Drone ((0, 0), (1, 0), 200))
printfn "\tAmount of drones 1 : %b" (1 = (List.length aDrone.Drones))
printfn "\tAdding drone arg : %A" ((300, 540), (2, 9), 300)
aDrone.AddDrone (Drone ((300, 540), (2, 9), 300))
printfn "\tAmount of drones 2 : %b" (2 = (List.length aDrone.Drones))
printfn "\tAdding drone arg : %A" ((170, 12), (26, 21), 200)
aDrone.AddDrone (Drone ((170, 12), (26, 21), 200))
printfn "\tAmount of drones 3 : %b" (3 = (List.length aDrone.Drones))
printf "Getting drone pos : \n"
for i = 0 to (List.length aDrone.Drones)-1 do
    printfn "\tDrone %A pos : %A" i aDrone.Drones.[i].Position
printf "Getting drone dest : \n"
for i = 0 to (List.length aDrone.Drones)-1 do
    printfn "\tDrone %A dest : %A" i aDrone.Drones.[i].Destination
printf "Getting drone speed cm/sec : \n"
for i = 0 to (List.length aDrone.Drones)-1 do
    printfn "\tDrone %A Speed : %A" i aDrone.Drones.[i].Speed
printf "Flight test : \n"
aDrone.FlyDrones aDrone.Drones
for i = 0 to (List.length aDrone.Drones)-1 do
    printfn "\tDrone %A pos : %A" i aDrone.Drones.[i].Position
printf "Drone at dest : \n"
for i = 0 to (List.length aDrone.Drones)-1 do
    printfn "\tDrone %A at dest : %b" i (aDrone.Drones.[i].AtDestination ())
// printf "Drone at dest : \n"
// for i = 0 to (List.length aDrone.Drones)-1 do
printfn "\t %A" (List.length (aDrone.WillCollide aDrone.Drones 10))


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
