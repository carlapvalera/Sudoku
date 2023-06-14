module Sudo
    //type Box ={row : int; col : int; value: int}

    let arrayOfArrays = [| [| 5;3;0;0;7;0;0;0;0|]; [|6;0;0;1;9;5;0;0;0|];[|0;9;8;0;0;0;0;6;0|];[|8;0;0;0;6;0;0;0;3|];[|4;0;0;8;0;3;0;0;1|];[|7;0;0;0;2;0;0;0;6|];[|0;6;0;0;0;0;2;8;0|];[|0;0;0;4;1;9;0;0;5|];[|0;0;0;0;8;0;0;7;9|]|]
    let Sudo = Array2D.init 9 9 (fun i j -> arrayOfArrays[i][j])
    let list = [1;2;3;4;5;6;7;8;9]
    let Possible =[]
    
  
    let Row(row : int, number :int)=
        arrayOfArrays[row]
        |> Array.contains(number)

    let Column(column : int, number :int)=
        arrayOfArrays[column]
        |> Array.contains(number)

    let Box(row : int, number :int) =
        if(row%3 =1) then Row(row-1,number) || (Row(row,number) || Row(row+1,number))  
        elif(row%3 =2) then Row(row-2,number) || (Row(row-1,number) || Row(row,number))  
        else Row(row,number) || (Row(row+1,number) || Row(row+2,number)) 

    let possible_number (row:int, column:int)  =
        list 
        |>List.filter(fun x -> Row(row,x)&&(Column(column,x)&&Box(row,x)))

    let append(list:List<int>) = 
        Possible
        |>List.append(list)

    let rec possible_number_positions(row:int, column:int) =
        append(possible_number(row,column))
        if(Sudo[row,column]<>0) then if(row <=8 && column<8)then possible_number_positions(row,column+1)
        elif(Sudo[row,column]<>0) then  if(column = 8 && row<8) then possible_number_positions(row+1,0)
        else append(possible_number([]))
        

        

                

    
   
       


        


      


