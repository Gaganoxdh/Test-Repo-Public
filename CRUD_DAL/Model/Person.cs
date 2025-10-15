using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CRUD_DAL.Model
{
    public class Person
    {
        [Key]
       
        public int Id { get; set; }
        
        public string UserName { get; set; }

        public string UserPassword { get; set; }  
        
        public string UserEmail { get; set; } 
        
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    
        public bool IsDeleted { get; set; } = false;
    }
}
