using Me.Kuerschner.AncientValidation.Helper;
using Me.Kuerschner.AncientValidation.Models.Enums;
using System;

namespace Me.Kuerschner.AncientValidation
{
    public static class RuleBuilderDateTimeExtensions
    {
        public static RuleBuilder<TObject, DateTime> LaterThan<TObject>(this RuleBuilder<TObject, DateTime> ruleBuilder, DateTime value) where TObject : class, new()
        {
            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return ruleBuilder.Value >= value;
            }, ErrorKey.LaterThan, args: value.ToString());
        }

        public static RuleBuilder<TObject, DateTime> EarlierThan<TObject>(this RuleBuilder<TObject, DateTime> ruleBuilder, DateTime value) where TObject : class, new()
        {
            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return ruleBuilder.Value <= value;
            }, ErrorKey.EarlierThan, args: value.ToString());
        }

        public static RuleBuilder<TObject, DateTime> IsEquals<TObject>(this RuleBuilder<TObject, DateTime> ruleBuilder, DateTime value) where TObject : class, new()
        {
            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return ruleBuilder.Value == value;
            }, ErrorKey.Equals, args: value.ToString());
        }

        public static RuleBuilder<TObject, DateTime> Between<TObject>(this RuleBuilder<TObject, DateTime> ruleBuilder, DateTime min, DateTime max) where TObject : class, new()
        {
            var minDate = DateHelper.GetMinDateTime(min, max);
            var maxDate = DateHelper.GetMaxDateTime(min, max);

            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return ruleBuilder.Value >= minDate && ruleBuilder.Value <= maxDate;
            }, ErrorKey.EarlierThan, args: new string[] { min.ToString(), max.ToString() });
        }
    }
}
