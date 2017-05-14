using System;

namespace ChessGame
{

    #region ChessPiece Class
    public class ChessPiece
    {
        private int id;
        private PieceName name;
        private PieceColor color;

        #region Enums
        public enum PieceName
        {
            pawn = 1,
            knight = 2,
            bishop = 3,
            rook = 4,
            queen = 5,
            king = 6
        }

        public enum PieceColor
        {
            black = 1,
            white = 2
        }
        #endregion

        #region Properties
        public PieceName Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public PieceColor Color
        {
            get
            {
                return this.color;
            }

            set
            {
                this.color = value;
            }
        }
        #endregion

        #region Constructors
        public ChessPiece( int id, PieceName name, PieceColor color )
        {
            this.id = id;
            this.Name = name;
            this.Color = color;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return "ChessPiece " + name.ToString();
        }
        #endregion

    }
    #endregion

    #region ChessBoard Class
    public class ChessBoard
    {
        private BoardSquare[,] board;
        private int boardSize = 8;

        public enum columns
        {
            a = 0,
            b = 1,
            c = 2,
            d = 3,
            e = 4,
            f = 5,
            g = 6,
            h = 7
        }

        public ChessBoard( )
        {
            board = new BoardSquare[boardSize, boardSize];

            // Running through Board initializing the Squares.
            for (int line = 0; line < boardSize; line++)
            {
                for (int column = 0; column < boardSize; column++)
                {
                    // If both column and line are odd or pair, then square is black, otherwise is white.
                    if ( ( line % 2 == 0 && column % 2 == 0 ) || (line % 2 > 0 && column % 2 > 0) )
                    {
                        board[line, column] = new BoardSquare(BoardSquare.SquareColor.Dark);
                    }
                    else
                    {
                        board[line, column] = new BoardSquare(BoardSquare.SquareColor.White);
                    }
                }
            }
        }

        public void addPiece(ChessPiece piece, columns column, int linha )
        {
            board[linha - 1, int.Parse(column.ToString())].Piece = piece;
        }

        public override string ToString()
        {
            string result = "";

            for(int linha = 0; linha < boardSize; linha++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    result += board[linha, col].ToString() + ", ";
                }
            }

            return result;

        }
    }
    #endregion

    #region BoardSquare Class
    public class BoardSquare
    {
        public SquareColor Color { get; set; }
        public ChessPiece Piece { get; set; }

        public enum SquareColor
        {
            White,
            Dark
        }

        public BoardSquare(SquareColor color )
        {
            Color = color;
            Piece = null;
        }

        public BoardSquare( SquareColor color, ref ChessPiece piece )
        {
            Color = color;
            Piece = piece;
        }

        public bool isEmpty()
        {
            return Piece == null;
        }

        public void clear()
        {
            Piece = null;
        }

        public void flipColor()
        {
            if(Color == SquareColor.Dark)
            {
                Color = SquareColor.White;
            }
            else
            {
                Color = SquareColor.Dark;
            }
        }
    }
    #endregion
}
