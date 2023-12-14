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
    public class Cartas : ICarta
    {
        private FigurasCartasEnum _figura;
        public FigurasCartasEnum Figura 
        {
            get { return _figura; }
            set { _figura = value; }
        }

        private ValoresCartasEnum _valor;
        public ValoresCartasEnum Valor 
        {
            get { return _valor; }
            set { _valor = value; }
        }

        public Cartas (int valorCarta, int figuraCarta)
        { 
            Valor = (ValoresCartasEnum)valorCarta;
            Figura = (FigurasCartasEnum)figuraCarta;
        }

    }
}
