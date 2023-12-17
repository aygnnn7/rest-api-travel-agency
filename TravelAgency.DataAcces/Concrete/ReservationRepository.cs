using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAcces.Abstract;
using TravelAgency.Entities.Entities;

namespace TravelAgency.DataAcces.Concrete
{
    public class ReservationRepository : IReservationRepository
    {
        public async Task<long> CreateReservationAsync(Reservation reservation)
        {
            using (AgencyDbContext db = new AgencyDbContext())
            {
                db.Reservations.Add(reservation);
                await db.SaveChangesAsync();
            }
            return reservation.Id;
        }

        public async Task<bool> DeleteReservationAsync(long reservationId)
        {
            var reservation = await GetReservationByIdAsync(reservationId);
            if (reservation != null)
            {
                using (AgencyDbContext db = new AgencyDbContext())
                {
                    db.Reservations.Remove(reservation);
                    await db.SaveChangesAsync();
                }
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Reservation>> GetReservationsAsync()
        {
            using (AgencyDbContext db = new AgencyDbContext())
            {
                return await db.Reservations.ToListAsync();
            }
        }

        public async Task<Reservation> GetReservationByIdAsync(long reservationId)
        {
            using (AgencyDbContext db = new AgencyDbContext())
            {
                return await db.Reservations.FindAsync(reservationId);
            }
        }

        public async Task<bool> UpdateReservationAsync(Reservation reservation)
        {
            var existingReservation = await GetReservationByIdAsync(reservation.Id);
            if (existingReservation != null)
            {
                using (AgencyDbContext db = new AgencyDbContext())
                {
                    db.Reservations.Update(reservation);
                    await db.SaveChangesAsync();
                }
                return true;
            }
            return false;
        }
    }

}
