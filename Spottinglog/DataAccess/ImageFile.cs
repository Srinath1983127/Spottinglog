using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Spottinglog.DataAccess
{
    public class ImageFile
    {
        public HttpPostedFileBase Image { get; set; }
    }
}