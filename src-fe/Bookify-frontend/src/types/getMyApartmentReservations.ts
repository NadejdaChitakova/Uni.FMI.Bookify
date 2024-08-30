import { ApartmentReservation } from "./apartmentReservation";

export interface GetMyApartmentReservations{
  apartmentId: string,
  apartmentName: string,
  entireProfit: number,
  reservations: ApartmentReservation[]
}
