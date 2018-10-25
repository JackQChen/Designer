
namespace FlowControl
{
    public abstract class DesignerItemBase
    {
        public DesignerItemBase()
        {
        }

        public DesignerItemBase(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
