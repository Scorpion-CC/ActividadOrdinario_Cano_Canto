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
            throw new NotImplementedException();
        }

        //CC: Ahora, después de iniciar el juego se le va a preguntar a cada uno si quiere una carta más, y así va a ser hasta que ya no quiera otra carta
        //y se pasa al siguiente jugador. De preferencia hay que hacer que el bot intente no agarrar cartas si tiene más de 18 puntos (con un if) y 
        //hay que guardar los puntos de cada uno en la lista Puntos que creamos. Al final de la ronda hay que crear un jugador más, que va a ser el dealer.
        public void JugarRonda() 
        {
            throw new NotImplementedException();
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
