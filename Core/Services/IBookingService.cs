using Core.DTOs;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IBookingService
    {
        Task<bool> AddBookingAsync(string PatientId, AddBookingDto addBookingDto);
        Task<IEnumerable<BookingDto>> GetAllMyBookingsAsync(string userId, int? pageSize, int? skip, int? take, string? search);
        Task<bool> UpdateBookingStatus(int Id, BookingStatus Status);

    }
}
