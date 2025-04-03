import { BookingStatus } from "../Enums/booking-status.enum";

 

export class Booking {
    bookingId?:number;
    userId?: number;
    eventId?: number;
    seatNumbers?: number[];
    bookingDate?: Date;
    bookingStatus?: BookingStatus;
}
export { BookingStatus };

