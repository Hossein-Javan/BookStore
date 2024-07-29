using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.ProductAgg
{
    public class ProductImage :BaseEntity
    {
        public ProductImage(string imageName, int sequance)
        {
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            ImageName = imageName;
            Sequance = sequance;
        }

        public long ProductId { get; internal set; }
        public string ImageName { get; private set; }
        public int Sequance { get; private set; }
    } 
}
