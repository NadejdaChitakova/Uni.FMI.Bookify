export interface UpdateApartmentRequest{
  id: string,
  name: string,
  description: string,
  street: string,
  countryId: string,
  city: string,
  cleaningFee: number,
  price: number,
  amenitiesId: string[],
  images: string[]
}
