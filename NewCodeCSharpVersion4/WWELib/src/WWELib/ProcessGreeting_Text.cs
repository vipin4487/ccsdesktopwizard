namespace WWELib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ProcessGreeting_Text
    {
        public Dictionary<string, string> GetCallVariableDictionary(List<string> CallVar)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (string str in CallVar)
            {
                if (str > null)
                {
                    dictionary.Add(str, str);
                }
            }
            return dictionary;
        }

        public string ProcessGreetingText(Dictionary<string, string> omniKvps, string greetingText)
        {
            StringBuilder builder = new StringBuilder();
            int index = greetingText.IndexOf("<");
            if (index < 0)
            {
                return greetingText;
            }
            int startIndex = index;
            if (index > 0)
            {
                builder.Append(greetingText.Substring(0, index));
            }
            int num3 = greetingText.IndexOf(">", index);
            while (num3 > -1)
            {
                string str2 = greetingText.Substring(index + 1, (num3 - index) - 1);
                if (str2 == "crlf")
                {
                    builder.Append("\r\n");
                    index = num3 + 1;
                }
                else
                {
                    try
                    {
                        string localkey = str2.Replace("callvar,", "").Trim();
                        KeyValuePair<string, string> pair = (from kvp in omniKvps
                            where kvp.Key == localkey
                            select kvp).FirstOrDefault<KeyValuePair<string, string>>();
                        if (!string.IsNullOrEmpty(pair.Key) && !string.IsNullOrEmpty(pair.Value))
                        {
                            string str3 = pair.Value;
                            builder.Append(str3);
                            startIndex = num3 + 1;
                        }
                        else if (str2.IndexOf("<") == -1)
                        {
                            builder.Append("<");
                            builder.Append(str2);
                            builder.Append(">");
                            startIndex = num3 + 1;
                        }
                        else if (str2.StartsWith("input") && (str2.Contains("emailButton") && (str2.Contains("_Subject") || str2.Contains("_HTMLBodyText"))))
                        {
                            builder.Append("<");
                            startIndex++;
                            int num4 = greetingText.IndexOf("/>", startIndex);
                            if (num4 > startIndex)
                            {
                                builder.Append(greetingText.Substring(startIndex, num4 - startIndex));
                                startIndex += num4 - startIndex;
                            }
                        }
                        else
                        {
                            builder.Append("<");
                            startIndex++;
                        }
                    }
                    catch (Exception)
                    {
                        if (str2.IndexOf("<") == -1)
                        {
                            builder.Append("<");
                            builder.Append(str2);
                            builder.Append(">");
                            startIndex = num3 + 1;
                        }
                        else if (str2.StartsWith("input") && (str2.Contains("emailButton") && (str2.Contains("_Subject") || str2.Contains("_HTMLBodyText"))))
                        {
                            builder.Append("<");
                            startIndex++;
                            int num5 = greetingText.IndexOf("/>", startIndex);
                            if (num5 > startIndex)
                            {
                                builder.Append(greetingText.Substring(startIndex, num5 - startIndex));
                                startIndex += num5 - startIndex;
                            }
                        }
                        else
                        {
                            builder.Append("<");
                            startIndex++;
                        }
                    }
                }
                index = greetingText.IndexOf("<", startIndex);
                if (index > -1)
                {
                    if (index > startIndex)
                    {
                        builder.Append(greetingText.Substring(startIndex, index - startIndex));
                        startIndex = index;
                    }
                    num3 = greetingText.IndexOf(">", index);
                }
                else
                {
                    num3 = -1;
                }
            }
            if (startIndex < greetingText.Length)
            {
                builder.Append(greetingText.Substring(startIndex));
            }
            return builder.ToString();
        }
    }
}

