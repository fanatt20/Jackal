﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JackalEngine;
namespace WindowsFormsApplication1
{

    public partial class PlayGroundCopy : Form
    {
        private Game game;
        int player = 0;
        private int totalPlayers;
        private int NextPlayer(int currentPlayerID)
        {
            switch (totalPlayers)
            {
                case 1:
                    return 0;
                case 2:
                    return player == 0 ? player++ : player--;
                default:
                    return -1;

            }

        }
        public PlayGroundCopy(int numberOfPlayers)
        {
            this.game = new Game(numberOfPlayers);
            totalPlayers = numberOfPlayers;
            InitializeComponent();
            if (numberOfPlayers < 2)
                groupBox3.Visible = false;

            for (int i = 0; i < game.Map.XSize; i++)
            {
                DataGridViewImageColumn clmn = new DataGridViewImageColumn();
                dataGridView1.Columns.Add(clmn);
            }
            dataGridView1.Rows.Add(game.Map.YSize);
            PrintMap(game.Map);
        }


        private void PrintMap(GameMap map)
        {
            for (int i = 0; i < GameMap._ySize; i++)
            {
                for (int j = 0; j < GameMap._xSize; j++)
                {
                    dataGridView1[i, j].Value = DrawCell(map[i, j]);
                }
            }
        }

        private Image DrawCell(Cell cell)
        {
            Image picture = Image.FromFile("Empty.bmp");
            switch (cell.Type)
            {
                case CellType.Unreached:
                    picture = Image.FromFile("Smoke.jpg");
                    break;
                case CellType.Water:
                    picture = Image.FromFile("Water.jpg");
                    break;
                case CellType.WithGold:
                    picture = Image.FromFile("Gold.jpg");
                    break;
                case CellType.Character1:
                    picture = Image.FromFile("Pirate1.jpg");
                    break;
                case CellType.Character2:
                    picture = Image.FromFile("Pirate2.jpg");
                    break;
                case CellType.Ship:
                    picture = Image.FromFile("Ship.jpg");
                    break;
            }
            return picture;
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyEventArgs e)
        {

            Side side = Side.Down;
            switch (e.KeyCode)
            {
                case Keys.Up:
                    side = Side.Up;
                    break;
                case Keys.Down:
                    side = Side.Down;
                    break;
                case Keys.Right:
                    side = Side.Right;
                    break;
                case Keys.Left:
                    side = Side.Left;
                    break;
            }
            EndTurnInfo result = game.Move(new TurnInfo(NextPlayer(player), side));
            PrintMap(result.ChangedCells);
            SetGameInfo(result.CharInform);

        }

        private void PrintMap(List<Cell> list)
        {
            foreach (var item in list)
            {
                dataGridView1[item.XCoord, item.YCoord].Value = DrawCell(item);
            }
        }

        private void SetGameInfo(CharInfo[] charInfo)
        {
            player1Death.Text = charInfo[0].Death.ToString();
            player1Gold.Text = charInfo[0].Gold.ToString();
            if (charInfo[0].WithGold)
            {
                player1GoldContain.Text = "Да";
            }
            else
            {
                player1GoldContain.Text = "Нет";
            }
            if (groupBox3.Visible)
            {
                player2Death.Text = charInfo[1].Death.ToString();
                player2Gold.Text = charInfo[1].Gold.ToString();
                if (charInfo[1].WithGold)
                {
                    player2GoldContain.Text = "Да";
                }
                else
                {
                    player2GoldContain.Text = "Нет";
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            ((DataGridView)sender).ClearSelection();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
