import { useContext } from 'react';
import { StoreContext } from '../Store';

const useGame = () => {
  const context = useContext(StoreContext);

  return context.game;
};

const usePlayer = () => {
  const context = useContext(StoreContext);

  return context.player;
};
const useGameState = () => {
  const context = useContext(StoreContext);

  return context.positions;
};

export { useGame, usePlayer, useGameState };
