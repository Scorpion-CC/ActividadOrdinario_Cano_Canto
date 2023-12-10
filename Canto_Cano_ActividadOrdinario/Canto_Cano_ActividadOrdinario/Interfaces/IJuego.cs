﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canto_Cano_ActividadOrdinario.Interfaces
{
    public interface IJuego
    {
        IDealer Dealer { get; }
        bool JuegoTerminado { get; }
        void AgregarJugador(IJugador jugador);
        void IniciarJuego();
        void JugarRonda();
        void MostrarGanador();
    }
}
