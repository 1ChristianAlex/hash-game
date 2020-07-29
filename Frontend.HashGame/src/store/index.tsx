import React, { createContext, useReducer } from 'react';
import { IGame, IPlayer, IAction } from '../Interfaces';
import { gameReducer, playerReducer } from './reducers';

interface IStore {
  game?: IGame;
  player?: IPlayer;
  positions?: Map<string, number[]>[] | null;
  dispatch?(action: IAction): void;
}

const defaultContext: IStore = {};
const defaultGame: IGame = {};
const defaultPlayer: IPlayer = {};

const StoreContext = createContext<IStore>(defaultContext);

const Store: React.FC = ({ children }) => {
  const [gameState, setGameState] = useReducer(gameReducer, defaultGame);
  const [playerState, setPlayerReducer] = useReducer(
    playerReducer,
    defaultPlayer
  );

  const combineReducer: IStore = {
    dispatch: (action: IAction) => {
      setGameState(action);
      setPlayerReducer(action);
    },
    game: gameState,
    player: playerState,
    positions: JSON.parse(gameState.gameState || '{}') as Map<
      string,
      number[]
    >[],
  };

  return (
    <StoreContext.Provider value={combineReducer}>
      {children}
    </StoreContext.Provider>
  );
};

export { Store, StoreContext };
