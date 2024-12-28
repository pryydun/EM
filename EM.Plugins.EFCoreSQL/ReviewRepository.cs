using EM.CoreBusiness;
using EM.Plugins.EFCoreSQL;
using EM_UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Plugins.EFCoreSQLServer
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly IDbContextFactory<EMContext> _contextFactory;

        public ReviewRepository(IDbContextFactory<EMContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task AddReviewAsync(Review review)
        {
            using var db = _contextFactory.CreateDbContext();
            db.Reviews.Add(review);
            await db.SaveChangesAsync();
        }

        public async Task<List<Review>> GetReviewsByEventIdAsync(int eventId)
        {
            using var db = _contextFactory.CreateDbContext();
            return await db.Reviews
                .Where(r => r.EventId == eventId)
                .ToListAsync();
        }
        public async Task DeleteAsync(int reviewId)
        {
            using var db = _contextFactory.CreateDbContext();
            var review = await db.Reviews.FindAsync(reviewId);
            if (review != null)
            {
                db.Reviews.Remove(review);
                await db.SaveChangesAsync();
            }
        }
    }
}
