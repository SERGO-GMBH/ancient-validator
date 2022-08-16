using Me.Kuerschner.AncientValidation.Models.Enums;
using System;
using System.Collections.Generic;

namespace Me.Kuerschner.AncientValidation.Helper
{
    internal class CollectionHelper
    {
        public static RuleBuilder<TObject, IEnumerable<TReturn>> ForEach<TObject, TReturn>(RuleBuilder<TObject, IEnumerable<TReturn>> ruleBuilder, Action<BaseValidationHandler<TReturn>> validate, bool errorNull = false) where TObject : class, new() where TReturn : class, new()
        {
            if (ruleBuilder == null) throw new Exception("RuleBuilder was null.");
            if (ruleBuilder.Value == null)
            {
                if(errorNull)
                {
                    ruleBuilder.AddError(ErrorKey.NotNull);
                }
                return ruleBuilder;
            }
            foreach (var item in ruleBuilder.Value)
            {
                var baseValidationHandler = new BaseValidationHandler<TReturn>(item);
                validate(baseValidationHandler);
                var result = baseValidationHandler.Result();

                ruleBuilder.AddErrors(result.Errors);
            }
            return ruleBuilder;
        }

        public static RuleBuilder<TObject, IList<TReturn>> ForEach<TObject, TReturn>(RuleBuilder<TObject, IList<TReturn>> ruleBuilder, Action<BaseValidationHandler<TReturn>> validate, bool errorNull = false) where TObject : class, new() where TReturn : class, new()
        {
            if (ruleBuilder == null) throw new Exception("RuleBuilder was null.");
            if (ruleBuilder.Value == null)
            {
                if (errorNull)
                {
                    ruleBuilder.AddError(ErrorKey.NotNull);
                }
                return ruleBuilder;
            }
            foreach (var item in ruleBuilder.Value)
            {
                var baseValidationHandler = new BaseValidationHandler<TReturn>(item);
                validate(baseValidationHandler);
                var result = baseValidationHandler.Result();

                ruleBuilder.AddErrors(result.Errors);
            }
            return ruleBuilder;
        }

        public static RuleBuilder<TObject, List<TReturn>> ForEach<TObject, TReturn>(RuleBuilder<TObject, List<TReturn>> ruleBuilder, Action<BaseValidationHandler<TReturn>> validate, bool errorNull = false) where TObject : class, new() where TReturn : class, new()
        {
            if (ruleBuilder == null) throw new Exception("RuleBuilder was null.");
            if (ruleBuilder.Value == null)
            {
                if (errorNull)
                {
                    ruleBuilder.AddError(ErrorKey.NotNull);
                }
                return ruleBuilder;
            }
            foreach (var item in ruleBuilder.Value)
            {
                var baseValidationHandler = new BaseValidationHandler<TReturn>(item);
                validate(baseValidationHandler);
                var result = baseValidationHandler.Result();

                ruleBuilder.AddErrors(result.Errors);
            }
            return ruleBuilder;
        }
    }
}
