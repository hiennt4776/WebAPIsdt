using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIsdt.Authorize;
using WebAPIsdt.Models;
using WebAPIsdt.Repository;

namespace WebAPIsdt.Controllers
{
    [BearerAuthorization]
    public class BenhNhanController : ApiController
    {
        

        private readonly BenhNhanRepository _repository;

        public BenhNhanController()
        {
            _repository = new BenhNhanRepository();
        }

        public IEnumerable<BenhNhan> GetAll()
        {
            return _repository.GetAll();
        }

        [Route("api/GetBenhNhanSDT")]
        public IEnumerable<BenhNhan> GetBenhNhanSDT(string SDT)
        {
            return _repository.GetBenhNhanTheoSDT(SDT);
        }

        
    }
}
