using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Model.Model.Test;

namespace WebApi.Model.ViewModel.Test
{
    class TestVM
    {
        public String Message { get; set; }

        static public implicit operator TestVM(WebApi.Model.Model.Test.Test obj)
        {
            return new TestVM()
            {
                Message = obj.Message
            };
        }
    }
}
