using System;
using System.ComponentModel.DataAnnotations;

namespace UserGroup.Web.Annotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class WikiAttribute : UIHintAttribute
    {
        public WikiAttribute() : base("Wiki")
        {
        }
    }
}