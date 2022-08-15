using System;
using System.Collections.Generic;
using System.Text;

namespace Me.Kuerschner.AncientValidation.Contracts
{
    public interface IBaseValidator<TObject> where TObject : class, new()
    {
        void Validate(BaseValidationHandler<TObject> validator);
    }
}
