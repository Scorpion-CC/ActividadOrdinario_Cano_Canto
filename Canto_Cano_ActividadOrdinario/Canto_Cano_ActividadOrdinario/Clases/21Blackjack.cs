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

        public IDealer Dealer { get; set; }

        public bool JuegoTerminado 
        {
            get;
            set;
        }

        public void AgregarJugador(IJugador jugador)
        {
            throw new NotImplementedException();
        }

        public void IniciarJuego() //Aquí se le reparte una carta a cada jugador y se le pregunta si quiere otra, hasta que este ya no quiera continuar.
        {
            throw new NotImplementedException();
        }

        //CC: Al final de la ronda vamos a crear otro jugador (el dealer) y en base a el vamos a ver quien gana y quien pierde, tenemos que crear una lista
        //que guarde la puntuación de los jugadores para que en ¨MostrarJugador¨ comparemos esa lista a la puntuación del dealer.
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
