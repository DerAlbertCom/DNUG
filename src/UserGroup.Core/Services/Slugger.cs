using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserGroup.Services
{
    public class Slugger : ISlugger
    {
        readonly Dictionary<char, string> entites = new Dictionary<char, string>
                                                        {
                                                            {'ä', "ae"},
                                                            {'ü', "ue"},
                                                            {'ö', "oe"},
                                                            {'ß', "ss"},
                                                            {'/', "-"},
                                                            {' ', "-"},
                                                            {'\\', "-"}
                                                        };

        const string allowedChars = "abcdefghijklmnopqrstuvwxz0123456789-0";

        public string GenerateFrom(string text)
        {
            var slug = new StringBuilder();
            text = text.ToLower();
            foreach (var currentChar in text)
            {
                if (entites.ContainsKey(currentChar))
                {
                    slug.Append(entites[currentChar]);
                }
                else if (allowedChars.Any(allowChar => allowChar == currentChar))
                {
                    slug.Append(currentChar);
                }
            }
            return slug.ToString();
        }
    }
}