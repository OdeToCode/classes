using System;

namespace Builder
{
    public class AccountBuilder
    {
        public static AccountBuilder DefaultAccount()
        {
            return new AccountBuilder();                
        }

        public AccountBuilder()
        {
            _account = new Account
                           {
                               Balance = 10000,
                               DueDate = DateTime.Now.AddDays(1),
                               Customer = new Customer
                                              {
                                                  Name = "Michele",
                                                  Address = new Address
                                                                {
                                                                    City = "Washington D.C.",
                                                                    Country = "USA"
                                                                }
                                              }
                           };
        }

        public AccountBuilder WithLatePaymentStatus()
        {
            _account.DueDate = DateTime.Now.AddDays(-1);
            return this;
        }

        public AccountBuilder WithVipCustomer()
        {
            _account.Customer.IsVip = true;
            return this;
        }

        public AddressBuilder WithAddress()
        {
            return new AddressBuilder(this);
        }

        public Account Build()
        {
            return _account;
        }

        private Account _account;

        public class AddressBuilder
        {
            public AddressBuilder(AccountBuilder accountBuilder)
            {
                _accountBuilder = accountBuilder;                
            }

            public AddressBuilder InLondon()
            {
                _accountBuilder._account.Customer.Address.City = "London";
                _accountBuilder._account.Customer.Address.Country = "UK";
                return this;
            }

            public AccountBuilder Build()
            {
                return _accountBuilder;
            }

            private readonly AccountBuilder _accountBuilder;
        }
    }
}