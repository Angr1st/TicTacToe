module TicTacToe.Types
open System.Net
open Aether

type Clicker =
  | Human
  | Computer
  | Nobody

type Point =
  {
    X:int;
    Y:int;
  }

  static member X_ =
    ((fun a -> a.X), (fun b a -> {a with X = b}))

  static member Y_ =
    ((fun a -> a.Y), (fun b a -> {a with Y = b}))

type Button =
  {
    Position: Point;
    ClickedBy: Clicker
  }

  static member ComparePosition (first:Point) (second:Point) =
     (first.X = second.X && first.Y = second.Y)

  static member Position_ =
    ((fun a -> a.Position), (fun b a -> {a with Position = b}))

  static member ClickedBy_ =
    ((fun a -> a.ClickedBy), (fun b a -> {a with ClickedBy = b}))

type Board =
  {
    Buttons: Button list
  }

  static member Buttons_ =
    ((fun a -> a.Buttons), (fun b a -> {a with Buttons = b}))

type Turn =
  {
    Number:int;
    ClickedBy:Clicker;
    ClickedButton:Button option;
    WonBy:Clicker option
  }

  static member Number_ =
    ((fun a -> a.Number), (fun b a -> {a with Number = b}))

  static member ClickedBy_ =
    ((fun a -> a.ClickedBy), (fun b a -> {a with Turn.ClickedBy = b}))

  static member ClickedButton_ =
    (fun a -> a.ClickedButton),
    (fun b a ->
      match a with
      | a when a.ClickedButton.IsSome -> {a with ClickedButton = Some b}
      | a -> a)

  static member WonBy_ =
  (fun a -> a.WonBy),
  (fun b a ->
    match a with
    | a when a.WonBy.IsSome -> {a with WonBy = Some b}
    | a -> a)

type HighScore =
  {
    Player:int;
    Computer:int;
  }

  static member Player_ =
    ((fun a -> a.Player), (fun b a -> {a with Player = b}))

  static member Computer_ =
    ((fun a -> a.Computer), (fun b a -> {a with Computer = b}))


type Model =
  {GameBoard:Board; CurrentTurn:Turn;Scoreboard:HighScore}

  static member GameBoard_ =
    ((fun a -> a.GameBoard), (fun b a -> {a with GameBoard = b}))

  static member CurrentTurn_ =
    ((fun a -> a.CurrentTurn), (fun b a -> {a with CurrentTurn = b}))

  static member Scoreboard_ =
    ((fun a -> a.Scoreboard), (fun b a -> {a with Scoreboard = b}))

type Msg =
  | PlayerTurn of Turn
  | Reset
