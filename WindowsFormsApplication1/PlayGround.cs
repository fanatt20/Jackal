using System;
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

    public partial class PlayGround : Form
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
        public PlayGround(int numberOfPlayers)
        {
            this.game = new Game(numberOfPlayers);
            totalPlayers = numberOfPlayers;
            InitializeComponent();
            if (numberOfPlayers < 2)
                groupBox3.Visible = false;
           
            for (int i = 0; i < game.Map.XSize; i++)
            {
                                dataGridView1.Columns.Add(i.ToString(),i.ToString());
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
                    dataGridView1[i, j].Value = DrawCell(map[i, j]).ToString();
                }
            }
        }

        private char DrawCell(Cell cell)
        {
            char picture = '0';
            switch (cell.Type)
            {
                case CellType.Unreached:
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
                 dataGridView1[item.XCoord, item.YCoord].Value = DrawCell(item).ToString();
            }
            
        }

        private void SetGameInfo(CharInfo[] charInfo)
        {
            player1Death.Text = charInfo[0].Death.ToString();
            player1Gold.Text = charInfo[0].Gold.ToString();
            if (groupBox3.Visible)
            {
                player2Death.Text = charInfo[1].Death.ToString();
                player2Gold.Text = charInfo[1].Gold.ToString();
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
