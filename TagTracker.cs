using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTML_Tag_Tracker
{
    class Program
    {
        public static Stack<string> endTag = new Stack<string>();

        public static bool CheckEndTag(string currentTag, bool isEndOfLine)
        {
            if (isEndOfLine && endTag.Count() > 1)
            {
                string expected = endTag.ElementAt(endTag.Count() - 1);
                Console.WriteLine("Expected " + expected + " found #");
                return false;
            }
            else if (isEndOfLine && endTag.Count() == 1)
            {
                string expected = endTag.Pop();
                if (currentTag != expected)
                {
                    Console.WriteLine("Expected # found " + currentTag);
                    return false;
                }
            }
            else if (!isEndOfLine && endTag.Count() > 0)
            {
                string expected = endTag.Pop();
                if (currentTag != expected)
                {
                    Console.WriteLine("Expected " + expected + " found " + currentTag);
                    return false;
                }
            }
            else if (isEndOfLine && endTag.Count() == 0)
            {
                Console.WriteLine("Expected # found " + currentTag);
                return false;
            }
            else
            {
                endTag.Pop();
            }

            return true;
        }
        static void Main(string[] args)
        {
            bool isCorrectlyTagged = true;

            Console.WriteLine("Enter Number Of Input:: ");
            int noInput = int.Parse(Console.ReadLine());

            while (noInput > 0)
            {
                Console.WriteLine("Please Enter A Line:: ");
                string line = Console.ReadLine();

                string tag = "";
                for (int index = 0; index < line.Length; index++)
                {
                    if (line[index] == '<' && tag == "")
                    {
                        tag = line[index].ToString();
                    }
                    else if (line[index] == '/' && tag == "<")
                    {
                        tag = tag + line[index];
                    }
                    else if (Char.IsLetter(line[index]) && Char.IsUpper(line[index]) && (tag == "<" || tag == "</"))
                    {
                        tag = tag + line[index];
                    }
                    else if (line[index] == '>' && tag.Length >= 1 && tag[0] == '<' && Char.IsLetter(tag[1]))
                    {
                        tag = tag + line[index];
                        tag = tag.Insert(1, "/");
                        endTag.Push(tag);
                        tag = "";
                    }
                    else if (line[index] == '>' && tag.Length >= 2 && tag[0] == '<' && tag[1] == '/')
                    {
                        tag = tag + line[index];
                        isCorrectlyTagged = CheckEndTag(tag, (index == line.Length - 1));
                        tag = "";
                        if (!isCorrectlyTagged)
                        {
                            break;
                        }
                        continue;
                    }
                    else
                    {
                        tag = "";
                        continue;
                    }
                }

                if (isCorrectlyTagged)
                {
                    Console.WriteLine("Correctly Tagged Paragraph");
                }

                noInput--;
            }

            Console.Read();
        }
    }
}
