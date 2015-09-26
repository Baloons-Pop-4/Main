using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPop.Validation
{
    using BalloonsPop.Common.Contracts;

    public class ValidationFactory : IValidationFactory
    {
        private static IMatrixValidator matrixValidator = null;
        private static IUserInputValidator userInputValidator = null;

        public IMatrixValidator CreateMatrixValidator()
        {
            if(matrixValidator == null)
            {
                matrixValidator = new MatrixValidator();
            }

            return matrixValidator;
        }

        public IUserInputValidator CreateUserInputValidator()
        {
            if(userInputValidator == null)
            {
                userInputValidator = new UserInputValidator();
            }

            return userInputValidator;
        }
    }
}