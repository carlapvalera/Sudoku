module Sudo
    //type Box ={row : int; col : int; value: int}

    let arrayOfArrays = [| [| 5;3;0;0;7;0;0;0;0|]; [|6;0;0;1;9;5;0;0;0|];[|0;9;8;0;0;0;0;6;0|];[|8;0;0;0;6;0;0;0;3|];[|4;0;0;8;0;3;0;0;1|];[|7;0;0;0;2;0;0;0;6|];[|0;6;0;0;0;0;2;8;0|];[|0;0;0;4;1;9;0;0;5|];[|0;0;0;0;8;0;0;7;9|]|]
    let Sudo = Array2D.init 9 9 (fun i j -> arrayOfArrays[i][j])

  
    let Row(row : int, number :int)=
        arrayOfArrays[row]
        |> Array.contains(number)

    let Column(column : int, number :int)=
        arrayOfArrays[column]
        |> Array.contains(number)

    //let Box(row : int,column : int, number :int)
        


      


