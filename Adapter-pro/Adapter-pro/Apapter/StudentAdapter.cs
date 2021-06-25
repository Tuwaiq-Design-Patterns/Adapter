using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Adapter_pro.Apapter
{
    class StudentAdapter: StudentRecord, IStudent
    {

        public override string GetAllStudent()
        {
            string resultxml = base.GetAllStudent();
            XmlDocument d = new XmlDocument();
            d.LoadXml(resultxml);
            return JsonConvert.SerializeObject(d, Newtonsoft.Json.Formatting.Indented);

        }
    }
}
