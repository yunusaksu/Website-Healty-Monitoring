using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor.Business
{
    public class TestRecord
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime? LastTestTime { get; set; }
        public bool Status { get; set; }
        public string ErrorMessage { get; set; }
    }
}
