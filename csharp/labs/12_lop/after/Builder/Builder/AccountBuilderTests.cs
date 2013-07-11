using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Builder
{
    [TestClass]
    public class AccountBuilderTests
    {
        [TestMethod]
        public void Step1_CanCreateAccount()
        {
            var account = AccountBuilder.DefaultAccount().Build();
            
            Assert.IsNotNull(account);
        }

        [TestMethod]
        public void Step2_AssignsDefaultValues()
        {
            var account = AccountBuilder.DefaultAccount().Build();

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
                                            .WithVipCustomer()
                                            .WithAddress().InLondon().Build()    
                                        .Build();

            Assert.IsTrue(account.Customer.Address.City == "London");
            Assert.IsTrue(account.Customer.Address.Country == "UK");
        }       
    }
}
