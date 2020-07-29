import { CREATE_GAME, UPDATE_GAME, UPDATE_PLAYER } from './types';
import { IGame, IAction, IPlayer } from '../interfaces';

const createGame = (game: IGame): IAction<IGame> => {
  return {
    type: CREATE_GAME,
    payload: game,
  };
};

const updateGame = (game: IGame): IAction<IGame> => {
  return {
    type: UPDATE_GAME,
    payload: game,
  };
};

const updatePlayer = (player: IPlayer): IAction<IPlayer> => {
  return {
    type: UPDATE_PLAYER,
    payload: player,
  };
};

export { createGame, updateGame, updatePlayer };
