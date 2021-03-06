module App.State

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fable.Import.Browser
open Global
open Types

let pageParser: Parser<Page->Page,Page> =
  oneOf [
    map About (s "about")
    map TicTacToe (s "tictactoe")
    map Home (s "home")
  ]

let urlUpdate (result: Option<Page>) model =
  match result with
  | None ->
    console.error("Error parsing url") |> ignore
    (model, Navigation.modifyUrl (toHash model.currentPage))
  | Some page ->
    ({ model with currentPage = page }, [])

let init result =
  let (tictactoe, tictactoeCmd) = TicTacToe.State.init()
  let (home, homeCmd) = Home.State.init()
  let (model, cmd) =
    urlUpdate result
      { currentPage = Home
        tictactoe = tictactoe
        home = home }
  model, Cmd.batch [ cmd
                     Cmd.map TicTacToeMsg tictactoeCmd
                     Cmd.map HomeMsg homeCmd ]

let update msg model =
  match msg with
  | TicTacToeMsg msg ->
      let (tictactoe, tictactoeCmd) = TicTacToe.State.update msg model.tictactoe
      ({ model with tictactoe = tictactoe }, Cmd.map TicTacToeMsg tictactoeCmd)
  | HomeMsg msg ->
      let (home, homeCmd) = Home.State.update msg model.home
      ({ model with home = home }, Cmd.map HomeMsg homeCmd)
