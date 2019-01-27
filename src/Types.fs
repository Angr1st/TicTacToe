module App.Types

open Global

type Msg =
  | TicTacToeMsg of TicTacToe.Types.Msg
  | HomeMsg of Home.Types.Msg

type Model = {
    currentPage: Page
    tictactoe: TicTacToe.Types.Model
    home: Home.Types.Model
  }
