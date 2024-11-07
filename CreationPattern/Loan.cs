namespace LearnRefactoring.CreationPattern
{ 
    public class Loan
    {
        /*
         +Loan(commitment, riskRating, maturity)
           +Loan(commitment, riskRating, maturity, expiry)
           +Loan(commitment, outstanding, riskRating, maturity, expiry)
           +Loan(capitalStrategy, commitment, riskRating, maturity, expiry)
           +Loan(capitalStrategy, commitment, outstanding, riskRating, maturity, expiry)
         
         */
        public Loan(double commitment, int riskRating, DateTime maturity)
            : this(new TermROC(), commitment, 0.00, riskRating, null, maturity) { }

        public Loan(double commitment, int riskRating, DateTime maturity, DateTime expiry)
            : this(new TermROC(), commitment, 0.00, riskRating, expiry, maturity) { }

        public Loan(double commitment, double outstanding, int riskRating, DateTime expiry)
            : this(new TermROC(), commitment, outstanding, riskRating, expiry, null) { }

        public Loan(double commitment, double outstanding, int riskRating, DateTime expiry, DateTime maturity)
            : this(new RevolvingTermROC(), commitment, outstanding, riskRating, expiry, maturity) { }

        public Loan(ICapitalStrategy strategy, double commitment, double outstanding, int riskRating, DateTime? expiry, DateTime? maturity)
        {
            CapitalStrategy = strategy;
            Commitment = commitment;
            Outstanding = outstanding;
            RiskRating = riskRating;
            Expiry = expiry;
            Maturity = maturity;
        }

        public ICapitalStrategy CapitalStrategy { get; }

        public double Commitment { get; }

        public double Outstanding { get; }

        public int RiskRating { get; }

        public DateTime? Expiry { get; }

        public DateTime? Maturity { get; }
    }
}
