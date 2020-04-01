using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Sistem_Ventas.Areas.Usuarios.Models;
using Sistem_Ventas.Data;
using Sistem_Ventas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistem_Ventas.Library
{
    public class LUsuarios : ListObject
    {
        public LUsuarios()
        {

        }
        public LUsuarios(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _usersRole = new UsersRoles();
        }
        public LUsuarios(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
            _usersRole = new UsersRoles();
        }
        internal async Task<List<object[]>> userLogin(string email, string password)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var appUser1 = _context.Users.Where(u => u.Email.Equals(email)).ToList();
                    var appUser2 = _context.TUsuarios.Where(u => u.IdUser.Equals(appUser1[0].Id)).ToList();
                    _selectList = await _usersRole.getRole(_userManager, _roleManager, appUser1[0].Id);
      
                    code = "0";
                    description = result.Succeeded.ToString();
                }
                else
                {
                    code = "1";
                    description = "Correo o contraseña inválidos";
                }
            }
            catch (Exception ex)
            {

                code = "2";
                description = ex.Message;
            }
            _identityError = new IdentityError
            {
                Code = code,
                Description = description
            };
            object[] data = { _identityError, _userData };
            dataList.Add(data);
            return dataList;
        }
        public async Task<List<InputModelRegistrar>> getTUsuariosAsync(String valor)
        {
            List<TUsuarios> listUser;
            if (valor == null)
            {
                listUser = _context.TUsuarios.ToList();
            }
            else
            {
                listUser = _context.TUsuarios.Where(u => u.NID.StartsWith(valor) || u.Nombre.StartsWith(valor) || u.Apellido.StartsWith(valor) || u.Imagen.StartsWith(valor)).ToList();
            }
            List<InputModelRegistrar> userList = new List<InputModelRegistrar>();
            
            foreach (var item in listUser)
            {
                _selectList = await _usersRole.getRole(_userManager, _roleManager, item.IdUser);
                userList.Add(new InputModelRegistrar
                {
                    Id = item.ID,
                    ID = item.IdUser,
                    NID = item.NID,
                    Nombre = item.Nombre,
                    Apellido = item.Apellido,
                    Role = _selectList[0].Text,
                    Email = item.Imagen
                });
                _selectList.Clear();
            }
            return userList;
        }

    }
}
