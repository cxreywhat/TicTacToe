using AutoMapper;
using Core.Dto.UserDto;
using Core.Exceptions.UserExceptions;
using Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Core.RegularExpressions
{
    public class UserRegularExpressions
    {
        public bool ValidNewUser(UserRegisterDto user)
        {
            if (user.Username.Length < Constants.MIN_LENGTH_USERNAME ||
                user.Username.Length > Constants.MAX_LENGTH_USERNAME)
            {
                throw new InvalidUsernameException("Имя должно состоять от 4 до 16 символов.");
            }
            else if(!IsLetterOrDigit(user.Username))
            {
                throw new InvalidUsernameException("Имя может состоять только из букв или цифр.");
            }
            else if (user.Password.Length < Constants.MIN_LENGTH_PASSWORD ||
                user.Password.Length > Constants.MAX_LENGTH_PASSWORD)
            {
                throw new InvalidPasswordException("Пароль должен состоять от 8 до 32 символов.");
            }
            else if(!IsLetterOrDigit(user.Password) && PasswordHasPunctation(user.Password))
            {
                throw new InvalidPasswordException("Пароль должен стоять из букв, цифр и знаков препинания: '!', '?' '.', ','");
            }

            return true;
        }

        private bool IsLetterOrDigit(string str) =>
            str.Any(x => char.IsLetterOrDigit(x));


        private bool PasswordHasPunctation(string password) =>
            password.Any(x => x == '!' || x == ',' || x == '.' || x == '?' );

    }
}
