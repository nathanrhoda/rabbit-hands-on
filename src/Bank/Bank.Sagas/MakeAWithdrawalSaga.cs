using Automatonymous;
using System;

namespace Bank.Sagas
{
    public class MakeAWithdrawalSaga : MassTransitStateMachine<WithdrawalStateData>
    {
        public State GetBalance { get; set; }

        public State ProcessWithdrawal { get; set; }

        public Event<IStartGetBalanceEvent> StartGetBalanceEvent { get; set; }
        public Event<IStartWithdrawalProcessEvent> StartWithdrawalProcessEvent { get; set; }
    }
}
