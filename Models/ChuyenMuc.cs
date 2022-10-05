
using DotNetNuke.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HueCIT.Modules.BaoTangSo.Models
{
    [TableName("ChuyenMuc")]
    //setup the primary key for table
    [PrimaryKey("ID", AutoIncrement = true)]

    public class ChuyenMuc
    {
        public Guid ID { get; set; }
        public string TenChuyenMuc { get; set; }
        public Guid IDChuyenMucCha { get; set; }

        public string MoTa { get; set; }

        [Required]
        public int ThuTuHienThi { get; set; }

        public ChuyenMuc()
        {
            this.ID = Guid.NewGuid();
            this.MoTa = null;
        }
    }
}