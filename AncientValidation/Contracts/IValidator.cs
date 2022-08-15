namespace Me.Kuerschner.AncientValidation.Contracts
{
    public interface IValidator<TObject> : IBaseValidator<TObject> where TObject : class, new()
    {
    }
}
