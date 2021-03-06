module TicTacToe.State

open Elmish
open Types
open Aether.Operators
open Aether
open Fable

let initTurn =
  {Number=0; ClickedBy=Clicker.Nobody;ClickedButton=None;WonBy=None}

let initButton x y =
  {
    Position = {X=x;Y=y};
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

let initScoreBoard = {Player=0;Computer=0}

let initModel =
  {GameBoard = initBoard; CurrentTurn = initTurn;Scoreboard = initScoreBoard}

let init () : Model * Cmd<Msg> =
  (initModel, [])

let updateBoard =
  Model.GameBoard_ >-> Board.Buttons_

let update msg model =
  let updateButtons gameBoard button =
    match button with
    | Some b -> gameBoard.Buttons |> List.map (fun x -> if (Button.ComparePosition x.Position b.Position) then b else x)
    | None -> gameBoard.Buttons

  let updateModel (oldModel:Model) (newTurn:Turn) =
    let updateGameBoard =
     Optic.set updateBoard (updateButtons oldModel.GameBoard newTurn.ClickedButton) oldModel

    {updateGameBoard with CurrentTurn = newTurn}

  match msg with
  | PlayerTurn newestTurn ->
      (updateModel model newestTurn, [])
  | Reset ->
      (initModel, [])
