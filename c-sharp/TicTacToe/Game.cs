using System;
using System.Linq;
using System.Collections.Generic;

namespace TicTacToe
{
    public enum Board_Constant
    {
        horizontalTile = 3,
        verticalTile = 3,
        symbolO = 'O',
        symbolX = 'X',
        blank = ' ',
    }
    public static class ExceptionMessage
    {
        public static readonly string EXCEPTION_INVALID_FIRST_PLAYER = "Invalid first player";
        public static readonly string EXCEPTION_INVALID_NEXT_PLAYER = "Invalid next player";
        public static readonly string EXCEPTION_INVALID_POSITION = "Invalid position";
    }
    public class Tile
    {
        public int X {get; set;}
        public int Y {get; set;}
        public char Symbol {get; set;}
    }

    public class Board
    {
       private List<Tile> _plays = new List<Tile>();
       
        public Board()
        {
            for (int i = 0; i < (int)Board_Constant.horizontalTile; i++)
            {
                for (int j = 0; j < (int)Board_Constant.verticalTile; j++)
                {
                    _plays.Add(new Tile{ X = i, Y = j, Symbol = (char)Board_Constant.blank});
                }  
            }       
        }
       public Tile TileAt(int x, int y)
       {
           return _plays.Single(tile => tile.X == x && tile.Y == y);
       }

       public void AddTileAt(char symbol, int x, int y)
       {
            _plays.Single(tile => tile.X == x && tile.Y == y).Symbol = symbol;
       }
    }

    public class Game
    {
        private char _lastSymbol = (char)Board_Constant.blank;
        private Board _board = new Board();
        
        public void Play(char symbol, int x, int y)
        {
            //if first move
            if (_lastSymbol == (char)Board_Constant.blank)
            {
                //first player must be X
                if (symbol == (char)Board_Constant.symbolO)
                {
                    throw new TicTacToeException(ExceptionMessage.EXCEPTION_INVALID_FIRST_PLAYER);
                }
            } 
            //if not first move but player repeated
            else if (symbol == _lastSymbol)
            {
                throw new TicTacToeException(ExceptionMessage.EXCEPTION_INVALID_NEXT_PLAYER);
            }
            //if not first move but play on an already played tile
            else if (_board.TileAt(x, y).Symbol != (char)Board_Constant.blank)
            {
                throw new TicTacToeException(ExceptionMessage.EXCEPTION_INVALID_POSITION);
            }

            // update game state
            _lastSymbol = symbol;
            _board.AddTileAt(symbol, x, y);
        }

        public char Winner()
        {   //if the positions in first row are taken
            if (_board.TileAt(0, 0).Symbol != (char)Board_Constant.blank &&
               _board.TileAt(0, 1).Symbol != (char)Board_Constant.blank &&
               _board.TileAt(0, 2).Symbol != (char)Board_Constant.blank)
               {
                    //if first row is full with same symbol
                    if (_board.TileAt(0, 0).Symbol == 
                        _board.TileAt(0, 1).Symbol &&
                        _board.TileAt(0, 2).Symbol == 
                        _board.TileAt(0, 1).Symbol )
                        {
                            return _board.TileAt(0, 0).Symbol;
                        }
               }
                
             //if the positions in first row are taken
             if(_board.TileAt(1, 0).Symbol != (char)Board_Constant.blank &&
                _board.TileAt(1, 1).Symbol != (char)Board_Constant.blank &&
                _board.TileAt(1, 2).Symbol != (char)Board_Constant.blank)
                {
                    //if middle row is full with same symbol
                    if (_board.TileAt(1, 0).Symbol == 
                        _board.TileAt(1, 1).Symbol &&
                        _board.TileAt(1, 2).Symbol == 
                        _board.TileAt(1, 1).Symbol)
                        {
                            return _board.TileAt(1, 0).Symbol;
                        }
                }

            //if the positions in first row are taken
             if(_board.TileAt(2, 0).Symbol != (char)Board_Constant.blank &&
                _board.TileAt(2, 1).Symbol != (char)Board_Constant.blank &&
                _board.TileAt(2, 2).Symbol != (char)Board_Constant.blank)
                {
                    //if middle row is full with same symbol
                    if (_board.TileAt(2, 0).Symbol == 
                        _board.TileAt(2, 1).Symbol &&
                        _board.TileAt(2, 2).Symbol == 
                        _board.TileAt(2, 1).Symbol)
                        {
                            return _board.TileAt(2, 0).Symbol;
                        }
                }

            return (char)Board_Constant.blank;
        }
    }
}