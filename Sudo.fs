module Sudo
    open Func
    
    let Add (listaOrig ) (objeto) = // agregar un elemento a uma lista
        let AddToBeginning (listaor) (objeto) = objeto::listaor
        let r = listaOrig |> List.rev 
        AddToBeginning r objeto |> List.rev
  
    let add (arr) ( number:int)= // append a una lista
            let r = arr|>Array.toList
            Add(r) (number) 
            |>List.toArray


    let mini3x3 (sudoku:int array2d,row:int, column:int) = // crear un caja de 3x3 a partir de un sydoku y una pos
        let mutable mini3 = []
        let mutable a = row
        let b_ = column
        while (a< row+3) do
            let mutable mini = [||]
            for b in column..b_+2 do
                mini<-add mini (sudoku[a,b])
            mini3<- Add (mini3) (mini|>Array.toList)
            a <-a+1
        mini3

    let boxing (sudoku:int array2d) = //crear la lista de todas las cajas de 3x3 del sudoku ( son 9)
       let mutable box_3x3 = []
       let a = [|0;0;0;3;3;3;6;6;6|]
       let b = [|0;3;6;0;3;6;0;3;6|]
       for k in 0..8 do
            box_3x3 <- Add (box_3x3) (mini3x3(sudoku,a[k],b[k]))
       box_3x3

    let Row(sudoku:int array2d ,row : int, number :int)= // comprobar si ese numero esta en la fila
        let mutable row_ = [||] 
        for i in 0..8 do
            row_ <- add (row_) (sudoku[row,i])
        row_
        |> Array.contains(number)

    let Column(sudoku :int array2d,column : int, number :int)= // comprobar si ese numero esta en la columna
        let mutable column_ = [||] 
        for i in 0..8 do
            column_ <- add (column_) (sudoku[i,column])
        column_
        |> Array.contains(number)
     
    let Box(sudoku:int array2d,row : int,column:int, number :int) =  // comprobar si ese numero esta en la caja de 3x3 correspondiente
        let aux(box:list<list<int>>) (z:int)=
            let mutable a = []
            for i in 0..2 do
                a <- a|>List.append([box[z][i]])

            a
        let boxs = boxing(sudoku)
        let box = boxs[3*(row/3)+column/3]

        aux box 0 |>List.contains(number) || aux box 1 |>List.contains(number)||aux box 2 |>List.contains(number)
    
    let possible_number (sudoku:int array2d,row:int, column:int)  = // numeros posibles d una pos determinada
        let lista = [1;2;3;4;5;6;7;8;9]
        lista
        |>List.filter(fun x -> not(Row( sudoku,row,x)||Column(sudoku,column,x)||Box(sudoku,row,column,x)))

    
    let Is_Valid ( sudo:Map<int*int,int>, row:int, column: int, x : int)=  // ver si un numero es valido en una determinada pos
        let mutable sudoku =  Array2D.zeroCreate 9 9
        let change =
            for i in 0..8 do
                for j in 0..8 do
                    if(Map.containsKey(i,j) sudo)then
                        sudoku[i,j]<-Map.find(i,j) sudo
                    else sudoku[i,j]<-0
        
        change
        not(Row( sudoku,row,x)||Column(sudoku,column,x)||Box(sudoku,row,column,x))




// para generar sudo ewcursivp sudo
    
    let rec solvePosition position sudoku =
        let x,y = position/9, position%9
        if position = 9*9 then
            Some sudoku
        else if Map.containsKey (x,y) sudoku then
            solvePosition (position+1) sudoku
        else 
            let isValid n = Is_Valid(sudoku,x,y,n)
            let solveCurrentCase n =
                if isValid n then
                    let newSudoku = Map.add (x, y) n sudoku
                    solvePosition (position+1) newSudoku
                else
                       None
            Array.tryPick solveCurrentCase [|1..9|]

            
      

                

    
   
       


        


      


