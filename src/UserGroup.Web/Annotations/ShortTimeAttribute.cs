using System;
using System.ComponentModel.DataAnnotations;

namespace UserGroup.Web.Annotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ShortTimeAttribute : UIHintAttribute
    {
        public ShortTimeAttribute()
            : base("ShortTime")
        {
        }
    }
}