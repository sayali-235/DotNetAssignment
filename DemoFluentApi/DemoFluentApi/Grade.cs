using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFluentApi
{
    internal class Grade
    {
        public int GardeID { get; set; }
        public string GardeName { get; set; }
        public ICollection<Student>Students { get; set; }
    }
}
