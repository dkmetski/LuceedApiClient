using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Luceed.ClientApp.Models
{
    public class DataViewModel
    {
        public List<Query1Model> Query1Models { get; set; }
        public List<Query2Model> Query2Models { get; set; }
        public List<Query3Model> Query3Models { get; set; }
    }
}