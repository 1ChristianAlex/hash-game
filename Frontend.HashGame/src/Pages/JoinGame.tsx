import React, { useEffect, useCallback, memo, useState } from 'react';
import { GameService } from '../Services';
import { useParams } from 'react-router-dom';
import { Container, Row, Col, Button } from 'react-bootstrap';
import { FaTimesCircle, FaCircle, FaSyncAlt } from 'react-icons/fa';
import { IPlayer, GamePlayer } from '../interfaces';
import { ModalConfirm } from '../Components';
import { statusGame } from '../config/constans';

// import { Container } from './styles';

const JoinGamePage: React.FC = () => {
  const { id } = useParams();
  const [player, setPlayer] = useState<IPlayer>();
  const [game, setGame] = useState<GamePlayer>();
  const [modalText, setModalText] = useState<string>();
  const [togle, setTogle] = useState<boolean>(false);
  const [load, setLoad] = useState<boolean>(false);
  const [position] = useState<any[][]>([
    Array.from(new Array(3)),
    Array.from(new Array(3)),
    Array.from(new Array(3)),
  ]);

  const getUser = useCallback(() => {
    const gameService = new GameService();
    gameService.joinGame(id).then((player) => {
      setPlayer(player);
    });
    gameService.getGameById(id).then((game) => {
      setGame(game);
    });
  }, [id]);

  useEffect(() => {
    getUser();
  }, [getUser]);

  useEffect(() => {
    return () => {
      if (player?.id) {
        const gameService = new GameService();

        gameService.unJoinGame(player!);
      }
    };
  }, [player]);

  const verifyTurn = () => {
    if (player?.name === game?.currentTurn) {
      return true;
    }
    setModalText('Não é sua vez');
    setTogle(!togle);
    return false;
  };
  const movePlayer = (x: number, y: number) => {
    const gameService = new GameService();
    if (verifyTurn()) {
      gameService
        .movePlayer({
          ...player,
          xPosition: x,
          yPosition: y,
        })
        .then((updatePlayer) => {
          setPlayer(updatePlayer);
          gameService.getGameById(updatePlayer!.gameId!).then((updateGame) => {
            setGame(updateGame);
          });
        });
    }
  };

  useEffect(() => {}, [player]);

  const updateGame = () => {
    const gameService = new GameService();
    setLoad(true);
    gameService.getGameById(game?.id!).then((updateGame) => {
      setGame(updateGame);
      setLoad(false);
    });
  };

  console.log(game);

  return (
    <Container className="w-50 my-5">
      {game?.status && (
        <Row>
          <Col className="text-center">
            <h1>{statusGame[game?.status!]}</h1>
          </Col>
        </Row>
      )}
      <Row className="my-3">
        <Col>
          <h4>Voce é {player?.name}</h4>
        </Col>
        <Col>
          {game?.currentTurn !== player?.name ? (
            <h5>Agora é a vez do {game?.currentTurn}</h5>
          ) : (
            <h5>Agora é sua vez!</h5>
          )}
        </Col>
        <Col>
          {!load && (
            <Button onClick={updateGame}>
              {' '}
              Atualiza Jogo
              <FaSyncAlt className="ml-2" />
            </Button>
          )}
        </Col>
      </Row>
      {position.map((item, xIndex) => {
        return (
          <Row key={xIndex}>
            {item.map((item, yIndex) => (
              <Col
                md={4}
                key={yIndex}
                className="box-hash-game text-center pointer p-5"
                onClick={() => movePlayer(xIndex, yIndex)}
              >
                {Array.isArray(game?.gameState) &&
                  game?.gameState?.map((px: { [key: string]: any }) => {
                    if (
                      px['x'] &&
                      px['x'][0] === xIndex &&
                      px['x'][1] === yIndex
                    ) {
                      return (
                        <FaTimesCircle
                          key={`positon-${yIndex}-${yIndex}`}
                          className="xPlayer-icon"
                        />
                      );
                    }
                    if (
                      px['y'] &&
                      px['y'][0] === xIndex &&
                      px['y'][1] === yIndex
                    ) {
                      return (
                        <FaCircle
                          key={`positon-${yIndex}-${yIndex}`}
                          className="yPlayer-icon"
                        />
                      );
                    }
                  })}
              </Col>
            ))}
          </Row>
        );
      })}
      <ModalConfirm
        togle={togle}
        setTogle={() => setTogle(!togle)}
        textHeader={modalText || ''}
      >
        {modalText}
      </ModalConfirm>
    </Container>
  );
};

export default memo(JoinGamePage);
