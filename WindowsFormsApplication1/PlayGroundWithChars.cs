using System;
using System.Collections.Generic;
using System.Windows.Forms;
using JackalEngine;

namespace WinFormUI
{
    public partial class PlayGroundWithChars : Form
    {
        private readonly Game _game;
        private readonly int _totalPlayers;
        private int _player;

        public PlayGroundWithChars(int numberOfPlayers)
        {
            _game = new Game(numberOfPlayers);
            _totalPlayers = numberOfPlayers;
            InitializeComponent();
            if (numberOfPlayers < 2)
                groupBox3.Visible = false;

            for (var i = 0; i <Map.XSize; i++)
            {
                dataGridView1.Columns.Add(i.ToString(), i.ToString());
            }
            dataGridView1.Rows.Add(Map.YSize);
            PrintMap(_game.Map);
        }

        private int NextPlayer(int currentPlayerId)
        {
            switch (_totalPlayers)
            {
                case 1:
                    return 0;
                case 2:
                    return _player == 0 ? _player++ : _player--;
                default:
                    return -1;
            }
        }

        private void PrintMap(Map map)
        {
            for (var i = 0; i < Map.YSize; i++)
            {
                for (var j = 0; j < Map.XSize; j++)
                {
                    dataGridView1[i, j].Value = DrawCell(map[i, j]).ToString();
                }
            }
        }

        private static char DrawCell(Cell cell)
        {
            var picture = '0';
            switch (cell.Type)
            {
                case CellType.Hidden:
                    picture = '░';
                    break;
                case CellType.Water:
                    picture = '▒';
                    break;
                case CellType.WithGold:
                    picture = '☼';
                    break;
                case CellType.Empty:
                    picture = ' ';
                    break;
                case CellType.Character1:
                    picture = '☺';
                    break;
                case CellType.Character2:
                    picture = '☻';
                    break;
                case CellType.Ship:
                    picture = '⌂';
                    break;
            }
            return picture;
        }

        private void Form1_KeyPress(object sender, KeyEventArgs e)
        {
            var side = Side.Down;
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
            var result = _game.Move(new TurnInfo(NextPlayer(_player), side));
            PrintMap(result.ChangedCells);
            SetGameInfo(result.CharInform);
        }

        private void PrintMap(List<Cell> list)
        {
            foreach (var item in list)
            {
                dataGridView1[item.XCoord, item.YCoord].Value = DrawCell(item).ToString();
            }
        }

        private void SetGameInfo(CharInfo[] charInfo)
        {
            player1Death.Text = charInfo[0].Death.ToString();
            player1Gold.Text = charInfo[0].Gold.ToString();
            if (!groupBox3.Visible) return;
            player2Death.Text = charInfo[1].Death.ToString();
            player2Gold.Text = charInfo[1].Gold.ToString();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            ((DataGridView) sender).ClearSelection();
        }
    }
}