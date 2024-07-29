using Common.Domain;

namespace Shop.Domain.OrderAgg
{
    public class OrderAddress:BaseEntity
    {
        public OrderAddress(string state, string city, string postalCode, string postalAddres,
            string phoneNumber, string name, string family, string nationalCode)
        {
            State = state;
            City = city;
            PostalCode = postalCode;
            PostalAddres = postalAddres;
            PhoneNumber = phoneNumber;
            Name = name;
            Family = family;
            NationalCode = nationalCode;
        }

        public long OrderId { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }

        public string PostalCode { get; private set; }

        public string PostalAddres { get; private set; }

        public string PhoneNumber { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string NationalCode { get; private set; }

        public Order Order { get; set; }
    }
}
