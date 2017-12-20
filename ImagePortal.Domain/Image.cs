using System;
using System.Collections.Generic;
using System.Text;

namespace ImagePortal.Domain
{
    public class Image
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public byte[] ImageData { get; set; }
    }
}
