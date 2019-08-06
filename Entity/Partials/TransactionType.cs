namespace Entity.Partials
{
    public enum TransactionType : short
    {
        //odd for credit, even for debit
        BlockchainReceived = 1,
        BlockchainSend = 2,
        InternalReceived = 3,
        InternalSend = 4,
        Deposit = 5,
        Withdraw = 6,
        BidTradeCredit = 7,
        BidOrderDebit = 8,
        AskTradeCredit = 9,
        AskOrderDebit = 10
    }
}
