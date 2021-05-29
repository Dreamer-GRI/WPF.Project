using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    public class User
    {
        private string log;
        private string pass;

        public int Id { get; set; }

        public string Log
        {
            get { return log; }
            set
            {
                log = value;
            }
        }
        public string Pass
        {
            get { return pass; }
            set
            {
                pass = value;
            }
        }
    }
}
