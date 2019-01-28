module TicTacToe.State

open Elmish
open Types
open System.Drawing

let initTurn =
  {Number=0; ClickedBy=Clicker.Nobody;ClickedButton=None}

let initButton x y =
  {
    Position = Point(x,y);
    ClickedBy = Clicker.Nobody
  }

let initBoard =
  let getAllPositions amount =
    seq { for i in 1 .. amount do
            for j in 1 .. amount do
              yield (i , j)
        }

  let allPositions = getAllPositions 9

  let newButtons = allPositions |> Seq.map (fun x -> initButton (fst x) (snd x)) |> Seq.toList

  {Buttons = newButtons}

let initModel =
  {GameBoard = initBoard; CurrentTurn = initTurn}

let init () : Model * Cmd<Msg> =
  (initModel, [])

let update msg model =
  match msg with
  | PlayersTurn newestTurn ->
      model + 1, []
  | ComputerTurn newestTurn ->
      model - 1, []
  | Reset ->
      (initModel, [])
