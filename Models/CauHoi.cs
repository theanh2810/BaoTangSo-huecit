
using DotNetNuke.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HueCIT.Modules.BaoTangSo.Models
{
    [TableName("CauHoi")]
    //setup the primary key for table
    [PrimaryKey("ID", AutoIncrement = true)]

    public class CauHoi
    {
        public int ID { get; set; }
        
        public Guid MaMauVat { get; set; }

        public string MoTa { get; set; }

        public string NoiDungCauHoi { get; set; }

        [Required]
        public int ThuTuHienThi { get; set; }

        public CauHoi()
        {
            
        }
    }
}