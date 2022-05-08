using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMTutorial.Models
{
    public class TrainingCourse
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string PresentedBy { get; set; }

        public DateTime Date { get; set; }
    }
}
