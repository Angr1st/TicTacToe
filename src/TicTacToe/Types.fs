module TicTacToe.Types
open System.Net
open System.Drawing

type Clicker =
  | Human
  | Computer
  | Nobody

type Button =
  {
    Position: Point;
    ClickedBy: Clicker
  }

type Board =
  {
    Buttons: Button list
  }

type Turn =
  {
    Number:int;
    ClickedBy:Clicker;
    ClickedButton:Button
  }

type Model = {GameBoard:Board; CurrentTurn:Turn}

type Msg =
  | PlayersTurn of Turn
  | ComputerTurn of Turn
  | Reset
