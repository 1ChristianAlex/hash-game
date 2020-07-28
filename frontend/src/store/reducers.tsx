import {
  UPDATE_GAME,
  CREATE_GAME,
  UPDATE_PLAYER,
  UPDATE_PLAYERX,
  UPDATE_PLAYERY,
} from './types';
import { IGame, IAction, IPlayer } from '../interfaces';

const gameReducer = (state: IGame, action: IAction) => {
  switch (action.type) {
    case UPDATE_GAME:
      return {
        ...state,
        ...action.payload,
      };
    case CREATE_GAME:
      return {};

    default:
      return state;
  }
};

const playerReducer = (state: IPlayer, action: IAction) => {
  switch (action.type) {
    case UPDATE_PLAYER:
      return {
        ...state,
        ...action.payload,
      };
    case UPDATE_PLAYERX:
      return {};

    case UPDATE_PLAYERY:
      return {};

    default:
      return state;
  }
};

export { gameReducer, playerReducer };
