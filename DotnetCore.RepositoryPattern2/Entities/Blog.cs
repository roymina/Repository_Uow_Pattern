using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore.RepositoryPattern2.Entities
{
    public class Blog : IAuditable
    {
        [Key]
        public int BlogId { get; set; }
        public string Title { get; set; } 
        public string CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
