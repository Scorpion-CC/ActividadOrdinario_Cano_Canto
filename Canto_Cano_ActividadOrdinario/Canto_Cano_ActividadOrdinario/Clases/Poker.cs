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

        private List<IJugador> Jugadores = new List<IJugador>();
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

                for (int j = 0; j < 5; j++)
                {
                    int seleccion, numCarta, seleccion2;
                    bool JugadorQuiereCartas = false;
                    List<ICarta> cartasADevolver = new List<ICarta>();

                    Jugadores[i].ObtenerCartas(Dealer.RepartirCartas(5));
                    do
                    {
                        Console.WriteLine("¿Desea cambiar alguna carta? \n1)Si 2)Cambiar todas las cartas 3)No");
                        seleccion = rand.Next(1, 4); //Para que el bot seleccione un numero al azar del 1 al 2.
                        if (seleccion == 1)
                        {

                            Console.WriteLine("Elija la carta que quiera cambiar:");
                            numCarta = rand.Next(1, 6);
                            Dealer.RecogerCartas(Jugadores[i].DevolverCarta(numCarta));
                            Jugadores[i].ObtenerCartas(Dealer.RepartirCartas(1));
                        }
                        else if (seleccion == 2)
                        {

                            Dealer.RecogerCartas(Jugadores[i].DevolverTodasLasCartas());


                        }
                        else { }
                        Console.WriteLine("¿Quiere cambiar otra carta? \n 1)Si 2)No");
                        seleccion2 = rand.Next(1, 3);
                        if (seleccion2 == 1)
                        {
                            JugadorQuiereCartas = true;
                        }
                        else { JugadorQuiereCartas = false; }

                    } while (JugadorQuiereCartas);
                }
            }
        }

        public void JugarRonda()
        {
            throw new NotImplementedException();
        }

        public void MostrarGanador()
        {
            throw new NotImplementedException();
        }

        public Poker (IDealer dealer)
        {
            Dealer = dealer;
        }
    }
}
