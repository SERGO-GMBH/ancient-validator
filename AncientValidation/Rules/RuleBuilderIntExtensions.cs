using Me.Kuerschner.AncientValidation.Models.Enums;
using System;

namespace Me.Kuerschner.AncientValidation
{
    public static class RuleBuilderIntExtensions
    {
        public static RuleBuilder<TObject, int> NotNull<TObject>(this RuleBuilder<TObject, int> ruleBuilder) where TObject : class, new()
        {
            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return ruleBuilder.Value != 0;
            }, ErrorKey.NotNull);
        }

        public static RuleBuilder<TObject, int> LowerThan<TObject>(this RuleBuilder<TObject, int> ruleBuilder, int value) where TObject : class, new()
        {
            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return ruleBuilder.Value <= value;
            }, ErrorKey.LowerThan, args: value + "");
        }

        public static RuleBuilder<TObject, int> HigherThan<TObject>(this RuleBuilder<TObject, int> ruleBuilder, int value) where TObject : class, new()
        {
            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return ruleBuilder.Value >= value;
            }, ErrorKey.HigherThan, args: value + "");
        }

        public static RuleBuilder<TObject, int> IsEquals<TObject>(this RuleBuilder<TObject, int> ruleBuilder, int value) where TObject : class, new()
        {
            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return ruleBuilder.Value == value;
            }, ErrorKey.Equals, args: value + "");
        }

        public static RuleBuilder<TObject, int> Between<TObject>(this RuleBuilder<TObject, int> ruleBuilder, int min, int max) where TObject : class, new()
        {
            var rMin = Math.Min(min, max);
            var rMax = Math.Max(min, max);

            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return ruleBuilder.Value >= rMin && ruleBuilder.Value <= rMax;
            }, ErrorKey.Equals, args: new string[] { min + "", max + "" });
        }

        public static RuleBuilder<TObject, int> Divisible<TObject>(this RuleBuilder<TObject, int> ruleBuilder, int value) where TObject : class, new()
        {
            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return ruleBuilder.Value % value == 0;
            }, ErrorKey.Devisible, args: value + "");
        }
    }
}
