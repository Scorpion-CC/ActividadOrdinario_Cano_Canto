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
            for (int i = 0; i < Jugadores.Count; i++)
            {
                Console.WriteLine($"Turno del jugador[{i+1}]: \nDeck:");
                List<ICarta> deckTemp = new List<ICarta>();
                deckTemp = Jugadores[i].MostrarCartas();
                for (int j = 0; j < Jugadores.Count; j++) //Esto es para calcular la puntuación actual que tiene cada jugador.
                {
                    if ((int)deckTemp[i].Valor == 1)
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
                    Console.WriteLine($"Puntos actuales (Jugador[{i + 1}]): {Puntos[i]}");
                    Console.WriteLine($"Jugador[{i + 1}], ¿quieres otra carta? \n 1)Si  2)No");
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
                    Console.ReadKey();
                    Console.Clear();
                } while (Puntos[i] < 18);
            }
        }

        //CC: En base al dealer verificamos quién gana y quién pierde, si este tiene más de 21 todos ganan (menos los que tengan más de 21). 
        //Hay que hacer un if para que automáticamente se salte a los jugadores que tuvieron más de 21 (porque estos ya perdieron).
        public void MostrarGanador() //Pueden haber varios ganadores.
        {
            throw new NotImplementedException();
        }

        public _21Blackjack(IDealer dealer) //CC: Aquí no se modifica nada, a menos que muera el código cuando lo pasemos al main.
        {
            Dealer = dealer;
        }
    }
}
