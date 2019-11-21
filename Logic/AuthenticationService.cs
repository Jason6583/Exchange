using DataAccess.UnitOfWork;
using Entity;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Logic
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IReadOnlyContext _readOnlyContext;
        private readonly IUnitOfWork _unitOfWork;
        public AuthenticationService(IUnitOfWork unitOfWork, IReadOnlyContext readOnlyContext)
        {
            _unitOfWork = unitOfWork;
            _readOnlyContext = readOnlyContext;
        }

        public BusinessOperationResult<UserCredentials> Authenticate(string emailOrMobile, string password)
        {
            var userCredential = _unitOfWork.UserCredentialRepository.GetByEmailOrPhone(emailOrMobile);
            if (userCredential != null)
            {
                if (userCredential.LoginUnblockOn <= DateTime.UtcNow) //unblock after 
                {
                    userCredential.LoginUnblockOn = null;
                    userCredential.LoginFailedAttempt = 0;
                }

                if (userCredential.LoginUnblockOn == null)
                {
                    if (userCredential.PasswordHash == ComputeHash(password, userCredential.Salt))
                    {
                        if (userCredential.LoginFailedStartOn != null || userCredential.LoginUnblockOn != null)
                        {
                            userCredential.LoginFailedStartOn = null;
                            userCredential.LoginFailedAttempt = 0;
                            userCredential.LoginUnblockOn = null;
                        }
                        _unitOfWork.SaveChanges();
                        return new BusinessOperationResult<UserCredentials>()
                        {
                            ErrorCode = 0,
                            ErrorMessage = "Login Successful.",
                            Entity = userCredential
                        };
                    }
                    else
                    {
                        if (userCredential.LoginFailedStartOn == null || userCredential.LoginFailedStartOn < DateTime.UtcNow.AddHours(-24))
                        {
                            userCredential.LoginFailedStartOn = DateTime.UtcNow;
                            userCredential.LoginFailedAttempt = 0;
                        }

                        userCredential.LoginFailedAttempt++;

                        if (userCredential.LoginFailedAttempt == 3)
                        {
                            userCredential.LoginUnblockOn = DateTime.UtcNow.AddHours(24);
                        }
                        _unitOfWork.SaveChanges();
                        return new BusinessOperationResult<UserCredentials>()
                        {
                            ErrorCode = 1003,
                            ErrorMessage = "Invalid email or password."
                        };
                    }
                }
                else
                {
                    return new BusinessOperationResult<UserCredentials>()
                    {
                        ErrorCode = 1002,
                        ErrorMessage = "Your Login is blocked for 24 Hours. You can login after ",
                        Entity = userCredential
                    };
                }
            }
            else
            {
                return new BusinessOperationResult<UserCredentials>()
                {
                    ErrorCode = 1001,
                    ErrorMessage = "Invalid email or password."
                };
            }
        }
        private string ComputeHash(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var passwordBytes = Encoding.UTF8.GetBytes(password);
                var saltBytes = Convert.FromBase64String(salt);
                var bytes = new byte[passwordBytes.Length + saltBytes.Length];
                Array.Copy(passwordBytes, 0, bytes, 0, passwordBytes.Length);
                Array.Copy(saltBytes, 0, bytes, passwordBytes.Length, saltBytes.Length);
                return Convert.ToBase64String(sha256.ComputeHash(bytes));
            }
        }

        private string GenerateSalt()
        {
            var bytes = new byte[32];
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(bytes, 0, 32);
            }
            return Convert.ToBase64String(bytes);
        }
    }
}
