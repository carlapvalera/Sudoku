open Sudo
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
        let generateRandom(n:int)=
            let mutable temp = [|0;0;0;0;0;0;0;0;0|]
            let random = new Random()
            for i in 0..temp.Length-1 do
                let mutable value = 0
                do 
                    value<-random.Next(1,10)
                while (temp|>Array.contains(value)) do
                    temp[i]<- value
            temp

        let Board =

            let mutable map = Array2D.zeroCreate 9 9
            map<- Paint (map, generateRandom(9),0,3)
            map<- Paint (map, generateRandom(9),3,3)
            map<- Paint (map, generateRandom(9),6,3)
            map


       // let Paint (mao:int array2d,rellenar:list<int>, start:int,dimension:int)=
         //   let mutable k = 0
           // let mutable mao = map
            //let t = start+dimension
            //for i in start..t do
               // for j in start ..t do
                 //   mao[i,j]<-rellenar[k+1]
            //mao

        
    let convertirArrayAMap (array: 'a [,]) =
        let mutable mapa = Map.empty
        for fila in 0 .. Array2D.length1 array - 1 do
            for columna in 0 .. Array2D.length2 array - 1 do
                if(array.[fila, columna]<>0) then
                    let clave =  (fila,columna)
                    let valor = array.[fila, columna]
                    mapa <- mapa.Add(clave, valor)
        mapa


   





