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
                if (str != null)
                {
                    dictionary.Add(str, str);
                }
            }
            return dictionary;
        }

        public string ProcessGreetingText(Dictionary<string, string> omniKvps, string greetingText)
        {
            int num2;
            int num3;
            StringBuilder builder = new StringBuilder();
            int index = greetingText.IndexOf("<");
            if (index >= 0)
            {
                num2 = index;
                if (index > 0)
                {
                    builder.Append(greetingText.Substring(0, index));
                }
                num3 = greetingText.IndexOf(">", index);
            }
            else
            {
                return greetingText;
            }
            while (true)
            {
                while (true)
                {
                    if (num3 > -1)
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
                                    builder.Append(pair.Value);
                                    num2 = num3 + 1;
                                }
                                else if (str2.IndexOf("<") == -1)
                                {
                                    builder.Append("<");
                                    builder.Append(str2);
                                    builder.Append(">");
                                    num2 = num3 + 1;
                                }
                                else if (!(str2.StartsWith("input") && (str2.Contains("emailButton") && (str2.Contains("_Subject") || str2.Contains("_HTMLBodyText")))))
                                {
                                    builder.Append("<");
                                    num2++;
                                }
                                else
                                {
                                    builder.Append("<");
                                    num2++;
                                    int num4 = greetingText.IndexOf("/>", num2);
                                    if (num4 > num2)
                                    {
                                        builder.Append(greetingText.Substring(num2, num4 - num2));
                                        num2 += num4 - num2;
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                if (str2.IndexOf("<") == -1)
                                {
                                    builder.Append("<");
                                    builder.Append(str2);
                                    builder.Append(">");
                                    num2 = num3 + 1;
                                }
                                else if (!(str2.StartsWith("input") && (str2.Contains("emailButton") && (str2.Contains("_Subject") || str2.Contains("_HTMLBodyText")))))
                                {
                                    builder.Append("<");
                                    num2++;
                                }
                                else
                                {
                                    builder.Append("<");
                                    num2++;
                                    int num5 = greetingText.IndexOf("/>", num2);
                                    if (num5 > num2)
                                    {
                                        builder.Append(greetingText.Substring(num2, num5 - num2));
                                        num2 += num5 - num2;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (num2 < greetingText.Length)
                        {
                            builder.Append(greetingText.Substring(num2));
                        }
                        return builder.ToString();
                    }
                    break;
                }
                index = greetingText.IndexOf("<", num2);
                if (index <= -1)
                {
                    num3 = -1;
                }
                else
                {
                    if (index > num2)
                    {
                        builder.Append(greetingText.Substring(num2, index - num2));
                        num2 = index;
                    }
                    num3 = greetingText.IndexOf(">", index);
                }
            }
        }
    }
}

