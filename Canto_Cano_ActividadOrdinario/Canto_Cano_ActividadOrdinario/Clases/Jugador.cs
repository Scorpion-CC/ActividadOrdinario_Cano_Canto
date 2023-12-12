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
    public class Jugador : IJugador
    {
        public ICarta DevolverCarta(int indiceCarta)
        {
            throw new NotImplementedException();
        }

        public List<ICarta> DevolverTodasLasCartas()
        {
            throw new NotImplementedException();
        }

        public ICarta MostrarCarta(int indiceCarta)
        {
            throw new NotImplementedException();
        }

        public List<ICarta> MostrarCartas()
        {
            throw new NotImplementedException();
        }

        public void ObtenerCartas(List<ICarta> cartas)
        {
            throw new NotImplementedException();
        }

        public void RealizarJugada()
        {
            throw new NotImplementedException();
        }
    }
}
