
namespace Me.Kuerschner.AncientValidation.Contracts
{
    public interface IHaveValidator<TObject> : IBaseValidator<TObject> where TObject : class, IHaveValidator<TObject>, new()
    {
        
    }
}
