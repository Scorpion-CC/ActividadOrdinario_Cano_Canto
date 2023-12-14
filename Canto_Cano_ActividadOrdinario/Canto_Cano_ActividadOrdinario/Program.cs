using Canto_Cano_ActividadOrdinario.Enumeradores;
using Canto_Cano_ActividadOrdinario.Interfaces;
using Canto_Cano_ActividadOrdinario.Clases;

namespace Canto_Cano_ActividadOrdinario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int seleccion, numJugadores;
            DeckDeCartas mainDeck = new DeckDeCartas(new List<ICarta>());
            CrearMainDeck(mainDeck.Cartas);
            Dealer dealer = new Dealer(mainDeck);

            Console.WriteLine("Elija el juego que quiere jugar. \n1) 21BlackJack  2)Poker");
            seleccion = int.Parse(Console.ReadLine());
            if (seleccion == 1) 
            {
                //Acá va todo lo de BlackJack, también se va a preguntar el número de jugadores en esta parte
                _21Blackjack JuegoDe21BlackJack = new _21Blackjack(dealer);
                Console.WriteLine("Ingrese cuántos jugadores van a jugar. (Mínimo = 1 / Máximo = 7)");
                numJugadores = int.Parse(Console.ReadLine());
                if (numJugadores < 1 || numJugadores > 7) { throw new Exception("Cantidad de jugadores no se encuentra en el rango establecido."); }
                else
                {
                    for (int i = 0; i < numJugadores; i++)
                    {

                        List<ICarta> deck = new List<ICarta>();
                        IJugador jugador = new Jugador(deck);
                        JuegoDe21BlackJack.AgregarJugador(jugador);
                    }
                }
                //Acá inicia el juego
                Console.WriteLine($"Se han creado {numJugadores} jugadores, presione cualquier tecla para inciar la ronda.");
                Console.ReadKey();
                JuegoDe21BlackJack.IniciarJuego();
                JuegoDe21BlackJack.JugarRonda();
                JuegoDe21BlackJack.MostrarGanador();
                Console.ReadKey();

            } else if (seleccion == 2) 
            { 
            //Acá van las funciones del poker, preguntamos cuántos jugadores quiere y se inicia el juego.
                Poker JuegoDePoker = new Poker(dealer);
                Console.WriteLine("Ingrese cuántos jugadores van a jugar. (Mínimo = 2 / Máximo = 7)");
                numJugadores = int.Parse(Console.ReadLine());
                if (numJugadores < 2 || numJugadores > 7) { throw new Exception("Cantidad de jugadores no se encuentra en el rango establecido."); }
                else 
                {
                    for (int i = 0; i < numJugadores; i++) {

                        List<ICarta> deck = new List<ICarta>();
                        IJugador jugador = new Jugador(deck);
                        JuegoDePoker.AgregarJugador(jugador);
                    }
                }
                //Acá inicia el juego
                Console.WriteLine($"Se han creado {numJugadores} jugadores, presione cualquier tecla para inciar la ronda.");
                Console.ReadKey();
                JuegoDePoker.IniciarJuego();
                JuegoDePoker.JugarRonda();
                JuegoDePoker.MostrarGanador();
                Console.ReadKey();
            }
            else { throw new Exception("Selección no válida."); } //Esto es por si se elije un numero que no sea 1 o 2, o cualquier otra cosa.
        }

        static void CrearMainDeck(List<ICarta> mainDeck)  //Aquí se añade cada carta al main deck, los 13 valores para las 4 figuras de cartas.
        {
            ICarta carta;
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 13; j++)

                {
                    mainDeck.Add(carta = new Cartas(j, i));
                }
            }

        }
    }
}
