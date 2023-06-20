open Sudo
open Create
open System
    

    let Create_Sudoku_1 =    // crear el sudoku
        let list = [1;2;3;4;5;6;7;8;9]
        let cero = 0
        let mutable max_val = []
        let mutable sudoku = Array2D.zeroCreate 9 9
        let fila ( row:int array,j : int)=
            for i in 0..8 do
                sudoku[j,i]<-row[i]
        for j in 0..8 do
            let mutable row= [||]
            for i in 0..8 do
                let mutable a = [||]
                if(max_val.Length<17) then
                     a <- possible_number(sudoku,j,i)|>List.toArray
                let mutable b =[0;0;0;0;0]
                let list = b |>List.append(a|>Array.toList)
                let c = new Random()
                let k =list[c.Next(list.Length-1)]
                if( k<>0  )then max_val<-max_val|>List.append([k])
                sudoku[j,i]<-k
        sudoku  
    
    let Create_Sudoku_2 =    // crear el sudoku
        let list = [1;2;3;4;5;6;7;8;9]
        let cero = 0
        let mutable max_val = []
        let mutable sudoku = Array2D.zeroCreate 9 9
        let c = new Random()
        while(max_val.Length<17)do
            let row = c.Next(9)
            let column = c.Next(9)
            if(sudoku[row,column]=0)then
                let mutable a = [||]
                if(max_val.Length<17) then
                     a <- possible_number(sudoku,row ,column)|>List.toArray
                let mutable b =[0;0;0;0;0]
                let list = b |>List.append(a|>Array.toList)
                let k =list[c.Next(list.Length-1)]
                if( k<>0  )then max_val<-max_val|>List.append([k])
                sudoku[row ,column]<-k
        sudoku  

    let Create_Sudoku_3=
    let convertirArrayAMap (array: 'a [,]) =
        let mutable mapa = Map.empty
        for fila in 0 .. Array2D.length1 array - 1 do
            for columna in 0 .. Array2D.length2 array - 1 do
                if(array.[fila, columna]<>0) then
                    let clave =  (fila,columna)
                    let valor = array.[fila, columna]
                    mapa <- mapa.Add(clave, valor)
        mapa


    let rec main = 
        let mutable sudo = Create_Sudoku_2
        let sudoku =convertirArrayAMap sudo
        let sol =  solvePosition 0 sudoku
        let solution = sol.Value
        while(not(sol <> None))do
            main
   





