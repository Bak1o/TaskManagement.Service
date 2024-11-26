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
    public class DomainTaskTransform
    {
        public void TransformFromModelToRepositoryModel(UpdateDomainTask target, DomainTask source)
        {
            source.Title = target.Title;
            source.Description = target.Description;
            source.DeadLine = target.DeadLine;
            source.Id = target.Id;
           
            if (source.Status == Status.InProgress && target.Status == Status.ToDo)
                throw new OwnValidationException(" if task status is in progress you can't change into to do");
            
            if(source.Status == Status.Done && (target.Status == Status.ToDo || target.Status == Status.InProgress))
                 throw new OwnValidationException(" if task status is done you can't change status ");

            
            source.Status = target.Status;
            source.Priority = target.Priority;

        }
    }
}
