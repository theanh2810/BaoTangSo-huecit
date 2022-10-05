
using DotNetNuke.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HueCIT.Modules.BaoTangSo.Models
{
    [TableName("FileDinhKem")]
    //setup the primary key for table
    [PrimaryKey("ID", AutoIncrement = true)]

    public class FileDinhKem
    {
        public Guid ID { get; set; }
        public Guid MaMauVat { get; set; }
        public string TenTep { get; set; }

        public string MoTa { get; set; }

        public string ViTriLuuTru { get; set; }
        
        public int LoaiFile { get; set; }

        public string AnhDaiDien { get; set; }

        public FileDinhKem()
        {
            this.ID = Guid.NewGuid();
        }
    }
}