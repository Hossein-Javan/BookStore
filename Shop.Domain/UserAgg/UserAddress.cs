using Common.Domain;
using Common.Domain.Exceptions;
using System.Xml.Linq;

namespace Shop.Domain.UserAgg
{
    public class UserAddress : BaseEntity
    {
        public UserAddress( string state, string city, string postalCode, string postalAddres, string phoneNumber,
            string name, string family, string nationalCode)
        {
            Guard(state, city, postalCode, postalAddres, phoneNumber,
            name, family, nationalCode);
            State = state;
            City = city;
            PostalCode = postalCode;
            PostalAddres = postalAddres;
            PhoneNumber = phoneNumber;
            Name = name;
            Family = family;
            NationalCode = nationalCode;
            ActiveAddress = false;
        }

        public long UserId { get; internal set; }
        public string State { get; private set; }
        public string City { get; private set; }

        public string PostalCode { get; private set; }

        public string PostalAddres { get; private set; }

        public string PhoneNumber { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string NationalCode { get; private set; }
        public bool ActiveAddress { get; private set; }

        public void Edit(string state, string city, string postalCode, string postalAddres, string phoneNumber,
           string name, string family, string nationalCode)
        {
            Guard( state, city, postalCode, postalAddres,  phoneNumber,
            name,  family,  nationalCode);
            State = state;
            City = city;
            PostalCode = postalCode;
            PostalAddres = postalAddres;
            PhoneNumber = phoneNumber;
            Name = name;
            Family = family;
            NationalCode = nationalCode;
        }
        public void setActive()
        {
            ActiveAddress = true;
        }

        public void Guard(string state, string city, string postalCode, string postalAddres, string phoneNumber,
           string name, string family, string nationalCode)
        {
            NullOrEmptyDomainDataException.CheckString(state, nameof(state));
            NullOrEmptyDomainDataException.CheckString(city, nameof(city));
            NullOrEmptyDomainDataException.CheckString(postalCode, nameof(postalCode));
            NullOrEmptyDomainDataException.CheckString(postalAddres, nameof(postalAddres));
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));
            NullOrEmptyDomainDataException.CheckString(family, nameof(family));
            NullOrEmptyDomainDataException.CheckString(name, nameof(name));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));
            if (IranianNationalIdChecker.IsValid(nationalCode) == false)
                throw new InvalidDomainDataException("کد ملی نامعتبر است");

        }
    }
}
