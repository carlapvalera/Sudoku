open Sudo
open System
    

    let Create_Sudoku =    // crear el sudoku
        let list = [1;2;3;4;5;6;7;8;9]
        let cero = 0
        let mutable Sudoku = []
        let mutable sudoku = Array2D.zeroCreate 9 9
        let fila ( row:int array,j : int)=
            for i in 0..8 do
                sudoku[j,i]<-row[i]
        for j in 0..8 do
            let mutable row= [||]
            for i in 0..8 do
                
                let a = possible_number(sudoku,j,i)|>List.toArray
                let mutable b =[0;0;0;0;0]
                let list = b |>List.append(a|>Array.toList)
                let c = new Random()
                sudoku[j,i]<-list[c.Next(list.Length-1)]
        sudoku  

    let convertirArrayAMap (array: 'a [,]) =
        let mutable mapa = Map.empty
        for fila in 0 .. Array2D.length1 array - 1 do
            for columna in 0 .. Array2D.length2 array - 1 do
                if(array.[fila, columna]<>0) then
                    let clave =  (fila,columna)
                    let valor = array.[fila, columna]
                    mapa <- mapa.Add(clave, valor)
        mapa

    

//let a = blabla()
let main = 
    let b = Create_Sudoku

    let arrayOfArrays = [| [| 5;3;0;0;7;0;0;0;0|]; [|6;0;0;1;9;5;0;0;0|];[|0;9;8;0;0;0;0;6;0|];[|8;0;0;0;6;0;0;0;3|];[|4;0;0;8;0;3;0;0;1|];[|7;0;0;0;2;0;0;0;6|];[|0;6;0;0;0;0;2;8;0|];[|0;0;0;4;1;9;0;0;5|];[|0;0;0;0;8;0;0;7;9|]|]
    let sudo = Array2D.init 9 9 (fun i j -> arrayOfArrays[i][j])
    let mutable Sudo= Map.empty
    let convertirArrayAMap (array: 'a [,]) =
        let mutable mapa = Map.empty
        for fila in 0 .. Array2D.length1 array - 1 do
            for columna in 0 .. Array2D.length2 array - 1 do
                if(array.[fila, columna]<>0) then
                    let clave =  (fila,columna)
                    let valor = array.[fila, columna]
                    mapa <- mapa.Add(clave, valor)
        mapa
    Sudo<-convertirArrayAMap(sudo)

    let a = solvePosition 0 Sudo
    8

    
    //let arrayOfArrays = [| [| 5;3;0;0;7;0;0;0;0|]; [|6;0;0;1;9;5;0;0;0|];[|0;9;8;0;0;0;0;6;0|];[|8;0;0;0;6;0;0;0;3|];[|4;0;0;8;0;3;0;0;1|];[|7;0;0;0;2;0;0;0;6|];[|0;6;0;0;0;0;2;8;0|];[|0;0;0;4;1;9;0;0;5|];[|0;0;0;0;8;0;0;7;9|]|]
    //let Sudo = Array2D.init 9 9 (fun i j -> arrayOfArrays[i][j])
    //let mutable solution =  Array2D.zeroCreate 9 9
    //let valid_pos = blabla(Sudo)
    //let mutable solution = Array2D.zeroCreate 9 9
    //solution <-Solve(Sudo,0,0,valid_pos)
    //for i in 0 .. 8 do
      //  for j in 0 .. 7 do
        //  Console.Write("{0}  ",solution[i,j])
        //Console.Write("{0} \n")
   



    //let b =arrayOfArrays_2
    //let a = blabla()
    //Console.WriteLine(a)
    //for i in 0..2 do 
        //for j in 0..2 do
        //    for k in 0..8 do
         //       Console.Write(a[i][j,k])
     

//Console.WriteLine(possible_number(0,0)
//Console.WriteLine(5%3) 





