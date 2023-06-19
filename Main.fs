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



   





