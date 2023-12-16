using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canto_Cano_ActividadOrdinario.Enumeradores;
using Canto_Cano_ActividadOrdinario.Interfaces;
using Canto_Cano_ActividadOrdinario.Clases;

namespace Canto_Cano_ActividadOrdinario.Clases
{
    public class _21Blackjack : IJuego 
    {
        Random rand = new Random();

        private List<IJugador> Jugadores = new List<IJugador>();
        private List<int> Puntos = new List<int>();

        public IDealer Dealer { get; set; }

        public bool JuegoTerminado 
        {
            get;
            set;
        }

        public void AgregarJugador(IJugador jugador)
        {
            Jugadores.Add(jugador);
        }

        public void IniciarJuego() //Aquí se le reparte dos cartas a cada jugador, y ya.
        {
            for (int i = 0; i < Jugadores.Count; i++) 
            {
                Puntos.Add(0);
                Jugadores[i].ObtenerCartas(Dealer.RepartirCartas(2));
                Console.WriteLine($"\nMano inicial del jugador[{i+1}]:");
                Jugadores[i].MostrarCartas();
                
            }
            Puntos.Add(0);
        }

        //CC: Ahora, después de iniciar el juego se le va a preguntar a cada uno si quiere una carta más, y así va a ser hasta que ya no quiera otra carta
        //y se pasa al siguiente jugador. De preferencia hay que hacer que el bot intente no agarrar cartas si tiene más de 18 puntos (con un if) y 
        //hay que guardar los puntos de cada uno en la lista Puntos que creamos. Al final de la ronda hay que crear un jugador más, que va a ser el dealer.
        public void JugarRonda() 
        {
            Console.ReadKey();
            Console.Clear();
            int seleccion, seleccion2;
            List<ICarta> deckTemp = new List<ICarta>();
            for (int i = 0; i < Jugadores.Count; i++)
            {
                Console.WriteLine($"Turno del jugador[{i+1}]: \nDeck:");
                deckTemp = Jugadores[i].MostrarCartas();
                for (int j = 0; j < deckTemp.Count; j++) //Esto es para calcular la puntuación actual que tiene cada jugador.
                {
                    if ((int)deckTemp[j].Valor == 1)
                    {
                        Console.WriteLine($"\nJugador[{i+1}], elije el valor del As en tu mano \n 1) 1pt  2) 11pts");
                        if (Puntos[i] < 11)
                        {
                            seleccion2 = 2;
                            Console.WriteLine($"\nJugador[{i + 1}]: {seleccion2}");
                            Puntos[i] += 11;
                        }
                        else 
                        {
                            seleccion2 = 1;
                            Console.WriteLine($"\nJugador[{i + 1}]: {seleccion2}");
                            Puntos[i] += 1;
                        }
                    }
                    else
                    {
                        Puntos[i] += (int)deckTemp[i].Valor; 
                    }

                }
                do
                {
                    Console.WriteLine($"\nPuntos actuales (Jugador[{i + 1}]): {Puntos[i]}");
                    Console.WriteLine($"\nJugador[{i + 1}], ¿quieres otra carta? \n 1)Si  2)No");
                    if (Puntos[i] < 18)
                    {
                        seleccion = 1;
                        Console.WriteLine($"Jugador[{i + 1}]: {seleccion}");
                        deckTemp.AddRange(Dealer.RepartirCartas(1));
                        Puntos[i] = +(int)deckTemp[deckTemp.Count].Valor;
                    }
                    else
                    {
                        seleccion = 2;
                        Console.WriteLine($"Jugador[{i + 1}]: {seleccion}");
                    }
                    Console.WriteLine("\nMano actual: ");
                    Console.WriteLine($"Puntaje: {Puntos[i]}");
                    Jugadores[i].MostrarCartas();
                    Console.ReadKey();
                    Console.Clear();
                } while (Puntos[i] < 18);

                if (Puntos[i] > 21) 
                {
                    Console.WriteLine($"\nJugador[{i + 1}], has perdido. Tienes más de 21 puntos.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            Console.WriteLine("Turno del Dealer: ");
            List<ICarta> deck = new List<ICarta>();
            IJugador jugador = new Jugador(deck);
            this.AgregarJugador(jugador);
            Jugadores[Jugadores.Count].ObtenerCartas(Dealer.RepartirCartas(2));
            deckTemp = Jugadores[Jugadores.Count].MostrarCartas();
            for (int i = 0; i < deckTemp.Count; i++)
            {
                if ((int)deckTemp[i].Valor == 1)
                {
                    Console.WriteLine($"\nEl dealer tiene un As en su mano.");
                    if (Puntos[Puntos.Count] < 11)
                    {
                        seleccion2 = 2;
                        Console.WriteLine($"\nEste As va a valer 11 puntos.");
                        Puntos[Puntos.Count] += 11;
                    }
                    else
                    {
                        seleccion2 = 1;
                        Console.WriteLine($"Este As va a valer 1 punto.");
                        Puntos[Puntos.Count] += 1;
                    }
                }
                else
                {
                    Puntos[Puntos.Count] += (int)deckTemp[i].Valor;
                }
            }
            do
            {
                Console.WriteLine($"Puntos actuales del dealer: {Puntos[Puntos.Count]}");
                if (Puntos[Puntos.Count] < 18)
                {
                    seleccion = 1;
                    Console.WriteLine($"El dealer agarra otra carta.");
                    deckTemp.AddRange(Dealer.RepartirCartas(1));
                    Puntos[Puntos.Count] = +(int)deckTemp[deckTemp.Count].Valor;
                }
                else
                {
                    seleccion = 2;
                    Console.WriteLine($"El dealer decide no agarrar otra carta");
                }
                Console.WriteLine("Mano actual del dealer:");
                Jugadores[Jugadores.Count].MostrarCartas();
                Console.WriteLine($"Puntaje: {Puntos[Puntos.Count]}");
                Console.ReadKey();
                Console.Clear();
            } while (Puntos[Puntos.Count] < 18);
        }

        //CC: En base al dealer verificamos quién gana y quién pierde, si este tiene más de 21 todos ganan (menos los que tengan más de 21). 
        //Hay que hacer un if para que automáticamente se salte a los jugadores que tuvieron más de 21 (porque estos ya perdieron).
        public void MostrarGanador() //Pueden haber varios ganadores.
        {
            Console.WriteLine("Puntajes finales: ");
            for (int i = 0; i < Jugadores.Count - 1; i++)
            {
                Console.WriteLine($"Jugador[{i+1}]: {Puntos[i]} pts.");
            }
            Console.WriteLine($"Dealer: {Puntos[Jugadores.Count]} pts.");

            for (int i = 0; i < Jugadores.Count - 1; i++) 
            {

                if (Puntos[i] > 21)
                {
                    Console.WriteLine($"El jugador[{i + 1}] ha perdido");
                }
                else 
                {
                    if (Puntos[i] > Puntos[Puntos.Count]) 
                    {

                        Console.WriteLine($"El jugador[{i+1}] ha ganado");
                    }            
                }            
            }
        }

        public _21Blackjack(IDealer dealer) //CC: Aquí no se modifica nada, a menos que muera el código cuando lo pasemos al main.
        {
            Dealer = dealer;
        }
    }
}
