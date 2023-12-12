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
    public class Poker : IJuego
    {
        public IDealer Dealer => throw new NotImplementedException();

        public bool JuegoTerminado => throw new NotImplementedException();

        public void AgregarJugador(IJugador jugador)
        {
            throw new NotImplementedException();
        }

        public void IniciarJuego()
        {
            throw new NotImplementedException();
        }

        public void JugarRonda()
        {
            throw new NotImplementedException();
        }

        public void MostrarGanador()
        {
            throw new NotImplementedException();
        }
    }
}
