import { Address } from "./address";
import { Amenity } from "./amenity";
import { ApartmentImageResponse } from "./apartmentImageResponse";

export interface Apartment {
    id: any,
    name: string,
    description: string,
    address: Address,
    apartmentImage: ApartmentImageResponse[],
    imageUrl : string,
    price: number,
    cleaningFee: number,
    lastBookedOnUtc: Date,
    amenities : Amenity[]
}
