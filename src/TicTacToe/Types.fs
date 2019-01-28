module TicTacToe.Types
open System.Net
open System.Drawing
open Aether

type Clicker =
  | Human
  | Computer
  | Nobody

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
    ClickedButton:Button option
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

type Model =
  {GameBoard:Board; CurrentTurn:Turn}

  static member GameBoard_ =
    ((fun a -> a.GameBoard), (fun b a -> {a with GameBoard = b}))

  static member CurrentTurn_ =
    ((fun a -> a.CurrentTurn), (fun b a -> {a with CurrentTurn = b}))

type Msg =
  | PlayerTurn of Turn
  | Reset
