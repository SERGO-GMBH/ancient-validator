using Me.Kuerschner.AncientValidation.Models.Enums;
using System;

namespace Me.Kuerschner.AncientValidation
{
    internal class RuleExecutor
    {
        public static RuleBuilder<TObject, TReturn> Check<TObject, TReturn>(RuleBuilder<TObject, TReturn> ruleBuilder, Func<RuleBuilder<TObject, TReturn>, bool> func, ErrorKey errorKey, bool canBeNull = false, params string[] args) where TObject : class, new()
        {
            if(ruleBuilder == null) throw new ArgumentNullException("ruleBuilder");
            if (!canBeNull)
            {
                if (ruleBuilder.Value == null)
                {
                    ruleBuilder.AddError(ErrorKey.NotNull);
                    return ruleBuilder;
                }
            }
            if(!func(ruleBuilder))
            {
                ruleBuilder.AddError(errorKey, args);
            }
            return ruleBuilder;
        }




    }
}
