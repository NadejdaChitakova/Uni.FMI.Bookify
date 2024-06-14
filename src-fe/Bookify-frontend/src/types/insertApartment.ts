import { Address } from "./address";

export interface InsertApartment{
  Name: string,
  Description: string,
  Price: number,
  CleaningFee: number,
  Address: Address,
  ApartmentPhotosIds: string[]
}
