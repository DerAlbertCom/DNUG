using System;
using System.ComponentModel.DataAnnotations;

namespace UserGroup.Web.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class WikiAttribute : UIHintAttribute
    {
        public WikiAttribute() : base("Wiki")
        {
        }
    }
}