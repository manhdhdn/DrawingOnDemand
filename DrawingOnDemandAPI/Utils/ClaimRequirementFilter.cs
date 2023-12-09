using DataAccess.IRepository;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DrawingOnDemandAPI.Utils
{
    public class ClaimRequirementFilter : IAuthorizationFilter
    {
        private readonly IAccountRepository accountRepository = new AccountRepository();
        private readonly IAccountRoleRepository accountRoleRepository = new AccountRoleRepository();
        private readonly IRoleRepository roleRepository = new RoleRepository();

        readonly Claim _claim;

        public ClaimRequirementFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var tokenHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            if (tokenHeader == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var token = tokenHeader.Replace("Bearer ", "");
            var tokenHandler = new JwtSecurityTokenHandler();
            var decodedToken = tokenHandler.ReadJwtToken(token);

            var accountId = accountRepository.GetAccounts().SingleOrDefault(a => a.Email == decodedToken.Claims.SingleOrDefault(c => c.Type == _claim.Type)!.Value)!.Id;
            var roleIds = accountRoleRepository.GetAccountRoles().Where(ar => ar.AccountId == accountId).ToList();
            var roleId = roleRepository.GetRoles().SingleOrDefault(r => r.Name == _claim.Value)!.Id;

            var hasClaim = roleIds.Any(r => r.RoleId == roleId);


            if (!hasClaim)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
