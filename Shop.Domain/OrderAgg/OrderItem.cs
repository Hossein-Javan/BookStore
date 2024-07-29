using Common.Domain;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.OrderAgg
{
    public class OrderItem :BaseEntity
    {
        public OrderItem(long inventoryId, int price, int count)
        {
            PriceGuard(price);
            CountGuard(count);
            InventoryId = inventoryId;
            this.price = price;
            Count = count;
            
        }

        public long OrderId { get;internal set; }
        public long InventoryId { get; private set; }
        public int price { get; private set; }
        public int Count { get; private set; }
        public int TotalPrice => price * Count;


        public void ChangeCount(int newCount)
        {
            CountGuard(newCount);
            Count = newCount;
        }
        public void SetPrice(int newPrice)
        {
            PriceGuard(newPrice);
            price = newPrice;
        }
        public void PriceGuard(int newPrice)
        {
            if (newPrice < 1)
                throw new InvalidDomainDataException("مبلغ کالا نامعتبر است");
        }  public void CountGuard(int newCount)
        {
            if (newCount < 1)
                throw new InvalidDomainDataException();
        }
        
    }
}
