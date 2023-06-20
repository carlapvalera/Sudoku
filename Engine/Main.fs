open Sudo
open System
    

    let Create_Sudoku_1 sudoku =    // crear el sudoku
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
    
    let Create_Sudoku_2 sudoku =    // crear el sudoku
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

    let Create_Sudoku_3 sudoku=
    
        let mutable map = Array2D.zeroCreate 9 9
        let generateRandom(n:int)=
            let mutable temp = [|0;0;0;0;0;0;0;0;0|]
            let random = new Random()
            for i in 0..temp.Length-1 do
                let mutable value = 0
                value<-random.Next(1,10)
                while (temp|>Array.contains(value)) do
                    value<-random.Next(1,10)
                temp[i]<- value
            temp
    
        let Paint (map:int array2d,rellenar:int array, start:int,dimension:int)=
            let mutable k = 0
            let mutable mao = map
            let t = start+dimension
            for i in start..t-1 do
                for j in start ..t-1 do
                    mao[i,j]<-rellenar[k]
                    k<-k+1
            mao
        let Board =
            map<- Paint (map, generateRandom(9),0,3)
            map<- Paint (map, generateRandom(9),3,3)
            map<- Paint (map, generateRandom(9),6,3)
            map
        map<-Board
        map

    let change (sudo:Map<int*int,int>) =
            let mutable sudoku = Array2D.zeroCreate 9 9
            for i in 0..8 do
                for j in 0..8 do
                    if(Map.containsKey(i,j) sudo)then
                        sudoku[i,j]<-Map.find(i,j) sudo
                    else sudoku[i,j]<-0  
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
    let Add_Pos (sudoku:int array2d, row: int, column:int,value:int)=
        let mutable sudo= sudoku
        sudo[row,column]<-value
        sudo
    let Aux (str: string)=
        if(str[0]= 'p')then false
        elif(str[0]='s')then false
        else true
    let Option (str: string)=
        if(str[0]= 'p')then "pista"
        else "solution"

    let Print (sudoku:int array2d) =
        Console.Clear()
        let a = "      1    2    3    4    5    6    7    8    9 "
        Console.WriteLine(a)
        for i in 0..8 do
            Console.Write("{0}    ", i+1)
            for j in 0..8 do
                Console.Write("[{0}]  ",sudoku[i,j])
            Console.WriteLine("\n")
    let Look (sudoku:int array2d)=
        let mutable a = [|10;10|]
        for i in 0..8 do 
            for j in 0..8 do
                if( sudoku[i,j] = 0) then a<-[|i;j|] 
        a       
        
    let main = 
        Console.WriteLine("Sudoku")
        let mutable read = ""
        Console.WriteLine("Elija su constructor de juego")
        Console.WriteLine("1-Create_Sudoku_1")
        Console.WriteLine("2-Create_Sudoku_2")
        Console.WriteLine("3-Create_Sudoku_3")
        read <- Console.ReadLine() 
        Console.Clear()
        while ( read>"3") do 
            Console.WriteLine("Elija su constructor de juego")
            Console.WriteLine("1-Create_Sudoku_1")
            Console.WriteLine("3-Create_Sudoku_3")
            read <-Console.ReadLine()
            Console.Clear()
        let mutable create = Array2D.zeroCreate 9 9

        if(read = "1")then create <- Create_Sudoku_1 create
        elif(read = "2") then create <- Create_Sudoku_2 create
        else create <- Create_Sudoku_3 create
        let a =  (convertirArrayAMap create)
        let mutable sol = solvePosition 0  a
        let mutable solution = sol.Value
        while(sol = None) do 
            sol = solvePosition 0  (convertirArrayAMap create)
            solution = sol.Value
        Print create

        let mutable cont = true
        let mutable row = 0
        let mutable column = 0
        let mutable value = 0
        while(cont) do
            Console.WriteLine("Row")
            let aux = Console.ReadLine()
            if(Aux (aux))then 
                row <- aux|>Int32.Parse
                Console.WriteLine("Column")
                column <- Console.ReadLine()|>Int32.Parse
                Console.WriteLine("Value")
                value <-Console.ReadLine()|>Int32.Parse
                if(row<10&& row>0 && column<10&& column>0)then 
            
                    if(Is_Valid(convertirArrayAMap(create),row-1,column-1,value)) then
                        create<- Add_Pos(create,row-1,column-1,value)
                        Print create
                    else 
                        Print create
                        Console.WriteLine( " disculpa en numero que estas entrando no es valido")

                else 
                    Print create
                    Console.WriteLine( " disculpa las posicion no es valida")
            else 
                if(Option(aux)="pista")then
                    let mutable _sol = solvePosition 0  (convertirArrayAMap create)
                    let mutable _solution = sol.Value
                    if(_sol = None) then
                        cont <- false
                        Console.WriteLine("Lo siento pero modo d resolucion del sudoku fue incorrecto, no hay una solucion vuiable")
                    else
                        let pos = Look create 
                        if(pos[0] =10 && pos[1] = 10) then
                                Print create
                                Console.WriteLine("El sudoku ya esta terminado felicitaciones")
                        else 
                                let f = change _solution
                                create<-Add_Pos(create,pos[0],pos[1],f[pos[0],pos[1]])
                                Print create
                                Console.WriteLine("Pista revelada en la pos[{0},{1}]el valor es {2}",pos[0]+1,pos[1]+1,f[pos[0],pos[1]])


                else
                    let mutable _sol = solvePosition 0  (convertirArrayAMap create)
                    let mutable _solution = sol.Value
                    if(_sol = None) then
                        cont <- false
                        Console.WriteLine("Lo siento pero modo d resolucion del sudoku fue incorrecto, no hay una solucion vuiable")
                    else
                        let ab = change _solution
                        Print ab
                        Console.WriteLine("FINAL SOLUTION")




        
        
            
            





