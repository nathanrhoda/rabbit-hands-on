using Automatonymous;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Sagas
{
    public class WithdrawalStateData : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string CurrentState { get; set; }
        public DateTime? WithdrawalCreated { get; set; }
        public DateTime? WithdrawalCompleted { get; set; }

        public string AccountNumber { get; set; }

        public double Amount { get; set; }
    }
}
