using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp5
{
    class Program1
    {
        public List<string> Firstlist { get; set; }
        public List<int> Pos { get; set; }
        public int Counter { get; set; }
        public void Read()
        {
            // Part 1 Level 4
            Counter = 0;
            string line;
            int position = 0;

            Firstlist = new List<string>();
            Pos = new List<int>();
            
            StreamReader file = new StreamReader(@"../../16S.fasta");
            List<string> names;

            while ((line = file.ReadLine()) != null)
            {
                var ch = '>';
                if (line.IndexOf(ch) != line.LastIndexOf(ch))
                {
                    names = line.Split('>').Skip(1).ToList();
                    foreach (string thing in names)
                    {
                        Pos.Insert(Counter, position);
                        Firstlist.Insert(Counter, thing.Substring(0, 11));
                        Counter++;
                        position = position + thing.Length + 1;
                    }
                }

                else if (line.IndexOf(ch) == line.LastIndexOf(ch))
                {
                    names = line.Split('>').Skip(1).ToList();
                    foreach (string stuff in names)
                    {
                        Pos.Insert(Counter, position);
                        Firstlist.Insert(Counter, stuff.Substring(0, 11));
                        Counter++;
                        position = position + line.Length + 1;
                    }
                }

                else
                {
                    Pos.Insert(Counter, position);
                    position = position + line.Length + 1;
                }
            }
            file.Close();
        }
    }
    class Program2 : Program1
    {
        public void Write()
        {
            
            FileStream fs = new FileStream(@"16S.index", FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs);
            base.Read();
            for (int i = 0; i < Counter; i++)
            {
                writer.WriteLine("{0} {1}", Firstlist[i], Pos[i]);
                //Console.WriteLine("{0} {1}",  firstlist[i], pos[i]);
            }

            
            writer.Close();
            fs.Close();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            args = Console.ReadLine().Split();
            var a = args[0];
            if (String.Compare(a, "IndexSequence16s", true) == 0)
            {
                var b = args[1];
                if (String.Compare(b, "16S.fasta", true) == 0)
                {
                    var c = args[2];
                    if (String.Compare(c, "16S.index", true) == 0)
                    {
                        Program2 con2 = new Program2();
                        con2.Write();
                    }

                    else
                    {
                        Console.WriteLine("Enter proper index file name");
                    }

                }

                else
                {
                    Console.WriteLine("Enter proper fasta file name");
                }

            }
            else
            {
                Console.WriteLine("Enter proper index sequence name");
            }

            Console.ReadLine();
        }
    }

            
        
    
}

