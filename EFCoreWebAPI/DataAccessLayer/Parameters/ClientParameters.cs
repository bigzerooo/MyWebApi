using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Parameters
{
    public class ClientParameters:QueryStringParameters
    {
        public string LastName { get; set; }
    }
}
