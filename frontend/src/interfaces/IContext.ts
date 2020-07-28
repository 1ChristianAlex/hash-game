export interface Action<T = object> {
  type: string;
  payload: T;
}
export interface Dispatch {
  dispatch(action: Action | null): void;
}
