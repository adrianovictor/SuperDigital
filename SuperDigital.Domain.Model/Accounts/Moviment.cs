using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.Domain.Model.Accounts
{
    public class Moviment
    {
        public DateTime Date { get; set; }
        public string Operation { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public string AccountOrigin { get; set; }
        public string AccountDestine { get; set; }
    }
}
