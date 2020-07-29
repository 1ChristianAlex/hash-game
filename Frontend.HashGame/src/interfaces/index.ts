import { Game } from './IGame';
import { Player } from './IPlayer';
import { Action, Dispatch } from './IContext';

export interface GamePlayer extends Game {
  players: Player[];
}
export type IGame = Game;
export type IPlayer = Player;
export type IAction<T = object> = Action<T>;
export type IDispatch = Dispatch;
