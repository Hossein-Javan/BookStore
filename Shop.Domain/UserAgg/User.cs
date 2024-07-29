﻿using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.UserAgg.Enums;
using Shop.Domain.UserAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shop.Domain.UserAgg
{
    public class User : AggregateRoot
    {
        public User(string name, string family, string email, string phoneNumber, string password, 
            Gender gender, IDomainUserService domainService)
        {
            Guard(email, phoneNumber, domainService);
            Name = name;
            Family = family;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
            Gender = gender;

        }

        public string Name { get; private set; }
        public string Family { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Password { get; private set; }
        public Gender Gender { get; private set; }
        public List<UserRole> Roles { get; private set; }
        public List<Wallet> Wallets { get; private set; }
        public List<UserAddress> Addresses { get; private set; }

        public static User RegisterUser(string email , string phoneNumber , string password , IDomainUserService domainService)
        {
            return new User("", "", email, phoneNumber, password, Gender.None, domainService);
        }
        public void Edit(string name, string family, string email, string phoneNumber, Gender gender, IDomainUserService domainService)
        {
            Guard(email, phoneNumber , domainService);
            Name = name;
            Family = family;
            Email = email;
            PhoneNumber = phoneNumber;
            Gender = gender;
        }

        public void AddAddress(UserAddress address)
        {
            address.UserId = Id;
            Addresses.Add(address);
        }
        public void EditAddress(UserAddress address)
        {
            var oldAddress = Addresses.FirstOrDefault(f => f.Id == address.Id);
            if (oldAddress == null)
                throw new NullOrEmptyDomainDataException("Address Not Found");
            Addresses.Remove(oldAddress);
            Addresses.Add(address);
        }
        public void DeleteAddress(long addressId)
        {
            var address = Addresses.FirstOrDefault(f => f.Id == addressId);
            if (address == null)
                throw new NullOrEmptyDomainDataException("Address Not Found");
            Addresses.Remove(address);
        }

        public void ChargeWallet(Wallet wallet)
        {
            wallet.UserId = Id;
            Wallets.Add(wallet);
        }
        public void SetRoles(List<UserRole> roles)
        {
            roles.ForEach(f => f.UserId = Id);
            Roles.Clear();
            Roles.AddRange(roles);
        }

        public void Guard(string email, string phoneNumber , IDomainUserService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));
            NullOrEmptyDomainDataException.CheckString(email, nameof(email));
            if (phoneNumber.Length != 11)
                throw new InvalidDomainDataException("Phone Number must be have 11 Character");
            if(email.IsValidEmail()==false)
                throw new InvalidDomainDataException("Email Address Not Approved");

            if (phoneNumber != PhoneNumber)
                if(domainService.IsPhoneNumberExist(phoneNumber))
                    throw new InvalidDomainDataException("The entired number is duplicated");
            if (email != Email)
                if (domainService.IsEmailExist(email))
                    throw new InvalidDomainDataException("The entired email address is duplicated");

        }
    }

   
}
