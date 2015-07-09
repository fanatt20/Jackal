using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using JackalEngine;
using WinFormUI.Properties;

namespace WinFormUI
{
    public partial class PlayGroundWithImages : Form
    {
        private readonly Game _game;
        private readonly int _totalPlayers;
        private int _player;

        public PlayGroundWithImages(int numberOfPlayers)
        {
            _game = new Game(numberOfPlayers);
            _totalPlayers = numberOfPlayers;
            InitializeComponent();
            if (numberOfPlayers < 2)
                groupBox3.Visible = false;

            for (var i = 0; i < _game.Map.XSize; i++)
            {
                var clmn = new DataGridViewImageColumn();
                dataGridView1.Columns.Add(clmn);
            }
            dataGridView1.Rows.Add(_game.Map.YSize);
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

        private void PrintMap(GameMap map)
        {
            for (var i = 0; i < GameMap._ySize; i++)
            {
                for (var j = 0; j < GameMap._xSize; j++)
                {
                    dataGridView1[i, j].Value = DrawCell(map[i, j]);
                }
            }
        }

        private static Image DrawCell(Cell cell)
        {
            Image picture = Resources.Empty;
            switch (cell.Type)
            {
                case CellType.Hidden:
                    picture = Resources.Smoke;
                    break;
                case CellType.Water:
                    picture = Resources.Water;
                    break;
                case CellType.WithGold:
                    picture = Resources.Gold;
                    break;
                case CellType.Character1:
                    picture = Resources.Pirate1;
                    break;
                case CellType.Character2:
                    picture = Resources.Pirate2;
                    break;
                case CellType.Ship:
                    picture = Resources.Ship;
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
                dataGridView1[item.XCoord, item.YCoord].Value = DrawCell(item);
            }
        }

        private void SetGameInfo(CharInfo[] charInfo)
        {
            player1Death.Text = charInfo[0].Death.ToString();
            player1Gold.Text = charInfo[0].Gold.ToString();
            player1GoldContain.Text = charInfo[0].WithGold ? Resources.YesString : Resources.NoString;

            if (!groupBox3.Visible) return;
            player2Death.Text = charInfo[1].Death.ToString();
            player2Gold.Text = charInfo[1].Gold.ToString();
            player2GoldContain.Text = charInfo[1].WithGold ? Resources.YesString : Resources.NoString;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            ((DataGridView) sender).ClearSelection();
        }
    }
}