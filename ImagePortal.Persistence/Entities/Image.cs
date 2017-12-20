using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagePortal.Persistence.Entities
{
    public class Image : EntityBase
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public byte[] ImageData { get; set; }   
    }
}
