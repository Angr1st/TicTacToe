module TicTacToe.View

open Fable.Core
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Aether

let simpleButton txt action dispatch =
  div
    [ ClassName "column is-narrow" ]
    [ a
        [ ClassName "button"
          OnClick (fun _ -> action |> dispatch) ]
        [ str txt ] ]

let root (model:Model) dispatch =
  let getScore model (lens:Lens<HighScore,int>) =
    Optic.get (Compose.lens Model.Scoreboard_ lens) model

  let getScore' = getScore model

  div
    [ ClassName "columns is-vcentered" ]
    [ div [ ClassName "column" ] [ ]
      div
        [ ClassName "column is-narrow"
          Style
            [ CSSProp.Width "170px" ] ]
        [ str (sprintf "Player Wins: %i Computer Wins: %i" (getScore' HighScore.Player_) (getScore' HighScore.Player_)) ]
      //model.
      simpleButton "Reset" Reset dispatch
      div [ ClassName "column" ] [ ] ]
