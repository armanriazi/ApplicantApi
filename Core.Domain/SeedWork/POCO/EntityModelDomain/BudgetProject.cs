using Core.Domain.EntityDataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Domain.SeedWork.POCO.EntityModelDomain
{
  
    public class BudgetProject:BaseEntity
    {
        
        public string BUD_ProjectID { get; set; }
    
        public string ProjectName { get; set; }      
    }
}
