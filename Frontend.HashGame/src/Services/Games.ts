import { Adapter } from './Adapter';
import { GamePlayer } from '../Interfaces';

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

  public async joinGame(id: string): Promise<GamePlayer[]> {
    const games = await this.Request.get<GamePlayer[]>(`/HashGame/${id}/join`);
    return games.data;
  }
}
