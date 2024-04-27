using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTRKDotNetCore.ConsoleApp;

[Table("Tbl_Blog")]
//EFCore သုံးမယ်ဆိုရင် table name ကြေညာပေးရတယ် ပီးတော့ primary key ကုိကြေညာပေးရတယ် 

public class BlogDto
{
    [Key] 
    public int BlogId { get; set; }
    public string BlogTitle { get; set; }
    public string BlogAuthor { get; set; }
    public string BlogContent { get; set;}
}

// public record BlogEntity(int BlogId, string BlogTitle , string BlogAuthor , string BlogContent);
