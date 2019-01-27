module Global

type Page =
  | Home
  | TicTacToe
  | About

let toHash page =
  match page with
  | About -> "#about"
  | TicTacToe -> "#tictactoe"
  | Home -> "#home"
