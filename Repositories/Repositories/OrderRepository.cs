﻿using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly AppDbContext _dbContext;

        public OrderRepository(AppDbContext dbContext, IClaimsService claimsService) : base(dbContext, claimsService)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CheckBuyProductAlready(Guid accountId, Guid productId)
        {
            var checkBuy = await _dbContext.OrderCartItems
                                           .Include(_ => _.ProductSize)
                                           .Include(_ => _.Order.Payment)
                                           .Where(_ => _.ProductSize.ProductID == productId && _.Order.AccountID == accountId && _.OrderStatus == Enums.OrderStatus.Shipped && _.Order.Payment.PaymentStatus == Enums.PaymentStatus.Completed)
                                           .FirstOrDefaultAsync();

            return checkBuy != null;
        }
    }
}
