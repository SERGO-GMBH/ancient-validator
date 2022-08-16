using Me.Kuerschner.AncientValidation.Helper;
using System;
using System.Collections.Generic;

namespace Me.Kuerschner.AncientValidation
{
    public static class RuleBuilderCollectionExtensions
    {
        public static RuleBuilder<TObject, List<TReturn>> ForEach<TObject, TReturn>(this RuleBuilder<TObject, List<TReturn>> ruleBuilder, Action<BaseValidationHandler<TReturn>> validate, bool errorNull = false) where TObject : class, new() where TReturn : class, new()
        {
            return CollectionHelper.ForEach(ruleBuilder, validate, errorNull);
        }

        public static RuleBuilder<TObject, IList<TReturn>> ForEach<TObject, TReturn>(this RuleBuilder<TObject, IList<TReturn>> ruleBuilder, Action<BaseValidationHandler<TReturn>> validate, bool errorNull = false) where TObject : class, new() where TReturn : class, new()
        {
            return CollectionHelper.ForEach(ruleBuilder, validate, errorNull);
        }

        public static RuleBuilder<TObject, IEnumerable<TReturn>> ForEach<TObject, TReturn>(this RuleBuilder<TObject, IEnumerable<TReturn>> ruleBuilder, Action<BaseValidationHandler<TReturn>> validate, bool errorNull = false) where TObject : class, new() where TReturn : class, new()
        {
            return CollectionHelper.ForEach(ruleBuilder, validate, errorNull);
        }
    }
}
