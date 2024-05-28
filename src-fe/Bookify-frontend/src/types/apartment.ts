import { Address } from "./address";
import { Amenity } from "./amenity";

export interface Apartment {
    id: any,
    name: string,
    description: string,
    address: Address,
    apartmentImages: File[],
    price: number,
    cleaningFee: number,
    lastBookedOnUtc: Date,
    amenities : Amenity[]
}
