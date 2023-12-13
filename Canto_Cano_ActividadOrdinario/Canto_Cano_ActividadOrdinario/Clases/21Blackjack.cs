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

        public void IniciarJuego()
        {
            throw new NotImplementedException();
        }

        public void JugarRonda() //Al final de la ronda vamos a crear otro jugador (el dealer) y en base a el vamos a ver quien gana y quien pierde.
        {
            throw new NotImplementedException();
        }

        public void MostrarGanador()
        {
            throw new NotImplementedException();
        }
    }
}
