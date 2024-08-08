namespace BankingControlPanel.Infrastructure.Persistence.Sql.Common
{
    public static class DefaultUserPasswords
    {
        //"Admin@123": $2b$12$ARv87t3BF1.UzLXXG7fAouuGahAluykDmSChkm5RYejuKQmWSC3sK
        public const string AdminPasswordHash = "$2b$12$ARv87t3BF1.UzLXXG7fAouuGahAluykDmSChkm5RYejuKQmWSC3sK";

        //"User@123": $2b$12$uUGDkynQvsESZf4pG1zPE..CWexqYEE1tOUM2MTS4Rr2XLA6UC./u
        public const string UserPasswordHash = "$2b$12$uUGDkynQvsESZf4pG1zPE..CWexqYEE1tOUM2MTS4Rr2XLA6UC./u";
    }
}