using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canto_Cano_ActividadOrdinario.Enumeradores;
using Canto_Cano_ActividadOrdinario.Interfaces;
using Canto_Cano_ActividadOrdinario.Clases;
using System.Collections.Specialized;

namespace Canto_Cano_ActividadOrdinario.Clases
{
    public class Poker : IJuego 
    {
        Random rand = new Random();

        public List<int> puntos = new List<int>(); //Lista que permite guardar los puntajes de los jugadores para facilitar determinar al ganador.

        public List<IJugador> Jugadores = new List<IJugador>();
        public IDealer Dealer { get; set; }

        public bool JuegoTerminado { get; set; }

        public void AgregarJugador(IJugador jugador)
        {
            Jugadores.Add(jugador);
        }

        public void IniciarJuego()
        {
            for (int i = 0; i < Jugadores.Count; i++) 
            {

                    int seleccion, numCarta, seleccion2;
                    bool JugadorQuiereCartas = false;
                    List<ICarta> cartasADevolver = new List<ICarta>();

                Console.WriteLine($"Primera baraja del jugador[{i+1}]:");
                Jugadores[i].ObtenerCartas(Dealer.RepartirCartas(5));
                Jugadores[i].MostrarCartas();

                do
                {
                        Console.WriteLine("\n¿Desea cambiar alguna carta? \n1)Si 2)Cambiar todas las cartas 3)No");
                        seleccion = rand.Next(1, 4); //Para que el bot seleccione un numero al azar del 1 al 2.

                        Console.WriteLine($"Jugador[{i+1}]: {seleccion}"); //Ya que los jugadores son bots, tenemos que mostrar sus acciones de esta manera.

                        if (seleccion == 3)
                        {
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else if (seleccion == 2)
                        {
                            Dealer.RecogerCartas(Jugadores[i].DevolverTodasLasCartas()); //Modificar el comportamiento de la funcion para eliminar las cartas despues de darlas.
                            Jugadores[i].ObtenerCartas(Dealer.RepartirCartas(5)); //Modificar el RepartirCartas para que imprima las cartas dadas.
                            Console.WriteLine($"\nNueva baraja (Jugador[{i+1}]): ");
                            Jugadores[i].MostrarCartas();//Aquí el usuario mostraría sus cartas.
                        }
                        else if (seleccion == 1)
                        {

                            Console.WriteLine("\nElija la carta que quiera cambiar:");
                            numCarta = rand.Next(0, 5);
                            Console.WriteLine($"Jugador[{i + 1}]: {numCarta + 1}");
                            cartasADevolver.Add(Jugadores[i].DevolverCarta(numCarta)); //Modificar la clase jugador para que se elimine la carta de este antes de darla.
                            Dealer.RecogerCartas(cartasADevolver);
                            cartasADevolver.Clear();
                            Jugadores[i].ObtenerCartas(Dealer.RepartirCartas(1));

                        }
                        Console.WriteLine("\n¿Quiere cambiar otra carta? \n 1)Si 2)No");
                        seleccion2 = rand.Next(1, 3);
                        Console.WriteLine($"Jugador[{i+1}]: {seleccion2}");
                        if (seleccion2 == 1)
                        {
                            JugadorQuiereCartas = true;
                        }
                        else if (seleccion2 == 2){JugadorQuiereCartas = false;}
                        Console.ReadKey();
                    Console.Clear();
                } while (JugadorQuiereCartas == true);
                    
            }
        }

        //CC: prácticamente lo único que se debe hacer en ¨JugarRonda¨ es verificar qué tipo de mano tiene cada jugador,
        // y de ahí asignarle un valor para que después en ¨MostrarGanador¨ sólo se imprima el jugador con más puntos (mejor deck).

        public void JugarRonda() //Jugar la ronda de acuerdo a las reglas del Poker Clásico, todos los valores dados van a ser múltiplos de 13, dependiendo del
                                 //tipo de mano, y a estos se le añade el valor de la última carta para que se determine qué deck fue mejor.
        {
            for (int i = 0; i < Jugadores.Count; i++) 
            {
                puntos.Add(0);
            }
            List<ICarta> deckTemp = new List<ICarta>();
            for (int i = 0; i < Jugadores.Count; i++)
            {
                Console.WriteLine($"\nJugador[{i+1}]:");
                deckTemp = Jugadores[i].MostrarCartas(); //Para poder acceder a los valores de las cartas del deck del jugador.
                deckTemp = OrdenarCartasPorValor(deckTemp);

                if (deckTemp[0].Figura == deckTemp[1].Figura && deckTemp[1].Figura == deckTemp[2].Figura && 
                    deckTemp[2].Figura == deckTemp[3].Figura && deckTemp[3].Figura == deckTemp[4].Figura) //verificar que todas las figuras del deck sean iguales
                {
                    if ((int)deckTemp[0].Valor == 1 && (int)deckTemp[1].Valor == 10 && (int)deckTemp[2].Valor == 11 && (int)deckTemp[3].Valor == 12 && (int)deckTemp[4].Valor == 13)
                    { 
                        Console.WriteLine($"El jugador[{i + 1}] tiene una escalera real.");
                        puntos[i] = 130 + (int)deckTemp[0].Figura; 
                        //Este puntaje es para que cuente como el mayor, se le añade el valor de la figura en el caso de que hayan 2 escaleras reales. 
                    }
                    else if ((int)deckTemp[1].Valor == (int)deckTemp[0].Valor + 1 && (int)deckTemp[2].Valor == (int)deckTemp[0].Valor + 2 &&
                            (int)deckTemp[3].Valor == (int)deckTemp[0].Valor + 3 && (int)deckTemp[4].Valor == (int)deckTemp[0].Valor + 4) 
                    {
                        Console.WriteLine($"El jugador [{i+1}] tiene una escalera de color.");
                        puntos[i] = 127 + (int)deckTemp[4].Valor; 
                    }
                    else { Console.WriteLine($"El jugador[{i+1}] tiene una mano del mismo color"); puntos[i] = 78 + (int)deckTemp[4].Valor; }

                } 
                else  
                {
                    if (deckTemp[0].Valor == deckTemp[1].Valor && deckTemp[1].Valor == deckTemp[2].Valor && deckTemp[2].Valor == deckTemp[3].Valor ||
                        deckTemp[1].Valor == deckTemp[2].Valor && deckTemp[2].Valor == deckTemp[3].Valor && deckTemp[3].Valor == deckTemp[4].Valor)
                    {
                        Console.WriteLine($"El jugador[{i + 1}] tiene un Poker");
                        puntos[i] = 104 + (int)deckTemp[4].Valor;
                    }
                    else if ((int)deckTemp[0].Valor == (int)deckTemp[1].Valor && (int)deckTemp[1].Valor == (int)deckTemp[2].Valor && (int)deckTemp[3].Valor == (int)deckTemp[4].Valor ||
                             (int)deckTemp[0].Valor == (int)deckTemp[1].Valor && (int)deckTemp[2].Valor == (int)deckTemp[3].Valor && (int)deckTemp[3].Valor == (int)deckTemp[4].Valor)
                    {
                        Console.WriteLine($"El jugador[{i + 1}] tiene un Full");
                        puntos[i] = 91 + (int)deckTemp[4].Valor;
                    }
                    else if ((int)deckTemp[1].Valor == (int)deckTemp[0].Valor + 1 && (int)deckTemp[2].Valor == (int)deckTemp[0].Valor + 2 &&
                            (int)deckTemp[3].Valor == (int)deckTemp[0].Valor + 3 && (int)deckTemp[4].Valor == (int)deckTemp[0].Valor + 4)
                    {

                        Console.WriteLine($"El jugador[{i + 1}] tiene una Escalera de {deckTemp[4].Valor}");
                        puntos[i] = 65 + (int)deckTemp[4].Valor;
                    }
                    else if (deckTemp[0].Valor == deckTemp[1].Valor && deckTemp[1].Valor == deckTemp[2].Valor ||
                             deckTemp[1].Valor == deckTemp[2].Valor && deckTemp[2].Valor == deckTemp[3].Valor ||
                             deckTemp[2].Valor == deckTemp[3].Valor && deckTemp[3].Valor == deckTemp[4].Valor)
                    {
                        Console.WriteLine($"El jugador[{i + 1}] tiene un Trio");
                        puntos[i] = 52 + (int)deckTemp[2].Valor;
                    }
                    else if (deckTemp[0].Valor == deckTemp[1].Valor && deckTemp[2].Valor == deckTemp[3].Valor ||
                             deckTemp[1].Valor == deckTemp[2].Valor && deckTemp[3].Valor == deckTemp[4].Valor)
                    {
                        Console.WriteLine($"El jugador[{i + 1}] tiene una Doble Pareja");
                        puntos[i] = 39 + (int)deckTemp[3].Valor;
                    }
                    else if (deckTemp[0].Valor == deckTemp[1].Valor)
                    {
                        Console.WriteLine($"El jugador[{i + 1}] tiene una Pareja");
                        puntos[i] = 26 + (int)deckTemp[1].Valor;
                    }
                    else if (deckTemp[1].Valor == deckTemp[2].Valor)
                    {
                        Console.WriteLine($"El jugador[{i + 1}] tiene una Pareja");
                        puntos[i] = 26 + (int)deckTemp[2].Valor;
                    }
                    else if (deckTemp[2].Valor == deckTemp[3].Valor)
                    {
                        Console.WriteLine($"El jugador[{i + 1}] tiene una Pareja");
                        puntos[i] = 26 + (int)deckTemp[3].Valor;
                    }
                    else if (deckTemp[3].Valor == deckTemp[4].Valor)
                    {
                        Console.WriteLine($"El jugador[{i + 1}] tiene una Pareja");
                        puntos[i] = 26 + (int)deckTemp[4].Valor;
                    }
                    else 
                    {
                        Console.WriteLine($"El jugador[{i+1}] no tiene una mano. Su carta más alta es el {deckTemp[4].Valor} de {deckTemp[4].Figura}");
                        puntos[i] = 13 + (int)deckTemp[4].Valor;
                    }
                }
                deckTemp.Clear();
            }
        }

        public void MostrarGanador() //El jugador con mejor mano (O sea con más puntos) es el ganador, fácil.
        {
            int numTemp = 0, posicionGanador = 0; //Para guardar la posición del jugador con mayor puntaje.
            for (int i = 0; i < puntos.Count; i++) 
            {
                if (puntos[i] > numTemp) 
                { 
                
                    numTemp = puntos[i];
                    posicionGanador = i;
                
                }
            }
            Console.WriteLine($"\n----------------------------------------\nEl ganador es el jugador [{posicionGanador + 1}]\n----------------------------------------");
        }

        public List<ICarta> OrdenarCartasPorValor(List<ICarta> deck) 
        {
            ICarta cartaTemp;

            for (int i = 1; i < deck.Count; i++) 
            {

                for (int j = 0; j < deck.Count - i; j++) 
                {

                    if ((int)deck[j].Valor > (int)deck[j + 1].Valor) 
                    {  
                        cartaTemp = deck[j+1];
                        deck[j+1] = deck[j];
                        deck[j] = cartaTemp;
                    }
                }
            
            }
            return deck;
        }

        public List<ICarta> OrdenarCartasPorFigura(List<ICarta> deck) 
        {

            ICarta cartaTemp;

            for (int i = 1; i < deck.Count; i++)
            {

                for (int j = 0; j < deck.Count - i; j++)
                {

                    if ((int)deck[j].Figura > (int)deck[j + 1].Figura)
                    {
                        cartaTemp = deck[j + 1];
                        deck[j + 1] = deck[j];
                        deck[j] = cartaTemp;
                    }
                }

            }
            return deck;

        }

        public Poker (IDealer dealer) //Aquí no se modifica nada.
        {
            Dealer = dealer;
        }
    }
}
