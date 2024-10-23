using Repositories.Models.CartItemModels;
using Services.Common;
using Services.Models.CartItemModels;
using Services.Models.CartModels;
using Services.Models.FeedBackModels;
using Services.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IFeedBackService
    {
        Task<ResponseModel> Create(FeedBackCreateModel feedBackCreateModel);
        Task<Pagination<GetFeedBacksModel>> GetFeedBacks(FeedBackFilterModel feedBackFilterModel);

    }
}
