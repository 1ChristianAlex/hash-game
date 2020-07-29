import axios, { AxiosInstance } from 'axios';

export class Adapter {
  public Request: AxiosInstance = axios.create({
    baseURL: 'http://localhost:5000',
  });
}
