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

                        Console.WriteLine($"Jugador[{i}]: {seleccion}"); //Ya que los jugadores son bots, tenemos que mostrar sus acciones de esta manera.

                        if (seleccion == 1)
                        {

                            Console.WriteLine("Elija la carta que quiera cambiar:");
                            numCarta = rand.Next(0, 5);
                            Console.WriteLine($"Jugador[{i}]: {numCarta + 1}");
                            cartasADevolver.Add(Jugadores[i].DevolverCarta(numCarta)); //Modificar la clase jugador para que se elimine la carta de este antes de darla.
                            Dealer.RecogerCartas(cartasADevolver);
                            cartasADevolver.Clear();
                            Jugadores[i].ObtenerCartas(Dealer.RepartirCartas(1));
                        }
                        else if (seleccion == 2)
                        {
                            Dealer.RecogerCartas(Jugadores[i].DevolverTodasLasCartas()); //Modificar el comportamiento de la funcion para eliminar las cartas despues de darlas.
                            Jugadores[i].ObtenerCartas(Dealer.RepartirCartas(5)); //Modificar el RepartirCartas para que imprima las cartas dadas.
                        }
                        else { }
                        Console.WriteLine("¿Quiere cambiar otra carta? \n 1)Si 2)No");
                        seleccion2 = rand.Next(1, 3);
                        Console.WriteLine($"Jugador[{i}]: {seleccion2}");
                        if (seleccion2 == 1)
                        {
                            JugadorQuiereCartas = true;
                        }
                        else { JugadorQuiereCartas = false; }

                    } while (JugadorQuiereCartas);
                }
            }
        }

        //CC: prácticamente lo único que se debe hacer en ¨JugarRonda¨ es verificar qué tipo de mano tiene cada jugador,
        // y de ahí asignarle un valor para que después en ¨MostrarGanador¨ sólo se imprima el jugador con más puntos (mejor deck).

        public void JugarRonda() //Jugar la ronda de acuerdo a las reglas del Poker Clásico, 
        {
            throw new NotImplementedException(); 
        }

        public void MostrarGanador() //El jugador con mejor mano es el ganador, fácil.
        {
            throw new NotImplementedException();
        }

        public Poker (IDealer dealer) //Aquí no se modifica nada.
        {
            Dealer = dealer;
        }
    }
}
