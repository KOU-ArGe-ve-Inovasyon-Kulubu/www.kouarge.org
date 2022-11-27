namespace KouArge.Core.Models
{
    public class Title : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<GeneralAssemblyApply> GeneralAssemblyApplies { get; set; }
    }
}
