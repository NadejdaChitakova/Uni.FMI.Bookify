import { Paging } from "./Paging";

export interface SearchApartmentRequest{
  searchByLocationOrName : string,
  numberOfGuests: number,
  cityId: string,
  countryId: string,
  fromDate: any,
  endDate:any,
  minPrice:any,
  maxPrice:any,
  paging: Paging
}
