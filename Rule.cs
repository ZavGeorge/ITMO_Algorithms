using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_lab_8
{
    class Rule
    {
        public String From { get; private set; }
        public String To { get; private set; }
        public bool Last { get; private set; }
        public Rule(String from, String to, bool last)
        {
            From = from;
            To = to;
            Last = last;
        }

       



    }
}
