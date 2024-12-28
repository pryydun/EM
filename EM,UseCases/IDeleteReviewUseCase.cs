using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM_UseCases
{
    public interface IDeleteReviewUseCase
    {
        Task ExecuteAsync(int reviewId);
    }
}
