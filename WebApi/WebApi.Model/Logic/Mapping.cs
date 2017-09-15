using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Model.Model.Test;
using WebApi.Model.ViewModel.Test;

namespace WebApi.Model.Logic
{
    public class Mapping
    {
        public Mapping()
        {

            var x0 = new Test();
            List < Test > list = new List<Test>();
            list.Add(x0);
            var x1 = new TestVM();
            var ha = list.Select(x=>new TestVM { Message = x.Message });

            var nnaa = list.ConvertAll<TestVM>(x=>x);
        }

    }
}
