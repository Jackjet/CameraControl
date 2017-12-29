using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraControl
{
    public class JsonModel
    {
        public object retData { get; set; }
        public string errMsg { get; set; }
        public int errNum { get; set; }
        public string status { get; set; }
    }
}
