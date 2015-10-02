namespace BalloonsPop.Common.Contracts
{
    public interface IValidationFactory
    {
        IMatrixValidator CreateMatrixValidator();
       
        IUserInputValidator CreateUserInputValidator();
    }
}