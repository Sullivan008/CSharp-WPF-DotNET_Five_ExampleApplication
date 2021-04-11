using System.Linq;
using Application.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.DataAccessLayer.Context
{
    public class ParkingAppReadonlyDbContext
    {
        private readonly ParkingAppDbContext _context;

        public ParkingAppReadonlyDbContext(ParkingAppDbContext context)
        {
            _context = context;
        }

        public IQueryable<ApplicationLog> ApplicationLogs => _context.ApplicationLog.AsNoTracking();

        public IQueryable<Car> Cars => _context.Car.AsNoTracking();

        public IQueryable<Card> Cards => _context.Card.AsNoTracking();

        public IQueryable<ParkingPass> ParkingPasses => _context.ParkingPass.AsNoTracking();

        public IQueryable<LoggedParkingPeriod> LoggedParkingPeriods => _context.LoggedParkingPeriod.AsNoTracking();
    }
}
