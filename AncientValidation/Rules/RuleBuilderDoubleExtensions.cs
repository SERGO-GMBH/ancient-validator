using Me.Kuerschner.AncientValidation.Models.Enums;
using System;

namespace Me.Kuerschner.AncientValidation
{
    public static class RuleBuilderDoubleExtensions
    {
        public static RuleBuilder<TObject, double> NotNull<TObject>(this RuleBuilder<TObject, double> ruleBuilder) where TObject : class, new()
        {
            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return ruleBuilder.Value == 0;
            }, ErrorKey.Equals, canBeNull: true);
        }

        public static RuleBuilder<TObject, double> LowerThan<TObject>(this RuleBuilder<TObject, double> ruleBuilder, double value) where TObject : class, new()
        {
            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return ruleBuilder.Value <= value;
            }, ErrorKey.LowerThan, args: value+"");
        }

        public static RuleBuilder<TObject, double> HigherThan<TObject>(this RuleBuilder<TObject, double> ruleBuilder, double value) where TObject : class, new()
        {
            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return ruleBuilder.Value >= value;
            }, ErrorKey.HigherThan, args: value + "");
        }

        public static RuleBuilder<TObject, double> IsEquals<TObject>(this RuleBuilder<TObject, double> ruleBuilder, double value) where TObject : class, new()
        {
            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return ruleBuilder.Value == value;
            }, ErrorKey.Equals, args: value + "");
        }

        public static RuleBuilder<TObject, double> Between<TObject>(this RuleBuilder<TObject, double> ruleBuilder, double min, double max) where TObject : class, new()
        {
            var rMin = Math.Min(min, max);
            var rMax = Math.Max(min, max);

            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return ruleBuilder.Value >= rMin && ruleBuilder.Value <= rMax;
            }, ErrorKey.Between, args: new string[] { min + "", max + "" });
        }

        public static RuleBuilder<TObject, double> Divisible<TObject>(this RuleBuilder<TObject, double> ruleBuilder, double value) where TObject : class, new()
        {
            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return ruleBuilder.Value % value == 0;
            }, ErrorKey.Devisible, args: value + "");
        }

        public static RuleBuilder<TObject, double> Even<TObject>(this RuleBuilder<TObject, double> ruleBuilder) where TObject : class, new()
        {
            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return ruleBuilder.Value % 1 == 0;
            }, ErrorKey.Even);
        }
    }
}
