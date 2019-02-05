import { VoteModel } from "./VoteModel";

export class ElectionModel {

  ElectionDate: Date;

  Votes: Array<VoteModel>;

  Status: number;

  WinnerRestaurantId: string;

  WinnerRestaurantName: string;

  Closed: boolean;

  constructor() { }
}
