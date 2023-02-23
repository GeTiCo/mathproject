//ОСНОВНОЙ БЛОК
int[,] C = {
    {0,0,0,0,0,0},
    {0,0,0,0,0,0},
    {0,0,0,0,0,0},
    {0,0,0,0,0,0},
    {0,0,0,0,0,0},
    {0,0,0,0,0,0}
};
//МАСКА БЛОК-МАРШРУТ
int[,] D = {
    {0,0,0,0,0,0},
    {0,0,0,0,0,0},
    {0,0,0,0,0,0},
    {0,0,0,0,0,0},
    {0,0,0,0,0,0},
    {0,0,0,0,0,0}
};
//ГОРИЗОНТАЛЬ БЛОК
int[,] H = {
    {1,8,9,8,7,8},
    {3,5,6,7,6,6},
    {2,2,4,5,4,3},
    {2,3,4,5,2,1},
    {2,4,3,2,1,9}
};
//ВЕРТИКАЛЬ БЛОК
int[,] V = {
    {0,1,2,3,4,1},
    {8,5,3,5,4,4},
    {6,7,2,7,6,6},
    {9,8,5,9,7,9},
    {9,9,9,8,8,1}
};

C[0, 5] = 0;

//ГОРИЗОНТАЛЬНАЯ ЛИНИЯ
for (int i = 4; i >= 0; i--)
{
    C[0, i] = C[0, i + 1] + V[i, 0];
}

//ВЕРТИКАЛЬНАЯ ЛИНИЯ
for (int i = 0; i <= 4; i++)
{
    C[i + 1, 5] = C[i, 5] + H[i, 5];
}

//ОСТАТОК ЗНАЧЕНИЙ
for(int i = 1; i <= 5; i++)
{
    for(int j = 4; j >= 0; j--)
    {
        int sumVertical = C[i - 1, j] + H[i - 1, j];
        int sumHorizontal = C[i, j + 1] + V[j, i];

        if(sumVertical > sumHorizontal)
        {
            C[i, j] = sumHorizontal;
        }
        else
        {
            C[i, j] = sumVertical;
        }
        
    }
}

//ПОИСК ПУТИ
int i1 = 5;
int j1 = 0;
while (true)
{
    
    int active = C[i1, j1];

    D[i1, j1] = active;

    int Horiz = active - V[j1,i1];

    if(Horiz == C[i1,j1 + 1])
    {
        j1++;
    }
    else
    {
        i1--;
    }
    if (C[i1, j1] == 0 || (i1 == 0 && j1 == 5))
    {
        break;
    }
}

//ВЫВОД МАТРИЦЫ
for (int i = 0; i <= 5; i++)
{
    for (int j = 0; j <= 5; j++)
    {
        if (C[i, j] == D[i, j])
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(C[i, j] + "\t");
        }
        else
        {
            Console.ResetColor();
            Console.Write(C[i, j] + "\t");
        }
    }
    Console.WriteLine();
}
Console.ReadKey();