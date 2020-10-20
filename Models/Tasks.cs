using CheckList.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CheckList.Models
{
    public class TaskGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [Display(Description = "Please provide a Name for this Task Group.", Name = "Group Name")]
        public string GroupName { get; set; }
        public bool Complete { get; set; }
        public DateTime AddDate { get; set; }
        public string AddByUserId {get;set; } //if this list were to become "public"
        public DateTime? UpdateDate { get; set; }
        public string UpdateByUserId { get; set; } //if this list were to become "public"

        public virtual ICollection<Task> Task { get; set; }        
        public virtual ApplicationUser AddByUser { get; set; }
        
    }
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public Guid TaskGroupId { get; set; }
        [Display(Description = "Please provide a Title for this Task.", Name = "Task Title")]
        public string TaskTitle { get; set; }
        public bool TaskComplete { get; set; }
        public DateTime? TaskDue { get; set; }
        public DateTime AddDate { get; set; }
        public string AddByUserId { get; set; } //if this list were to become "public"
        public DateTime? UpdateDate { get; set; } 
        public string UpdateByUserId { get; set; } //if this list were to become "public"
        public virtual ApplicationUser AddByUser { get; set; }
        public virtual ApplicationUser UpdateByUser { get; set; }

        public virtual TaskGroup TaskGroup { get; set; }

    }
}
