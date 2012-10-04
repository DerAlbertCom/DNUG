using System;
using System.ComponentModel.DataAnnotations;

namespace UserGroup.Web.Annotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ShortDateAttribute : UIHintAttribute
    {
        public ShortDateAttribute()
            : base("ShortDate")
        {
        }
    }
}