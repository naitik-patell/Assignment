using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataModels;

[Table("employee")]
public partial class Employee
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("firstname", TypeName = "character varying")]
    public string Firstname { get; set; } = null!;

    [Column("lastname", TypeName = "character varying")]
    public string Lastname { get; set; } = null!;

    [Column("deptid")]
    public int? Deptid { get; set; }

    [Column("age")]
    public int Age { get; set; }

    [Column("email", TypeName = "character varying")]
    public string Email { get; set; } = null!;

    [Column("education", TypeName = "character varying")]
    public string Education { get; set; } = null!;

    [Column("company", TypeName = "character varying")]
    public string Company { get; set; } = null!;

    [Column("experience")]
    public int Experience { get; set; }

    [Column("package")]
    public int Package { get; set; }

    [Column("gender", TypeName = "character varying")]
    public string Gender { get; set; } = null!;

    [ForeignKey("Deptid")]
    [InverseProperty("Employees")]
    public virtual Department? Dept { get; set; }
}
