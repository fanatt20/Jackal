using System;
using System.Collections.Generic;
using System.Linq;

namespace JackalEngine
{
    class Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        protected Point()
        {
            throw new NotImplementedException();
        }

        public bool MoveBySide(Side side)
        {
            if ((side == Side.Down && Y > (JackalEngine.Map.YSize - 2)) ||
                    (side == Side.Up && Y < 1) ||
                    (side == Side.Right && X > (JackalEngine.Map.XSize - 2)) ||
                    (side == Side.Left && X < 1))
                return false;
            switch (side)
            {
                case Side.Down:
                    Y += 1;
                    break;
                case Side.Up:
                    Y -= 1;
                    break;
                case Side.Left:
                    X -= 1;
                    break;
                case Side.Right:
                    X += 1;
                    break;
                default:
                    throw new NotImplementedException("sry");
            }
            return true;
        }
        public bool OpositeMove(Side side)
        {
            if ((side == Side.Down && Y < 1) ||
                (side == Side.Up && Y > (JackalEngine.Map.YSize - 2)) ||
                (side == Side.Right && X < 1) ||
                (side == Side.Left && X > (JackalEngine.Map.XSize - 2)))
                return false;
            switch (side)
            {
                case Side.Down:
                    Y -= 1;
                    break;
                case Side.Up:
                    Y += 1;
                    break;
                case Side.Left:
                    X += 1;
                    break;
                case Side.Right:
                    X -= 1;
                    break;
                default:
                    throw new NotImplementedException("sry");
            }
            return true;
        }
    }
    public class Game
    {

        private readonly List<Ship> _ships = new List<Ship>();
        private readonly Map _map = new Map();
        private int _goldMapCapacity = 17;

        public Game(int charNumber)
        {
            switch (charNumber)
            {
                case 1:
                    _ships.Add(new Ship(JackalEngine.Map.XSize / 2, 0));
                    _map[JackalEngine.Map.XSize / 2, 0] = new Cell(CellType.Character1);
                    break;
                case 2:
                    _ships.Add(new Ship(JackalEngine.Map.XSize / 2, 0));
                    _ships.Add(new Ship(JackalEngine.Map.XSize / 2, JackalEngine.Map.YSize - 1));
                    _map[JackalEngine.Map.XSize / 2, 0] = new Cell(CellType.Character1);
                    _map[JackalEngine.Map.XSize / 2, JackalEngine.Map.YSize - 1] = new Cell(CellType.Character2);
                    break;
                case 3:
                    _ships.Add(new Ship(JackalEngine.Map.XSize / 2, 0));
                    _ships.Add(new Ship(JackalEngine.Map.XSize / 2, JackalEngine.Map.YSize - 1));
                    _ships.Add(new Ship(0, JackalEngine.Map.YSize / 2));
                    _map[JackalEngine.Map.XSize / 2, 0] = new Cell(CellType.Character1);
                    _map[JackalEngine.Map.XSize / 2, JackalEngine.Map.YSize - 1] = new Cell(CellType.Character2);
                    _map[0, JackalEngine.Map.YSize / 2] = new Cell(CellType.Character3);
                    break;
                case 4:
                    _ships.Add(new Ship(JackalEngine.Map.XSize / 2, 0));
                    _ships.Add(new Ship(JackalEngine.Map.XSize / 2, JackalEngine.Map.YSize - 1));
                    _ships.Add(new Ship(0, JackalEngine.Map.YSize / 2));
                    _ships.Add(new Ship(JackalEngine.Map.XSize - 1, JackalEngine.Map.YSize / 2));
                    _map[JackalEngine.Map.XSize / 2, 0] = new Cell(CellType.Character1);
                    _map[JackalEngine.Map.XSize / 2, JackalEngine.Map.YSize - 1] = new Cell(CellType.Character2);
                    _map[0, JackalEngine.Map.YSize / 2] = new Cell(CellType.Character3);
                    _map[JackalEngine.Map.XSize - 1, JackalEngine.Map.YSize / 2] = new Cell(CellType.Character3);
                    break;
                default: throw new NotSupportedException();
            }
        }

        public Map Map
        {
            get { return _map; }
        }

        private void CheckActionsOnThatCell(Character ch, Point futureCoordinates)
        {
            int x = futureCoordinates.X, y = futureCoordinates.Y;
            if (_map[x, y].Type == CellType.Hidden) 
                GenerateCell(x, y);
            if (_map[x, y].Type == CellType.WithGold)
            {
                if (!ch.WithGold)
                {
                    ch.WithGold = true;
                    _map[x, y] = new Cell(CellType.Empty);
                }
                return;
            }
            if (_map[x, y].Type == CellType.Ship && ch.WithGold)
            {
                ch.WithGold = false;
                ch.TakeGold();
                return;
            }

            if (_map[x, y].Type == CellType.Character1 || _map[x, y].Type == CellType.Character2)
            {
                var enemy= _ships.Select(ship => ship.Crew[0]).First(cah => cah.X == x && cah.Y == y);
                _ships.Select(ship=>ship).First(ship=>ship.Crew.Contains(enemy)).KillCharacter(enemy);
                _map[x, y] = enemy.CurrentCell;
                enemy.CurrentCell=new Cell(CellType.Ship);

            }

        }


        private bool CanMoveInThatCell(Point ch)
        {
            if (_map[ch.X, ch.Y].Type == CellType.Water)
                return false;

            return true;
        }

        private void RestoreCell(Side side, Character ch)
        {
            _map[ch.X, ch.Y] = ch.CurrentCell;
        }

        private void SaveFutureCell(Character ch, Point futurePoint)
        {
            ch.CurrentCell = _map[futurePoint.X, futurePoint.Y];
        }

        private void GenerateCell(int x, int y)
        {
            var rnd = new Random();
            if (rnd.Next(6) == 0 && _goldMapCapacity > 0)
            {
                _goldMapCapacity--;
                _map[x, y] = new Cell(CellType.WithGold);
            }
            else
            {
                _map[x, y] = new Cell(CellType.Empty);
            }
        }

        private void SetCharacterOnMap(int x, int y, int charId)
        {
            CellType cellTypEnum;
            Enum.TryParse("Character" + (charId + 1).ToString(), false, out cellTypEnum);
            _map[x, y] = new Cell(cellTypEnum);

        }

        public EndTurnInfo Move(TurnInfo info)
        {
            if (info.CharacterId >= _ships.Count)
                throw new ArgumentOutOfRangeException(string.Format("No Character with ID={0}", info.CharacterId));
            var ch = _ships[info.CharacterId].Crew[0];
            var characterPoint = ch.GetPoint();
            if (!characterPoint.MoveBySide(info.MovingSide))
                return new EndTurnInfo(_map.ChangedCells(true),
                    _ships.Select(ship => ship.Crew[0].GetCharInfo()).ToArray());
            if (!CanMoveInThatCell(characterPoint))
            {
                characterPoint.OpositeMove(info.MovingSide);
            }
            else
            {
                RestoreCell(info.MovingSide, ch);
                CheckActionsOnThatCell(ch, characterPoint);
                SaveFutureCell(ch,characterPoint);
                SetCharacterOnMap(characterPoint.X, characterPoint.Y, info.CharacterId);
                ch.ApplyPoint(characterPoint);
            }
            return new EndTurnInfo(_map.ChangedCells(true), _ships.Select(ship => ship.Crew[0].GetCharInfo()).ToArray());
        }
    }
}