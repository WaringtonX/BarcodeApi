using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BarCodeApi.Models;

[Table("Barcode")]
public partial class Barcode
{
    [Key]
    [Column("bar_id")]
    public int BarId { get; set; }

    [Column("bar_code")]
    [StringLength(50)]
    [Unicode(false)]
    public string BarCode1 { get; set; } = null!;

    [Column("bar_name")]
    [StringLength(100)]
    [Unicode(false)]
    public string BarName { get; set; } = null!;

    [Column("bar_itemcount")]
    public int BarItemcount { get; set; }

    [Column("bar_createdate", TypeName = "datetime")]
    public DateTime BarCreatedate { get; set; }
}
