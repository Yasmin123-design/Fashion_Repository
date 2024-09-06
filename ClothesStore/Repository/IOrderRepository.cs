using ClothesStore.Migrations;
using ClothesStore.Models;

namespace ClothesStore.Repository
{
    public interface IOrderRepository
    {
        public void CreateOrder(Order order);
    }
}
