using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models.IdentityConfiguration
{
    public class ApplicationUser : IdentityUser<int> { }
    public class Role : IdentityRole<int> { }
    public class RoleClaim : IdentityRoleClaim<int> { }
    public class UserToken : IdentityUserToken<int> { }
}
