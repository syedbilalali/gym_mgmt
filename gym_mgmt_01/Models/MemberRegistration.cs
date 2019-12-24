using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using gym_mgmt_01.Helper_Code.Common;
using gym_mgmt_01.Models;

namespace gym_mgmt_01.Models
{
    public class MemberRegistration
    {
        public Member member { get; set; }
        public Contact contact { get; set; }

        [AllowFileSize(FileSize = 5 * 1024 * 1024, ErrorMessage = "Maximum allowed file size is 5 MB")]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}