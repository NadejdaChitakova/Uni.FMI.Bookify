import { DateRange } from "./dateRange";
import { Paging } from "./Paging";


export interface SearchApartmentRequest{
  searchByLocationOrName : string,
  numberOfGuests: number,
  cityId: string,
  countryId: string,
  duration: any,
  minPrice:any,
  maxPrice:any,
  paging: Paging
}
