﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WebAppDemo
{
    internal class Grade
    {
        public Grade()
        {
            Students = new List<Student>();
           

        }
        public int GradeId {  get; set; }
        public string GradeName { get; set; }
        public IList<Student> Students { get; set; }
    }
}
