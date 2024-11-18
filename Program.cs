using System;

internal class Ejercicio
{
    static void Main()
    {
        bool jugarOtraVez = true;
        while (jugarOtraVez)
        {
            char[,] tablero = new char[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tablero[i, j] = ' ';
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("NOTA:");
            Console.WriteLine("Espero te diviertas :)");
            Console.WriteLine(" ");
            Console.ResetColor();

            Console.WriteLine("Nombre del Jugador 1:");
            string jugador1 = Console.ReadLine();
            Console.WriteLine("Nombre del Jugador 2:");
            string jugador2 = Console.ReadLine();

            Console.WriteLine($"{jugador1}, elige tu símbolo (X o O):");
            char simbolo1 = char.Parse(Console.ReadLine().ToUpper());

            char simbolo2;
            if (simbolo1 == 'X')
            {
                simbolo2 = 'O';
            }
            else
            {
                simbolo2 = 'X';
            }

            Console.WriteLine($"{jugador1} jugará con {simbolo1} y {jugador2} jugará con {simbolo2}.");

            bool juegoTerminado = false;
            char turno = simbolo1;
            string jugadorActual = jugador1;

            while (!juegoTerminado)
            {
                MostrarTablero(tablero);
                Console.WriteLine($"Turno de {jugadorActual} ({turno}).");
                Console.WriteLine("Número de Fila: ");
                int fila = int.Parse(Console.ReadLine()) - 1;
                Console.WriteLine("Número de Columna: ");
                int columna = int.Parse(Console.ReadLine()) - 1;

                if (fila >= 0 && fila < 3 && columna >= 0 && columna < 3 && tablero[fila, columna] == ' ')
                {
                    tablero[fila, columna] = turno;

                    if (HayGanador(tablero))
                    {
                        MostrarTablero(tablero);
                        Console.WriteLine($"¡Felicidades, {jugadorActual} ({turno}) ha ganado!");
                        juegoTerminado = true;
                    }
                    else
                    {
                        if (turno == simbolo1)
                        {
                            turno = simbolo2;
                            jugadorActual = jugador2;
                        }
                        else
                        {
                            turno = simbolo1;
                            jugadorActual = jugador1;
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Posición inválida. Intenta de nuevo.");
                    Console.ResetColor();
                }
            }

            Console.WriteLine("¿Desean jugar otra vez? (s/n):");
            char respuesta = char.Parse(Console.ReadLine().ToLower());
            if (respuesta != 's')
            {
                jugarOtraVez = false;
            }
            else
            {
                Console.Clear();
            }
        }
    }

    static void MostrarTablero(char[,] tablero)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(tablero[i, j]);
                if (j < 2) Console.Write("|");
            }
            Console.WriteLine();
            if (i < 2) Console.WriteLine("-----");
        }
    }

    static bool HayGanador(char[,] tablero)
    {
        for (int i = 0; i < 3; i++)
        {
            if ((tablero[i, 0] == tablero[i, 1] && tablero[i, 1] == tablero[i, 2] && tablero[i, 0] != ' ') ||
                (tablero[0, i] == tablero[1, i] && tablero[1, i] == tablero[2, i] && tablero[0, i] != ' '))
            {
                return true;
            }
        }
        if ((tablero[0, 0] == tablero[1, 1] && tablero[1, 1] == tablero[2, 2] && tablero[0, 0] != ' ') ||
            (tablero[0, 2] == tablero[1, 1] && tablero[1, 1] == tablero[2, 0] && tablero[0, 2] != ' '))
        {
            return true;
        }
        return false;
    }
}




