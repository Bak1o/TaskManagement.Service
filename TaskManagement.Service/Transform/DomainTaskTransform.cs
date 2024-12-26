using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Service.Enums;
using TaskManagement.Service.Exceptions;
using TaskManagement.Service.Models;

namespace TaskManagement.Service.Transform
{
    public static class DomainTaskTransform
    {
        public static void TransformFromModelToRepositoryModel(UpdateDomainTask source, DomainTask target)
        {
            target.Title = source.Title;
            target.Description = source.Description;
            target.DeadLine = source.DeadLine;
            target.Id = source.Id;
           
            if (target.Status == Status.InProgress && source.Status == Status.ToDo)
                throw new OwnValidationException(" if task status is in progress you can't change into to do");
            
            if(target.Status == Status.Done && (source.Status == Status.ToDo || source.Status == Status.InProgress))
                 throw new OwnValidationException(" if task status is done you can't change status ");

            
            target.Status = source.Status;
            target.Priority = source.Priority;

        }
    }
}
