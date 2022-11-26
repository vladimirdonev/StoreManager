using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Manage.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManager.DAL.Entities;
using StoreManager.Models;
using StoreManager.Services.Users;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace StoreManager.ViewModels.Users
{
    public class ProfileViewModel : IndexModel
    {



        private readonly UserManagerExtension<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        
        public ProfileViewModel(
            UserManagerExtension<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        

        public string ProfileImg { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }


        [BindProperty]
        public new InputModel Input { get; set; }

        public new class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            
            public string ProfileImg { get; set; }

            
            public string FirstName { get; set; }

            
            public string LastName { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var firstName = await _userManager.GetFirstNameAsync(user);
            var lastName = await _userManager.GetLastNameAsync(user);
            var profileImg = await _userManager.GetProfilePictoreAsync(user);

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                
                LastName = lastName,

                FirstName = firstName,
                
                ProfileImg = profileImg
            };
        }

        public override async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public override async Task<IActionResult> OnPostAsync()
        {

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            var firstName = await _userManager.GetFirstNameAsync(user);
            if(Input.FirstName != firstName)
            {
                await _userManager.SetFirstNameAsync(user, Input.FirstName);
            }

            var lastName = await _userManager.GetLastNameAsync(user);
            if(Input.LastName != lastName)
            {
                await _userManager.SetLastNameAsync(user, Input.LastName);
            }

            var ProfileImg = await _userManager.GetProfilePictoreAsync(user);
            if(Input.ProfileImg != ProfileImg)
            {
                await _userManager.SetProfilePictoreAsync(user, Input.ProfileImg);
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }

    }
}
