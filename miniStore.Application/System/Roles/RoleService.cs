using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using miniStore.Data.Entities;
using miniStore.ViewModels.System.Roles;
using miniStore.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniStore.Application.System.Roles
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleService(RoleManager<AppRole> roleManager) { 
            _roleManager = roleManager;
        }
        public async Task<List<RoleVM>> GetAll()
        {
            var result = await _roleManager.Roles.Select(x => new RoleVM()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).ToListAsync();

            return result;
        }
    }
}
