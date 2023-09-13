using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class BookingRepository : IBookingRepository
    {
        protected readonly ITrybeHotelContext _context;
        public BookingRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        public BookingResponse Add(BookingDtoInsert booking, string email)
        {
            // throw new NotImplementedException();
            var newRoom = _context.Rooms.FirstOrDefault(room => room.RoomId == booking.RoomId);
            var roomUser = _context.Users.FirstOrDefault(user => user.Email == email);
            var hotel = _context.Hotels.FirstOrDefault(findHotel => findHotel.HotelId == newRoom!.HotelId);
            var city = _context.Cities.FirstOrDefault(cit => cit.CityId == hotel!.CityId);

            if (newRoom == null || booking.GuestQuant > newRoom.Capacity)
            {
                return null!;
            }

            var newBook = new Booking
            {
                CheckIn = booking.CheckIn,
                CheckOut = booking.CheckOut,
                GuestQuant = booking.GuestQuant,
                Room = newRoom,
            };

            _context.Bookings.Add(newBook);
            _context.SaveChanges();

            var result = new BookingResponse
            {
                BookingId = newBook.BookingId,
                CheckIn = newBook.CheckIn,
                CheckOut = newBook.CheckOut,
                GuestQuant = newBook.GuestQuant,
                Room = new RoomDto
                {
                    RoomId = newRoom.RoomId,
                    Name = newRoom.Name,
                    Capacity = newRoom.Capacity,
                    Image = newRoom.Image,
                    Hotel = new HotelDto
                    {
                        HotelId = hotel!.HotelId,
                        Name = hotel!.Name,
                        Address = hotel!.Address,
                        CityId = hotel!.CityId,
                        CityName = city!.Name,
                    }
                },
            };

            return result;
        }

        public BookingResponse GetBooking(int bookingId, string email)
        {
            throw new NotImplementedException();
        }

        public Room GetRoomById(int RoomId)
        {
            throw new NotImplementedException();
        }

    }

}