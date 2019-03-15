using System;
using System.Collections.Generic;
using System.Text;

namespace EntityModel
{
    public interface ICourse 
    {
        string CourseName { get; set; }
        double Fees { get; set; }
        int DurationInDays { get; set; }
        string Details { get; set; }
        
    }
}
