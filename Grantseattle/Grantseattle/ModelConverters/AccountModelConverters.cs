using InventoryERP.Domain;
using InventoryERP.Services.Models;
using InventoryERP.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryERP.Web.ModelConverters
{
    public static class AccountModelConverters
    {
        public static CreateMemberModel ToCreateMemberModel(this SignUpViewModel model)
        {
            CreateMemberModel entity = new CreateMemberModel();

            entity.Email = model.Email;
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Password = model.Password;

            return entity;
        }
    }
}