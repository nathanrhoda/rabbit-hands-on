using System;

namespace Bank.Sagas
{
    public interface IStartWithdrawalProcessEvent
    {
        string AccountNumber { get; set; }
        double Amount { get; set; }

    }
}