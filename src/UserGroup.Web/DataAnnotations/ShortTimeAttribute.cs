using System;
using System.ComponentModel.DataAnnotations;

namespace UserGroup.Web.DataAnnotations
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