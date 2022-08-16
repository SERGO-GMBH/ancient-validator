using Me.Kuerschner.AncientValidation.Models.Enums;
using System;

namespace Me.Kuerschner.AncientValidation
{
    public static class RuleBuilderFloatExtensions
    {
        public static RuleBuilder<TObject, float> NotNull<TObject>(this RuleBuilder<TObject, float> ruleBuilder) where TObject : class, new()
        {
            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return ruleBuilder.Value != 0;
            }, ErrorKey.NotNull, true);
        }

        public static RuleBuilder<TObject, float> LowerThan<TObject>(this RuleBuilder<TObject, float> ruleBuilder, float value) where TObject : class, new()
        {
            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return ruleBuilder.Value <= value;
            }, ErrorKey.LowerThan, args: value + "");
        }

        public static RuleBuilder<TObject, float> HigherThan<TObject>(this RuleBuilder<TObject, float> ruleBuilder, float value) where TObject : class, new()
        {
            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return ruleBuilder.Value >= value;
            }, ErrorKey.HigherThan, args: value + "");
        }

        public static RuleBuilder<TObject, float> IsEquals<TObject>(this RuleBuilder<TObject, float> ruleBuilder, float value) where TObject : class, new()
        {
            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return ruleBuilder.Value == value;
            }, ErrorKey.Equals, args: value + "");
        }

        public static RuleBuilder<TObject, float> Between<TObject>(this RuleBuilder<TObject, float> ruleBuilder, float min, float max) where TObject : class, new()
        {
            var rMin = Math.Min(min, max);
            var rMax = Math.Max(min, max);

            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return ruleBuilder.Value >= rMin && ruleBuilder.Value <= rMax;
            }, ErrorKey.Equals, args: new string[] { min + "", max + "" });
        }

        public static RuleBuilder<TObject, float> Divisible<TObject>(this RuleBuilder<TObject, float> ruleBuilder, float value) where TObject : class, new()
        {
            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return ruleBuilder.Value % value == 0;
            }, ErrorKey.Devisible, args: value + "");
        }

        public static RuleBuilder<TObject, float> Even<TObject>(this RuleBuilder<TObject, float> ruleBuilder) where TObject : class, new()
        {
            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return ruleBuilder.Value % 1 == 0;
            }, ErrorKey.Even);
        }
    }
}
