open Sudo
open System

//let a = blabla()
let main = 
    //let b =arrayOfArrays_2
    let a = Box(3,0,7)
    Console.WriteLine(a)
    //for i in 0..2 do 
        //for j in 0..2 do
        //    for k in 0..8 do
         //       Console.Write(a[i][j,k])
     

//Console.WriteLine(possible_number(0,0)
//Console.WriteLine(5%3) 

for i in 0 .. 8 do
    for j in 0 .. 7 do
        Console.Write("{0}  ",Sudo[i,j])
    Console.Write("{0} \n",Sudo[i,8])




