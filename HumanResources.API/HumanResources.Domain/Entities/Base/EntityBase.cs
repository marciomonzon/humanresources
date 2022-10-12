namespace HumanResources.Domain.Entities.Base
{
    public abstract class EntityBase
    {
        public int Id { get; private set; }
        public DateTime CreatedDate { get; private set; }

        protected EntityBase()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
