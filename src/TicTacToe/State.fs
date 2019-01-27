module TicTacToe.State

open Elmish
open Types

let initTurn =
  {Number=0; ClickedBy=Clicker.Nobody;ClickedButton=None}

let initBoard =
  {}

let init () : Model * Cmd<Msg> =
  0, []

let update msg model =
  match msg with
  | Increment ->
      model + 1, []
  | Decrement ->
      model - 1, []
  | Reset ->
      0, []
