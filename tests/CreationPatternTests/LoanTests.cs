using LearnRefactoring.CreationPattern;
using Shouldly;

namespace LearnRefactoring.CreationPatternTests
{
    [TestClass]
    public class LoanTests
    {
        [TestMethod]
        public void TestLoanConstructor_WithCommitmentRiskRatingMaturity_Success()
        {
            // Arrange
            double commitment = 1000.0;
            int riskRating = 5;
            DateTime maturity = DateTime.Now.AddYears(1);

            // Act
            var loan = new Loan(commitment, riskRating, maturity);

            // Assert
            commitment.ShouldBe(loan.Commitment);
            riskRating.ShouldBe(loan.RiskRating);
            loan.Maturity.ShouldNotBeNull();
            maturity.ShouldBe(loan.Maturity.Value);
            
        }

        [TestMethod]
        public void TestLoanConstructor_WithCommitmentRiskRatingMaturityExpiry_Success()
        {
            // Arrange
            double commitment = 1000.0;
            int riskRating = 5;
            DateTime maturity = DateTime.Now.AddYears(1);
            DateTime expiry = DateTime.Now.AddYears(2);

            // Act
            var loan = new Loan(commitment, riskRating, maturity, expiry);

            // Assert
            commitment.ShouldBe(loan.Commitment);
            riskRating.ShouldBe(loan.RiskRating);
            loan.Maturity.ShouldNotBeNull();
            maturity.ShouldBe(loan.Maturity.Value);
            loan.Expiry.ShouldNotBeNull();
            expiry.ShouldBe(loan.Expiry.Value);
            
        }

        [TestMethod]
        public void TestLoanConstructor_WithCommitmentOutstandingRiskRatingExpiry_Success()
        {
            // Arrange
            double commitment = 1000.0;
            double outstanding = 500.0;
            int riskRating = 5;
            DateTime expiry = DateTime.Now.AddYears(1);

            // Act
            var loan = new Loan(commitment, outstanding, riskRating, expiry);

            // Assert
            commitment.ShouldBe(loan.Commitment);
            outstanding.ShouldBe(loan.Outstanding);
            riskRating.ShouldBe(loan.RiskRating);
            loan.Expiry.ShouldNotBeNull();
            expiry.ShouldBe(loan.Expiry.Value);
        }

        [TestMethod]
        public void TestLoanConstructor_WithCommitmentOutstandingRiskRatingExpiryMaturity_Success()
        {
            // Arrange
            double commitment = 1000.0;
            double outstanding = 500.0;
            int riskRating = 5;
            DateTime expiry = DateTime.Now.AddYears(1);
            DateTime maturity = DateTime.Now.AddYears(2);

            // Act
            var loan = new Loan(commitment, outstanding, riskRating, expiry, maturity);

            // Assert
            commitment.ShouldBe(loan.Commitment);
            outstanding.ShouldBe(loan.Outstanding);
            riskRating.ShouldBe(loan.RiskRating);
            loan.Maturity.ShouldNotBeNull();
            maturity.ShouldBe(loan.Maturity.Value);
            loan.Expiry.ShouldNotBeNull();
            expiry.ShouldBe(loan.Expiry.Value);
        }

        [TestMethod]
        public void TestLoanConstructor_WithStrategyCommitmentOutstandingRiskRatingExpiryMaturity_Success()
        {
            // Arrange
            var strategy = new MockCapitalStrategy();
            double commitment = 1000.0;
            double outstanding = 500.0;
            int riskRating = 5;
            DateTime expiry = DateTime.Now.AddYears(1);
            DateTime maturity = DateTime.Now.AddYears(2);

            // Act
            var loan = new Loan(strategy, commitment, outstanding, riskRating, expiry, maturity);

            // Assert
            strategy.ShouldBe(loan.CapitalStrategy);
            commitment.ShouldBe(loan.Commitment);
            outstanding.ShouldBe(loan.Outstanding);
            riskRating.ShouldBe(loan.RiskRating);
            loan.Maturity.ShouldNotBeNull();
            maturity.ShouldBe(loan.Maturity.Value);
            loan.Expiry.ShouldNotBeNull();
            expiry.ShouldBe(loan.Expiry.Value);
        }
    }
}