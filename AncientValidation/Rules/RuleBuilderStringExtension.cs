using Me.Kuerschner.AncientValidation.Constants;
using Me.Kuerschner.AncientValidation.Extensions;
using Me.Kuerschner.AncientValidation.Models.Enums;
using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Me.Kuerschner.AncientValidation
{
    public static class RuleBuilderStringExtension
    {
        public  static RuleBuilder<TObject, string> NotEmpty<TObject>(this RuleBuilder<TObject, string> ruleBuilder) where TObject : class, new()
        {
            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return ruleBuilder.Value != string.Empty;
            }, ErrorKey.NotNull, false);
        }

        public static RuleBuilder<TObject, string> IsEquals<TObject>(this RuleBuilder<TObject, string> ruleBuilder, Expression<Func<TObject, string>> property) where TObject : class, new()
        {
            if (ruleBuilder == null && property != null) return ruleBuilder;

            var value = property.Compile().Invoke(ruleBuilder.ValidationObject);

            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return ruleBuilder.Value.Equals(value);
            }, ErrorKey.Equals, args: value);
        }

        public static RuleBuilder<TObject, string> EqualsIgnoreCase<TObject>(this RuleBuilder<TObject, string> ruleBuilder, string value) where TObject : class, new()
        {
            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return ruleBuilder.Value.EqualsIgnoreCase(value);
            }, ErrorKey.EqualsIgnoreCase, args: value);
        }

        public static RuleBuilder<TObject, string> IsEmail<TObject>(this RuleBuilder<TObject, string> ruleBuilder) where TObject : class, new()
        {
            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return Regex.Match(ruleBuilder.Value, PropertyConstants.EMAIL_REGEX).Success;
            }, ErrorKey.IsEmail);
        }

        public static RuleBuilder<TObject, string> IsPhoneNumber<TObject>(this RuleBuilder<TObject, string> ruleBuilder) where TObject : class, new()
        {
            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return Regex.Match(ruleBuilder.Value, PropertyConstants.PHONE_REGEX).Success;
            }, ErrorKey.IsPhoneNumber);
        }

        public static RuleBuilder<TObject, string> Match<TObject>(this RuleBuilder<TObject, string> ruleBuilder, string regex) where TObject : class, new()
        {
            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return Regex.Match(ruleBuilder.Value, regex).Success;
            }, ErrorKey.IsPhoneNumber);
        }
    }
}
