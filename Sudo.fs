module Sudo
    open System

    //type Box ={row : int; col : int; value: int}

   // let arrayOfArrays = [| [| 5;3;0;0;7;0;0;0;0|]; [|6;0;0;1;9;5;0;0;0|];[|0;9;8;0;0;0;0;6;0|];[|8;0;0;0;6;0;0;0;3|];[|4;0;0;8;0;3;0;0;1|];[|7;0;0;0;2;0;0;0;6|];[|0;6;0;0;0;0;2;8;0|];[|0;0;0;4;1;9;0;0;5|];[|0;0;0;0;8;0;0;7;9|]|]
   // let Sudo = Array2D.init 9 9 (fun i j -> arrayOfArrays[i][j])
    //let list = [1;2;3;4;5;6;7;8;9]
    
   
    let Add (listaOrig ) (objeto) = // agregar un elemento a uma lista
        let AddToBeginning (listaor) (objeto) = objeto::listaor
        let r = listaOrig |> List.rev 
        AddToBeginning r objeto |> List.rev
  
    let add (arr) ( number:int)= // append a una lista
            let r = arr|>Array.toList
            Add(r) (number) 
            |>List.toArray


    let mini3x3 (sudoku,row:int, column:int) = // crear un caja de 3x3 a partir de un sydoku y una pos
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

    let boxing (sudoku) = //crear la lista de todas las cajas de 3x3 del sudoku ( son 9)
       let mutable box_3x3 = []
       let a = [|0;0;0;3;3;3;6;6;6|]
       let b = [|0;3;6;0;3;6;0;3;6|]
       for k in 0..8 do
            box_3x3 <- Add (box_3x3) (mini3x3(sudoku,a[k],b[k]))
       box_3x3

    let Row(sudoku ,row : int, number :int)= // comprobar si ese numero esta en la fila
        let mutable row_ = [||] 
        for i in 0..8 do
            row_ <- add (row_) (sudoku[row,i])
        row_
        |> Array.contains(number)

    let Column(sudoku ,column : int, number :int)= // comprobar si ese numero esta en la columna
        let mutable column_ = [||] 
        for i in 0..8 do
            column_ <- add (column_) (sudoku[i,column])
        column_
        |> Array.contains(number)
     
    let Box(sudoku,row : int,column:int, number :int) =  // comprobar si ese numero esta en la caja de 3x3 correspondiente
        let aux(box:list<list<int>>) (z:int)=
            let mutable a = []
            for i in 0..2 do
                a <- a|>List.append([box[z][i]])

            a
        let boxs = boxing(sudoku)
        let box = boxs[3*(row/3)+column/3]

        aux box 0 |>List.contains(number) || aux box 1 |>List.contains(number)||aux box 2 |>List.contains(number)
    
    let possible_number (sudoku,row:int, column:int)  = // numeros posibles d una pos determinada
        let lista = [1;2;3;4;5;6;7;8;9]
        lista
        |>List.filter(fun x -> not(Row( sudoku,row,x)||Column(sudoku,column,x)||Box(sudoku,row,column,x)))

    let blabla(sudoku) =  // la listan de numeros posibles d una pos determinada
        let mutable lista =[]
        let rec possible_number_positions(row:int, column:int)=
            if(sudoku[row,column]=0) then lista <- Add lista (possible_number (sudoku,row,column))
            elif (sudoku[row,column]<>0) then lista <- Add lista ([])
            if(row <=8 && column<8)then possible_number_positions(row,column+1)
            elif(column = 8 && row<8) then possible_number_positions(row+1,0)

        possible_number_positions(0,0)
        lista



        // para pacooooooooooooooooo
    let Create_Sudoku =    // crear el sudoku
        let list = [1;2;3;4;5;6;7;8;9]
        let cero = 0
        let mutable Sudoku = []
        let mutable row= [||]
        for j in 0..8 do
            for i in 0..8 do
                let random = new Random()
                let a = random.Next(list.Length-1)
                let b = random.Next(4)
                let index = [0;0;1;1;1]
                let pos =[|0;a|]
                row<- add row pos[index[b]]
            Sudoku<-Add Sudoku row
        let Sudo =Array2D.init 9 9 (fun i j -> Sudoku[i][j])
        Sudo


    let Is_Valid ( sudoku, row:int, column: int, x : int)=  // ver si un numero es valido en una determinada pos
        not(Row( sudoku,row,x)||Column(sudoku,column,x)||Box(sudoku,row,column,x))




// para generar sudo ewcursivp sudo
    
    let rec Solve ( sudoku, row:int, column:int, valid_pos)=
        
        let Valid (sudoku,valid_pos:list<list<int>>,row:int, column:int)=
            let mutable list =[]
            list<-valid_pos[9*(row/9)+column/9]
            let mutable number = [||]
            for i in 0..list.Length-1 do
                if(Is_Valid(sudoku, row, column,list[i])) then number <- add number list[i]
            number

       
        let valid_pos = blabla(sudoku)
        let mutable solution = (false,sudoku)
        let number = Valid(sudoku,valid_pos, row, column)
        if(number.Length = 0) then solution<-(false,sudoku)
        else 
            
            if(row = 8 && column = 8) then solution<-(true, sudoku)
            elif(row<8 && column = 8) then 
                for i in 0..number.Length-1 do
                    let mutable new_ = sudoku
                    new_[row,column]<-number[i]
                    Solve(new_, row+1,0)


            elif( column<8) then
                for i in 0..number.Length-1 do
                    let mutable new_ = sudoku
                    new_[row,colummn]<-number[i]
                    Solve(new_, row , column+1)

        solution
        
            
      

                

    
   
       


        


      


