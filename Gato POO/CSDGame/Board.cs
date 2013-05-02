using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace CSDGame
{
    public class Tablero
    {
        public int movesMade = 0;
        public int Owins = 0;
        public int Xwins = 0;
        private Propietario[,] propietario = new Propietario[3,3];
       
        public const int X = 0;
        public const int O = 1;
        public const int B = 2;

        public int playersTurn = X;

        public int getPlayerForTurn()
        {
            return playersTurn;
        }

        public int getOWins()
        {
            return Owins;
        }

        public int getXWins()
        {
            return Xwins;
        }

        public void initTablero()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    propietario[x, y] = new Propietario();
                    propietario[x, y].setValue(B);
                    propietario[x, y].setLocation(new Point(x,y));
                }
            }
        }

        public void detectHit(Point loc)
        {
            // Revisa si el tablero ha sido cliqueado
            if (loc.Y <= 500)
            {
                int x = 0;
                int y = 0;

                if (loc.X < 167)
                {
                    x = 0;
                }
                else if (loc.X > 167 && loc.X < 334)
                {
                    x = 1;
                }
                else if (loc.X > 334)
                {
                    x = 2;
                }

                if (loc.Y < 167)
                {
                    y = 0;
                }
                else if (loc.Y > 167 && loc.Y < 334)
                {
                    y = 1;
                }
                else if (loc.Y > 334 && loc.Y < 500)
                {
                    y = 2;
                }

                if (movesMade % 2 == 0)
                {
                    GFX.drawX(new Point(x, y));
                    propietario[x, y].setValue(X);
                    if (detectRow())
                    {
                        MessageBox.Show("Felicidades has ganado X");
                        Xwins++;
                        reset();
                        GFX.setUpCanvas();
                    }

                    playersTurn = O;
                }
                else
                {
                    GFX.drawO(new Point(x, y));
                    propietario[x, y].setValue(O);
                    if (detectRow())
                    {
                        MessageBox.Show("Felicidades has ganado, O");
                        Owins++;
                        reset();
                        GFX.setUpCanvas();
                    }

                    playersTurn = X;
                }

                movesMade++;
            }
        }
        public bool detectRow()
        {
            bool isWon = false;

            for (int x = 0; x < 3; x++)
            {
                if (propietario[x, 0].getValue() == X && propietario[x, 1].getValue() == X && propietario[x, 2].getValue() == X)
                {
                    return true;
                }
                if (propietario[x, 0].getValue() == O && propietario[x, 1].getValue() == O && propietario[x, 2].getValue() == O)
                {
                    return true;
                }

                // Detecta las lineas diagonales
                switch (x)
                {
                    case 0:
                        if (propietario[x, 0].getValue() == X && propietario[x + 1, 1].getValue() == X && propietario[x + 2, 2].getValue() == X)
                        {
                            return true;
                        }
                        if (propietario[x, 0].getValue() == O && propietario[x + 1, 1].getValue() == O && propietario[x + 2, 2].getValue() == O)
                        {
                            return true;
                        }

                        break;

                    case 2:
                        if (propietario[x, 0].getValue() == X && propietario[x - 1, 1].getValue() == X && propietario[x - 2, 2].getValue() == X)
                        {
                            return true;
                        }
                        if (propietario[x, 0].getValue() == O && propietario[x - 1, 1].getValue() == O && propietario[x - 2, 2].getValue() == O)
                        {
                            return true;
                        }
                        break;
                }
            }

            for (int y = 0; y < 3; y++)
            {
                if (propietario[0, y].getValue() == X && propietario[1, y].getValue() == X && propietario[2, y].getValue() == X)
                {
                    return true;
                }
                if (propietario[0, y].getValue() == O && propietario[1, y].getValue() == O && propietario[2, y].getValue() == O)
                {
                    return true;
                }
            }

            return isWon;
        }

        public void reset()
        {
            propietario = new Propietario[3, 3];
            initTablero();
        }
    }

    class Propietario
    {
        private Point location;
        private int value = Tablero.B;

        public void setLocation(Point p)
        {
            location = p;
        }
        public Point getLocation()
        {
            return location;
        }

        public void setValue(int i)
        {
            value = i;
        }
        public int getValue()
        {
            return value;
        }

    }
}
