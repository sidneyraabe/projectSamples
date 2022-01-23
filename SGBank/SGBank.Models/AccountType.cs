namespace SGBank.Models
{
    public enum AccountType
    {
        Free = 1,
        Basic,
        Premium
    }

    /*
    Free Account
        Cannot deposit or withdraw more than $100 at a time
        Deposits must be a positive number
        Withdrawals must be a negative number
        Cannot overdraft the account

    Basic Account
        Can deposit any positive amount
        Withdrawals must be negative and cannot exceed $500
        Can overdraft up to $100 not including a $10 fee deducted from the balance

    Premium Account
        Can deposit any positive amount
        Withdrawals must be negative with no limit except the overdraft limit
        Can overdraft up to $500 with no fee.
    */
}