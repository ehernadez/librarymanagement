namespace LibraryManagement.Main.Entities
{
    public class AuditableEntity
    {
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
