﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenCart.Actions.User;
using OpenCart.Pages;
using OpenCart.Data.Commons;
using OpenCart.Data.Products;
using OpenCart.Pages.User;
using OpenCart.Pages.AdminPanel;
using OpenCart.Data.Users;

namespace OpenCart
{
    [TestFixture]
    public class LoginTestWithWrongData : TestRunner
    {
        private static readonly object[] UserData =
        {
            new object[] { UserRepository.Get().InvalidUser(), UserRepository.Get().AdminUser(), MessagesRepository.DangerMessage() },
        };

        [Test, TestCaseSource(nameof(UserData))]
        public void VerifyBlockUserByIncorrectPassword(IUser invaliduser, IUser admin, string dangerMessage)
        {
            log.Info("Started VerifyBlockUserByIncorrectPassword() with email  = " + invaliduser.GetEmail());
            Assert.AreEqual(
                Application.Get().LoadHomeActions()
                .GotoLoginAccountActions()
                .UnsuccessfulLogin(invaliduser)
                .UnsuccessfulLogin(invaliduser)
                .UnsuccessfulLogin(invaliduser)
                .UnsuccessfulLogin(invaliduser)
                .UnsuccessfulLogin(invaliduser)
                .UnsuccessfulLogin(invaliduser)
                .GetDangerAlertText(),
                dangerMessage
                );
            log.Info("Finished VerifyBlockUserByIncorrectPassword() with email  = " + invaliduser.GetEmail());

            log.Info("Started unblock user with email  = " + invaliduser.GetEmail());
            Assert.IsTrue(
                Application.Get().LoadAdminActions().GetLoginPage(admin)
                .GetCustomers()
                .GetUnlockCustomer(invaliduser)
                .IsCloseDisplayed()
                );
            isTestSuccess = true;
            log.Info("Finished unblock user with Admin name  = " + invaliduser.GetEmail());
        }
    }
}
