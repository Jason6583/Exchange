using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public interface IAuthenticationService
    {
        BusinessOperationResult<UserCredentials> Authenticate(string emailOrMobile, string password);
    }
}
