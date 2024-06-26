﻿namespace DatabaseLibrary.Entities.Actions;

public partial class Comment
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public DateTime Date { get; set; }
    public string EntityType { get; set; } = null!;
    public int EntryId { get; set; }
    public string Text { get; set; } = null!;
    public bool? IsTechnical { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}