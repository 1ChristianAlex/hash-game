export interface Action {
  type: string;
  payload: object;
}
export interface Dispatch {
  dispatch(action: Action | null): void;
}
