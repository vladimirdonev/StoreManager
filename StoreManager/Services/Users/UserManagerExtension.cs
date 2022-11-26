using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StoreManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreManager.Services.Users
{
    public class UserManagerExtension<TUsers> : UserManager<ApplicationUser> where TUsers : ApplicationUser
    {
        public UserManagerExtension(IUserStore<ApplicationUser> store, IOptions<IdentityOptions> optionsAccessor, 
            IPasswordHasher<ApplicationUser> passwordHasher, IEnumerable<IUserValidator<ApplicationUser>> userValidators, 
            IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators, ILookupNormalizer keyNormalizer, 
            IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<ApplicationUser>> logger) : 
            base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }

        public async Task SetFirstNameAsync(TUsers User,string FirstName)
        {
            ThrowIfDisposed();
            if (User == null)
            {
                throw new ArgumentNullException("user");
            }
            User.FirstName = FirstName;
            await this.UpdateUserAsync(User);
        }
        public async Task<string> GetFirstNameAsync(TUsers User)
        {
            var FirstName = string.Empty;
            if(User.FirstName != null)
            {
                FirstName = User.FirstName;
            }

             return await Task.FromResult(FirstName);
        }

        public async Task<string> GetLastNameAsync(TUsers User)
        {
            var LastName = string.Empty;
            if (User.FirstName != null)
            {
                LastName = User.LastName;
            }

            return await Task.FromResult(LastName);
        }
        public async Task SetLastNameAsync(TUsers User, string LastName)
        {
            ThrowIfDisposed();
            if (User == null)
            {
                throw new ArgumentNullException("user");
            }
            User.LastName = LastName;
            await this.UpdateUserAsync(User);
        }

        public async Task SetProfilePictoreAsync(TUsers User, string ProfileImg)
        {
            ThrowIfDisposed();
            if (User == null)
            {
                throw new ArgumentNullException("user");
            }
            User.ProfileImg = ProfileImg;
            await this.UpdateUserAsync(User);
        }

        public async Task<string> GetProfilePictoreAsync(TUsers User)
        {
            var profilePictore = string.Empty;
            if (User.ProfileImg != null)
            {
                profilePictore = User.ProfileImg;
            }

            return await Task.FromResult(profilePictore);
        }
    }
}
