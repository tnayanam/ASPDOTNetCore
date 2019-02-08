﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public class ConferenceModel
    {
        public ConferenceModel()
        {
            Start = DateTime.Now;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public string Location { get; set; }
        public int AttendeeTotal { get; set; }
    }
}
