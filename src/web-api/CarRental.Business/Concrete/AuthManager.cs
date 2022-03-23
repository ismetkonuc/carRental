﻿using CarRental.Business.Constants;
using CarRental.Business.Interfaces;
using CarRental.Core.Utils.Results;
using CarRental.Core.Utils.Security.JWT;
using CarRental.Entities.Concrete;
using CarRental.Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace CarRental.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenHelper _tokenHelper;
        private readonly SignInManager<AppUser> _signInManager;
        public AuthManager(UserManager<AppUser> userManager, ITokenHelper tokenHelper, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tokenHelper = tokenHelper;
            _signInManager = signInManager;
        }

        public IDataResult<AppUser> Register(UserForRegisterDto userForRegisterDto, string password)
        {

            var userExistResult = UserExists(userForRegisterDto.Email);
            if (!userExistResult.IsSuccess)
            {
                return userExistResult;
            }

            AppUser registeredUser = new AppUser()
            {
                Name = userForRegisterDto.FirstName,
                Surname = userForRegisterDto.LastName,
                Email = userForRegisterDto.Email
            };

            _userManager.CreateAsync(registeredUser, userForRegisterDto.Password);
            return new SuccessDataResult<AppUser>(registeredUser, true, Messages.UserRegistered);
        }

        public IDataResult<AppUser> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userManager.FindByEmailAsync(userForLoginDto.Email).Result;
            if (userToCheck == null)
            {
                return new ErrorDataResult<AppUser>(userToCheck, false, Messages.UserNotFound);
            }

            var signInResult = _signInManager.CheckPasswordSignInAsync(userToCheck, userForLoginDto.Password, false).Result;

            if (!signInResult.Succeeded)
            {
                return new ErrorDataResult<AppUser>(userToCheck, true,Messages.UserNotFound);
            }

            _signInManager.SignInAsync(userToCheck, true).Wait();
            return new SuccessDataResult<AppUser>(userToCheck, true, Messages.SuccessfulLogin);
        }

        public IDataResult<AppUser> UserExists(string email)
        {
            var user = _userManager.FindByEmailAsync(email).Result;
            if (user is not null)
            {
                return new ErrorDataResult<AppUser>(user, false, Messages.UserAlreadyExists);
            }
            return new SuccessDataResult<AppUser>(null ,true);
        }

        public IDataResult<AccessToken> CreateAccessToken(AppUser user)
        {
            var roles = _userManager.GetRolesAsync(user).Result.ToList();
            var accessToken = _tokenHelper.CreateToken(user, roles);
            return new SuccessDataResult<AccessToken>(accessToken, true, Messages.AccessTokenCreated);
        }
    }
}