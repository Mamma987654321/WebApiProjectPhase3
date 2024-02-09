using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class Subject
    {
        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public int? Marks { get; set; }
    }
}
