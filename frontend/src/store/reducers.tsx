import { UPDATE_GAME, CREATE_GAME, UPDATE_PLAYER } from './types';
import { IGame, IAction, IPlayer } from '../interfaces';

const gameReducer = (state: IGame, action: IAction<IGame>) => {
  switch (action.type) {
    case UPDATE_GAME:
      return {
        ...state,
        ...action.payload,
      };
    case CREATE_GAME:
      return { ...action.payload };

    default:
      return state;
  }
};

const playerReducer = (state: IPlayer, action: IAction<IPlayer>) => {
  switch (action.type) {
    case UPDATE_PLAYER:
      return {
        ...state,
        ...action.payload,
      };
    default:
      return state;
  }
};

export { gameReducer, playerReducer };
