using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Builder
{
    public class AccountBuilder
    {
        private Account _account;

        public AccountBuilder()
        {
            CreateAccount();
        }

        private void CreateAccount()
        {
            _account = new Account();
            _account.Balance = 10;
            _account.Customer = new Customer();
            _account.Customer.Name = "Scott";
            _account.Customer.IsVip = false;
            _account.Customer.Address = new Address();
            _account.Customer.Address.City = "Hagerstown";
            _account.Customer.Address.Country = "USA";
            _account.DueDate = DateTime.Now.AddMonths(1);
        }

        public AddressBuilder WithAddress()
        {
            return new AddressBuilder(this);
        }

        public static AccountBuilder DefaultAccount()
        {
            return new AccountBuilder();
        }

        public AccountBuilder WithLatePaymentStatus()
        {
            _account.DueDate = DateTime.Now.AddMonths(-1);
            return this;
        }

        public AccountBuilder WithVipCustomer()
        {
            _account.Customer.IsVip = true;
            return this;
        }

        public Account Build()
        {
            return _account;
        }

        public class AddressBuilder
        {
            private readonly AccountBuilder _builder;

            public AddressBuilder(AccountBuilder builder)
            {
                _builder = builder;
            }

            public AddressBuilder InLondon()
            {
                _builder._account.Customer.Address.City = "London";
                _builder._account.Customer.Address.Country = "UK";
                return this;
            }

            public AccountBuilder Build()
            {
                return _builder;
            }
        }
    }

    



    [TestClass]
    public class AccountBuilderTests
    {
        [TestMethod]
        public void Step1_CanCreateAccount()
        {
            Account account = AccountBuilder.DefaultAccount()
                                            .Build();                        
            Assert.IsNotNull(account);
        }

        [TestMethod]
        public void Step2_AssignsDefaultValues()
        {
            var account = AccountBuilder.DefaultAccount()
                                        .Build();            

            Assert.IsTrue(account.Balance > 0);
            Assert.IsTrue(account.DueDate > DateTime.Now);
            Assert.IsNotNull(account.Customer.Address.City);
            Assert.IsNotNull(account.Customer.Address.Country);
            Assert.IsFalse(account.Customer.IsVip);
            Assert.IsNotNull(account.Customer.Name);            
        }

        [TestMethod]
        public void Step3_EasyToCreateLateAccount()
        {
            var account = AccountBuilder.DefaultAccount()
                                        .WithLatePaymentStatus()
                                        .Build();

            Assert.IsTrue(account.DueDate < DateTime.Now);
        }

        [TestMethod]
        public void Step4_CanCreateLateAccountWithVipCustomer()
        {
            var account = AccountBuilder.DefaultAccount()
                                            .WithLatePaymentStatus()
                                            .WithVipCustomer()
                                        .Build();

            Assert.IsTrue(account.Customer.IsVip);
        }

        [TestMethod]
        public void Step5_CanCustomizeAddress()
        {
            var account = AccountBuilder.DefaultAccount()
                                            .WithLatePaymentStatus()                                            
                                            .WithAddress().InLondon().Build()
                                            .WithVipCustomer()                                            
                                        .Build();

            Assert.IsTrue(account.Customer.Address.City == "London");
            Assert.IsTrue(account.Customer.Address.Country == "UK");
        }       
    }
}
