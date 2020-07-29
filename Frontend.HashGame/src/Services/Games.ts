import { Adapter } from './Adapter';
import { GamePlayer, IPlayer } from '../Interfaces';

export class GameService extends Adapter {
  public async getAllGames(): Promise<GamePlayer[]> {
    const games = await this.Request.get<GamePlayer[]>('/HashGame');
    return games.data.sort(
      (prev, next) =>
        new Date(prev.createDate!).getTime() +
        new Date(next.createDate!).getTime()
    );
  }

  public async createNewGame(): Promise<GamePlayer[]> {
    await this.Request.post<GamePlayer>('/HashGame', {});
    return this.getAllGames();
  }

  public async joinGame(id: string): Promise<IPlayer> {
    const games = await this.Request.post<IPlayer>(`/HashGame/${id}/join`, {});
    return games.data;
  }

  public async unJoinGame(player: IPlayer): Promise<IPlayer> {
    const games = await this.Request.post<IPlayer>(`/HashGame/unjoin`, player);
    return games.data;
  }

  public async getGameById(id: string): Promise<GamePlayer> {
    const games = await this.Request.get<GamePlayer>(`/HashGame/game/${id}`);
    const data = games.data;
    if (data.gameState) {
      data.gameState = JSON.parse(data.gameState);
    }
    return data;
  }
  public async movePlayer(player: IPlayer): Promise<IPlayer> {
    const games = await this.Request.post<IPlayer>(
      `/HashGame/moviment`,
      player
    );
    return games.data;
  }
}
