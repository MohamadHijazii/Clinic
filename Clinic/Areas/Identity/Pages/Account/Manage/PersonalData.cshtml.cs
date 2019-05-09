using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Clinic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Clinic.Areas.Identity.Pages.Account.Manage
{
    public class PersonalDataModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<PersonalDataModel> _logger;

        public PersonalDataModel(
            UserManager<ApplicationUser> userManager,
             SignInManager<ApplicationUser> signInManager,
            ILogger<PersonalDataModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name ="First Name")]
            public string Fname { get; set; }

            [Display(Name = "Middle Name")]
            public string Mname { get; set; }

            [Display(Name = "Last Name")]
            public string Lname { get; set; }
        }


        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var fname = user.fname;
            var mname = user.mname;
            var lname = user.lname;


            Input = new InputModel
            {
                Fname = fname,
                Mname = mname,
                Lname = lname
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var fname = user.fname;
            if (Input.Fname != fname)
            {
               // var setFnameResult = await _userManager.SetEmailAsync(user, Input.Email);
                user.fname = Input.Fname;
                //    var userId = await _userManager.GetUserIdAsync(user);
                //    throw new InvalidOperationException($"Unexpected error occurred setting email for user with ID '{userId}'.");
            }

            var mname = user.mname;
            if (Input.Mname != mname)
            {
                //var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);

                user.mname = Input.Mname;

                //if (!setPhoneResult.Succeeded)
                //{
                //    var userId = await _userManager.GetUserIdAsync(user);
                //    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                //}
            }


            var lname = user.lname;
            if (Input.Lname != lname)
            {
                //var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);

                user.lname = Input.Lname;

                //if (!setPhoneResult.Succeeded)
                //{
                //    var userId = await _userManager.GetUserIdAsync(user);
                //    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                //}
            }

            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }



    }
}