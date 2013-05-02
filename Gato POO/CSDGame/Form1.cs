using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSDGame
{
    public partial class Form1 : Form
    {
        public GFX engine;
        public Tablero ElTablero;

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics toPass = panel1.CreateGraphics();
            engine = new GFX(toPass);

            ElTablero = new Tablero();
            ElTablero.initTablero();

            refreshLabel();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Point mouse = Cursor.Position;
            mouse = panel1.PointToClient(mouse);
            ElTablero.detectHit(mouse);
            refreshLabel();
        }

        private void rButton_Click(object sender, EventArgs e)
        {
            ElTablero.reset();
            GFX.setUpCanvas();
        }

        private void aButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Este tablero de Tic Tac Toe ha sido creado por Iliana, Juan, Evelin, J. Pablo para el proyecto de POO en base a un videotutorial");
        }

        private void eButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void refreshLabel()
        {
            String newText = "Le toca a ";
            if (ElTablero.getPlayerForTurn() == Tablero.X)
            {
                newText += "X";
            }
            else
            {
                newText += "O";
            }

            newText += " \n";
            newText += "X Ha ganado " + ElTablero.getXWins() + " Partidas.\nO Ha ganado " + ElTablero.getOWins() + " Partidas";

            label1.Text = newText;
        }
    }
}
