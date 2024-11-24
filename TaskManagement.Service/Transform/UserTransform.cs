using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Service.Models;

namespace TaskManagement.Service.Transform
{
    public class UserTransform
    {
        public void TransformFromModelToRepositoryModel(UpdateUser source, User target)
        {
            target.UserName = source.UserName;
            target.Email = source.Email;
            target.Password = source.Password;
            target.Id = source.Id;
            target.Role = source.Role;

        }
    }
}
