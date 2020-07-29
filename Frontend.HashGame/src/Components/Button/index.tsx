import React from 'react';
import { ButtonHashGame } from './styles';

interface IButton {
  onClick?(event: React.MouseEvent<HTMLButtonElement, MouseEvent>): void;
}

const Button: React.FC<IButton> = ({ children, onClick }) => {
  return <ButtonHashGame onClick={onClick}>{children}</ButtonHashGame>;
};

export default Button;
