open Sudo
open System

let main = Console.WriteLine(Row(0,5))
Console.WriteLine(5%3) 

for i in 0 .. 8 do
    for j in 0 .. 7 do
        Console.Write("{0}  ",Sudo[i,j])
    Console.Write("{0} \n",Sudo[i,8])




