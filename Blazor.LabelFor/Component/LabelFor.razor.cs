using Microsoft.AspNetCore.Components;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace Blazor.LabelFor.Component
{
    public partial class LabelFor
    {
        private const string htmlClassAttribute = "class";

        [Parameter] public Expression<Func<string>> For { get; set; } = default!;
        [Parameter] public string? RequiredCharacter { get; set; } = default;
        [Parameter] public string? RequiredClass { get; set; } = default;
        [Parameter] public RenderFragment? ChildContent { get; set; } = default;
        [Parameter(CaptureUnmatchedValues = true)] public IDictionary<string, object>? AdditionalAttributes { get; set; } = default;

        private string DisplayName => GetDisplayName();
        private IDictionary<string, object>? HtmlAttributes => GetHtmlAttributes();

        private string GetDisplayName()
        {
            ArgumentNullException.ThrowIfNull(For);

            var memberExpression = (MemberExpression)For.Body;

            var displayName = GetDisplayNameFromAttribute(memberExpression);
            if (string.IsNullOrEmpty(RequiredCharacter) || !IsRequiredMember(memberExpression))
            {
                return displayName;
            }

            return GetDisplayNameWithRequiredCharacter(displayName, RequiredCharacter);
        }

        private string GetDisplayNameFromAttribute(MemberExpression memberExpression)
        {
            var displayNameAttribute = memberExpression.Member.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute;

            return displayNameAttribute?.DisplayName ?? memberExpression.Member.Name ?? string.Empty;
        }

        private string GetDisplayNameWithRequiredCharacter(string displayName, string requiredCharacter)
        {
            return string.Concat(displayName, requiredCharacter);
        }

        private IDictionary<string, object>? GetHtmlAttributes()
        {
            ArgumentNullException.ThrowIfNull(For);

            var memberExpression = (MemberExpression)For.Body;

            if (string.IsNullOrEmpty(RequiredClass) || !IsRequiredMember(memberExpression))
            {
                return AdditionalAttributes;
            }

            return GetHtmlAttributesWithRequiredClass(AdditionalAttributes, RequiredClass);
        }

        private IDictionary<string, object> GetHtmlAttributesWithRequiredClass(IDictionary<string, object>? aditionalAttributes, string requiredClass)
        {
            var htmlAttributesWithRequiredClass = new Dictionary<string, object>();

            if (aditionalAttributes is not null)
            {
                htmlAttributesWithRequiredClass = aditionalAttributes.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            }

            if (!htmlAttributesWithRequiredClass.TryAdd(htmlClassAttribute, requiredClass))
            {
                htmlAttributesWithRequiredClass[htmlClassAttribute] += string.Concat(" ", requiredClass);
            }

            return htmlAttributesWithRequiredClass;
        }

        private bool IsRequiredMember(MemberExpression memberExpression)
        {
            return memberExpression.Member.GetCustomAttribute<RequiredAttribute>() is not null;
        }
    }
}
