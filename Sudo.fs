module Sudo
    //type Box ={row : int; col : int; value: int}

    let arrayOfArrays = [| [| 5;3;0;0;7;0;0;0;0|]; [|6;0;0;1;9;5;0;0;0|];[|0;9;8;0;0;0;0;6;0|];[|8;0;0;0;6;0;0;0;3|];[|4;0;0;8;0;3;0;0;1|];[|7;0;0;0;2;0;0;0;6|];[|0;6;0;0;0;0;2;8;0|];[|0;0;0;4;1;9;0;0;5|];[|0;0;0;0;8;0;0;7;9|]|]
    let Sudo = Array2D.init 9 9 (fun i j -> arrayOfArrays[i][j])
    let list = [1;2;3;4;5;6;7;8;9]
    
    //let Possible =[]
   
    let Add (listaOrig ) (objeto) = 
        let AddToBeginning (listaor) (objeto) = objeto::listaor
        let r = listaOrig |> List.rev 
        AddToBeginning r objeto |> List.rev
        //a |> List.rev
    let add (arr) ( number:int)=
            let r = arr|>Array.toList
            Add(r) (number) 
            |>List.toArray

    let arrayOfArrays_2 =

        let mutable array = []
        let Column ( col:int) =
            let mutable arr = [||]
            for i in 0..8 do 
                arr<- add arr (arrayOfArrays[i][col]) 
            arr
        for j in 0..8 do
            array<-(Add (array)(Column(j)|>Array.toList))
        
        array  

    let mini3x3 (row:int, column:int) =
        let mutable mini3 = []
        let mutable a = row
        let b_ = column
        while (a< row+3) do
            let mutable mini = [||]
            for b in column..b_+2 do
                mini<-add mini (Sudo[a,b])
            mini3<- Add (mini3) (mini|>Array.toList)
            a <-a+1
        mini3

    let boxing = 
       let mutable box_3x3 = []
       let a = [|0;0;0;3;3;3;6;6;6|]
       let b = [|0;3;6;0;3;6;0;3;6|]
       for k in 0..8 do
            box_3x3 <- Add (box_3x3) (mini3x3(a[k],b[k]))
       box_3x3

    let Row(row : int, number :int)=
        arrayOfArrays[row]
        |> Array.contains(number)

    let Column(column : int, number :int)=
        arrayOfArrays_2[column]
        |> List.contains(number)
     
    let Box(row : int,column:int, number :int) =
        let aux(box:list<list<int>>) (z:int)=
            let mutable a = []
            for i in 0..2 do
                a <- a|>List.append([box[z][i]])

            a
        let boxs = boxing
        let box = boxs[3*(row/3)+column/3]

        aux box 0 |>List.contains(number) || aux box 1 |>List.contains(number)||aux box 2 |>List.contains(number)
    
    let possible_number (row:int, column:int)  =
        let lista = [1;2;3;4;5;6;7;8;9]
        lista
        |>List.filter(fun x -> not(Row(row,x)||Column(column,x)||Box(row,column,x)))


    

        
    let blabla() =
        let mutable lista =[]
        let rec possible_number_positions(row:int, column:int)=
            if(Sudo[row,column]=0) then lista <- Add lista (possible_number (row,column))
            elif (Sudo[row,column]<>0) then lista <- Add lista ([])
            if(row <=8 && column<8)then possible_number_positions(row,column+1)
            elif(column = 8 && row<8) then possible_number_positions(row+1,0)

        possible_number_positions(0,0)
        lista


            
        
// para generar sudo ewcursivp sudo
    
    let Solve sudoku=
        for i in 0..8 do
            for j in 0..8 do
                if(sudoku[i,j]<>0)
                  sudoku()





    let posible (row:int, column:int)=
        let pos = blabla()
        let index(row:int,column:int) = 9*(row/9)+column/9
        let Su = Sudo
        let pos index = 
            seq{
                for i in 0..pos[index].Length-1 ->pos[index][i]
            }
        for i in 0..8 do
            for j in 0..9 do
               Solve(Su)        

                

    
   
       


        


      


