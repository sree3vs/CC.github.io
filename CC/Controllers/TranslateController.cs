using CC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CC.Controllers
{
    public class TranslateController : ApiController
    {
        private Translate[] tr = new Translate[]
        {
            new Translate {currentlangtext = "Hello", targetlangtext ="नमस्ते", language="Hindi" }
        };

        public IEnumerable<Translate> GetAll()
        {
            return tr;
        }
    }
}
