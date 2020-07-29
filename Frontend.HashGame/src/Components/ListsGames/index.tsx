import React from 'react';
import { Row, Col, ListGroup } from 'react-bootstrap';
import { GamePlayer } from '../../interfaces';
import { statusGame } from '../../config/constans';
import { useHistory } from 'react-router-dom';
// import { Container } from './styles';

interface IListGames {
  gamesList: GamePlayer[];
}

const ListsGames: React.FC<IListGames> = ({ gamesList }) => {
  const history = useHistory();

  const joinGame = (id: string) => {
    history.push(`${id}/join`);
  };

  return (
    <Row>
      <Col md={12}>
        <ListGroup>
          {gamesList.map((game, index) => {
            return (
              <ListGroup.Item
                action
                key={game.id}
                onClick={() => {
                  joinGame(game.id!);
                }}
              >
                Partida {index} - {statusGame[game.status!]}{' '}
              </ListGroup.Item>
            );
          })}
        </ListGroup>
      </Col>
    </Row>
  );
};

export default ListsGames;
