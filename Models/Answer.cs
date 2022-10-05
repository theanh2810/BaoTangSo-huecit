
using DotNetNuke.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HueCIT.Modules.BaoTangSo.Models
{
    [TableName("DapAn")]
    //setup the primary key for table
    [PrimaryKey("ID", AutoIncrement = true)]

    public class Answer
    {
        public int ID { get; set; }
        
        public int MaCauHoi { get; set; }
        public Guid MaMauVat { get; set; }

        public string DapAn { get; set; }

        public int CauHoiDung { get; set; }

        public string GhiChu { get; set; }

        public Answer()
        {
            
        }
    }
}