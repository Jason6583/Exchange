using Auth.Models;
using IdentityServer4.Events;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Logic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Auth.Controllers
{
    public class AccountController : Controller
    {
        private readonly Logic.IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        private readonly IClientStore _clientStore;
        private readonly IIdentityServerInteractionService _identityServerInteractionService;
        private readonly IEventService _eventService;
        public AccountController(Logic.IAuthenticationService authenticationService, IUserService userService, IClientStore clientStore, IIdentityServerInteractionService identityServerInteractionService, IEventService eventService)
        {
            _authenticationService = authenticationService;
            _userService = userService;
            _clientStore = clientStore;
            _identityServerInteractionService = identityServerInteractionService;
            _eventService = eventService;
        }

        public IActionResult Login(string ReturnUrl)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login, int? dummy)
        {
            if (ModelState.IsValid && login != null)
            {
                var authenticationResult = _authenticationService.Authenticate(login.EmailOrMobile, login.Password);

                if (authenticationResult.ErrorCode == 0)
                {
                    var user = _userService.GetUser(authenticationResult.Entity.UserId);

                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim("FullName", user.Email),
                        new Claim(ClaimTypes.Role, user.Email),
                        new Claim("subject", user.UniqueId.ToString().ToLower()),
                        new Claim("sub", user.UniqueId.ToString().ToLower()),
                        new Claim("name", user.Email.ToString().ToLower())
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        ExpiresUtc = DateTimeOffset.Now.AddDays(1),
                        IsPersistent = true,
                    };
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                    var context = await _identityServerInteractionService.GetAuthorizationContextAsync(login.ReturnUrl);
                    if (context != null)
                    {
                        var client = await _clientStore.FindClientByIdAsync(context.ClientId);
                        if (client != null && client.RequirePkce)
                        {
                            throw new NotImplementedException();
                        }
                        else
                        {
                            // we can trust model.ReturnUrl since GetAuthorizationContextAsync returned non-null
                            return Redirect(login.ReturnUrl);
                        }
                    }

                    // request for a local page
                    if (Url.IsLocalUrl(login.ReturnUrl))
                    {
                        return Redirect(login.ReturnUrl);
                    }
                    else if (string.IsNullOrEmpty(login.ReturnUrl))
                    {
                        return Redirect("~/");
                    }
                }
                else
                {
                    ModelState.AddModelError("", authenticationResult.ErrorMessage);
                }
                //await _eventService.RaiseAsync(new UserLoginSuccessEvent(user.Email, user.Email, user.MobileNumber));
            }
            return View(login);
        }
    }
}
