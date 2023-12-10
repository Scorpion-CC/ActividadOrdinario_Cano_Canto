using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canto_Cano_ActividadOrdinario.Enumeradores;

namespace Canto_Cano_ActividadOrdinario.Interfaces
{
    public interface ICarta
    {
        FigurasCartasEnum Figura { get; }
        ValoresCartasEnum Valor { get; }
    }
}
