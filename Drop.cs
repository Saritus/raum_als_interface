using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TouchWalkthrough
{

    class Drop
    {
        private int id              { get; set; }
        private string name         { get; set; }
        private string description  { get; set; }
        private Category category   { get; set; }

        private DateTime startTime  { get; set; }
        private DateTime endTime    { get; set; }

        private ExtendedLocation location { get; set; }

        private bool followed       { get; set; }
        private bool ignored        { get; set; }

        private string picturePath { get; set; }
    }
}
