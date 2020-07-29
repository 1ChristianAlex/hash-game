export interface Game {
  id?: string;
  currentTurn?: string;
  gameState?: string;
  createDate?: Date;
  status?: statusGameEnum;
}
export enum statusGameEnum {
  EmAndamento = 1,
  Empate,
  VencedorY,
  VencedorX,
}
