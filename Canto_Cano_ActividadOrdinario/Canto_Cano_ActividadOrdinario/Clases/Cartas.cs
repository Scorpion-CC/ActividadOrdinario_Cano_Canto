﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canto_Cano_ActividadOrdinario.Enumeradores;
using Canto_Cano_ActividadOrdinario.Interfaces;
using Canto_Cano_ActividadOrdinario.Clases;

namespace Canto_Cano_ActividadOrdinario.Clases
{
    public class Cartas : ICarta , IDeckDeCartas
    {
        public FigurasCartasEnum Figura => throw new NotImplementedException();

        public ValoresCartasEnum Valor => throw new NotImplementedException();

        public void BarajearDeck()
        {
            throw new NotImplementedException();
        }

        public void MeterCarta(ICarta carta)
        {
            throw new NotImplementedException();
        }

        public void MeterCarta(List<ICarta> cartas)
        {
            throw new NotImplementedException();
        }

        public ICarta SacarCarta(int indiceCarta)
        {
            throw new NotImplementedException();
        }

        public ICarta VerCarta(int indiceCarta)
        {
            throw new NotImplementedException();
        }
    }
}
