import React, { useMemo, useState } from 'react';
import { Container, Row, Col } from 'react-bootstrap';
import { Button, ListsGames, ModalConfirm } from '../Components';
import { GameService } from '../Services';
import { GamePlayer } from '../interfaces';
// import { Container } from './styles';

const ListGamesPage: React.FC = () => {
  const [gamesList, setGameList] = useState<GamePlayer[]>([]);
  const [togle, setTogle] = useState(false);

  useMemo(() => {
    const gameService = new GameService();
    gameService
      .getAllGames()
      .then((gameListResponse) => setGameList(gameListResponse));
  }, []);

  const createGame = () => {
    const gameService = new GameService();
    gameService.createNewGame().then((gameListResponse) => {
      setGameList(gameListResponse);
      setTogle(!togle);
    });
  };

  return (
    <Container>
      <Row className="my-5">
        <Col md={10}>
          <ListsGames gamesList={gamesList} />
        </Col>
        <Col>
          <Button onClick={createGame}>Novo Jogo!</Button>
        </Col>
      </Row>
      <ModalConfirm
        togle={togle}
        setTogle={() => setTogle(!togle)}
        textHeader={'Jogo Criado com sucesso'}
      >
        Novo Jogo Criado
      </ModalConfirm>
    </Container>
  );
};

export default ListGamesPage;
