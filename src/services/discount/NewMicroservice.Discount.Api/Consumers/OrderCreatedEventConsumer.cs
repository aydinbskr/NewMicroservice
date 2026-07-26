using MassTransit;
using NewMicroservice.Bus.Events;
using NewMicroservice.Discount.Api.Features.Discounts;
using NewMicroservice.Discount.Api.Repositories;

namespace NewMicroservice.Discount.Api.Consumers
{
    public class OrderCreatedEventConsumer(IServiceProvider serviceProvider) : IConsumer<OrderCreatedEvent>
    {
        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var discount = new Repositories.Discount
                {
                    Id = Guid.CreateVersion7(),
                    Code = DiscountCodeGenerator.Generate(),
                    Created = DateTime.Now,
                    Rate = 0.1f,
                    Expired = DateTime.Now.AddMonths(1),
                    UserId = context.Message.UserId
                };

                await appDbContext.Discounts.AddAsync(discount);

                await appDbContext.SaveChangesAsync();
            }
        }
    }
}
