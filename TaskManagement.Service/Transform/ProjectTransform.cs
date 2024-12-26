using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Service.Models;

namespace TaskManagement.Service.Transform
{
    public static class ProjectTransform
    {
        public static void TransformFromModelToRepositoryModel(UpdateProject source, Project target)
        {
            target.Name = source.Name;
            target.Description = source.Description;
            target.EndDate = source.EndDate;
            target.Id = source.Id;
            target.Status = source.Status;

        }

    }
}
