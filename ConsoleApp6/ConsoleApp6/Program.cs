using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp6
{

    // Level4 Part 2, Level5 and Level6

    class Level56
    {

        public List<string> Firstlist { get; set; }

        public void Read()
        {
            int counter = 0;
            string line;

            Firstlist = new List<string>();
            StreamReader file = new StreamReader(@"../../16S.fasta");

            while ((line = file.ReadLine()) != null)
            {
                Firstlist.Insert(counter, line);
                counter++;
            }

        }

    }

    class Level5 : Level56
    {
        public string Input { get; set; }
        public void Write()
        {
            List<string> names;
            base.Read();

            IEnumerable<string> things = Firstlist.Where(strings => strings.Contains(Input)).Select(strings => strings);
            var index = Firstlist.FindIndex(str => str.Contains(Input) == true);

            if (Firstlist.Skip(index - 1).First().IndexOf('>') != Firstlist.Skip(index - 1).First().LastIndexOf('>'))
            {
                names = Firstlist.Skip(index - 1).First().Split('>').Skip(1).ToList();
                foreach (string thing in names)
                {
                    Console.WriteLine(thing.Substring(0, 11));
                }
            }

            else if (Firstlist.Skip(index - 1).First().IndexOf('>') == Firstlist.Skip(index - 1).First().LastIndexOf('>'))
            {
                Console.WriteLine(Firstlist.Skip(index - 1).First().Substring(1, 12));
            }
            
        }
    }


    class Level6 : Level56
    {
        public string Input { get; set; }
        public void Write()
        {
            List<string> names;
            base.Read();

            IEnumerable<string> things = Firstlist.Where(strings => strings.Contains(Input)).Select(strings => strings);
            var index = Firstlist.FindIndex(str => str.Contains(Input) == true);
            foreach (string thing in things)
            {
                if (thing.IndexOf('>') != thing.LastIndexOf('>'))
                {
                    names = thing.Split('>').Skip(1).ToList();
                    foreach (string stuff in names)
                    {
                        Console.WriteLine(stuff.Substring(0, 11));
                    }
                }

                else if (thing.IndexOf('>') == thing.LastIndexOf('>'))
                {
                    names = thing.Split('>').Skip(1).ToList();
                    foreach (string stuff in names)
                    {
                        Console.WriteLine(stuff.Substring(0, 11));
                    }
                }

            }
        }
    }


    class Level4_2 : Level56
    {
        public List<string> C { get; set; }
        public List<string> B { get; set; }
        public List<string> A { get; set; }
        public new void Read()
        {
            int counter = 0;

            string line;
            string line2;
            string indexes;


            List<string> j;
            List<string> k;

            C = new List<string>();
            B = new List<string>();
            A = new List<string>();


            StreamReader file = new StreamReader(@"../../../../\ConsoleApp5\ConsoleApp5\bin\Debug\16S.index");
            StreamReader reader = new StreamReader(@"../../../../\ConsoleApp5\ConsoleApp5\16S.fasta");
            StreamReader index_file = new StreamReader(@"../../query.txt");


            while ((indexes = index_file.ReadLine()) != null)
            {
                j = indexes.Split('\n').ToList();

                foreach (string th in j)
                {

                    A.Add(th);
                }

            }
            while ((line2 = file.ReadLine()) != null)
            {
                k = line2.Split(' ').ToList();
                foreach (string thing in k)
                {
                    C.Add(thing);

                }

            }

            while ((line = reader.ReadLine()) != null)
            {
                B.Insert(counter, line + '\n' + reader.ReadLine());

                counter++;

            }

            index_file.Close();
            file.Close();
            reader.Close();

        }
    }

    class Level4 : Level4_2
    {

        public void Write()
        {
            List<string> names;

            List<string> e;
            FileStream fs = new FileStream(@"results.txt", FileMode.Create, FileAccess.Write);
            StreamWriter result = new StreamWriter(fs);
            base.Read();
            foreach (string index in A)
            {

                var indice = index;
                foreach (string sh in C)
                {


                    if (indice == sh)
                    {
                        var ind = C.FindIndex(str => str.Contains(indice) == true);
                        var s = C.Skip(ind - 1).First();
                        foreach (string fu in B)
                        {
                            e = fu.Split('\n').ToList();
                            foreach (string shi in e)
                            {

                                var ch = '>';
                                if (shi.IndexOf(ch) != shi.LastIndexOf(ch))
                                {
                                    names = shi.Split('>').Skip(1).ToList();
                                    var i = e.FindIndex(str => str.Contains(s) == true);

                                    foreach (string thing in names)
                                    {
                                        if (thing.Substring(0, 11) == s)
                                        {
                                            result.WriteLine(thing);
                                            result.WriteLine(e.Skip(i + 1).First());
                                        }




                                    }
                                }

                                else if (shi.IndexOf(ch) == shi.LastIndexOf(ch))
                                {
                                    var il = e.FindIndex(str => str.Contains(s) == true);

                                    if (shi.Substring(1, 11) == s)
                                    {
                                        result.WriteLine(shi);
                                        result.WriteLine(e.Skip(il + 1).First());
                                    }

                                }
                            }
                        }

                    }

                    //error message :

                    //else if (indice != sh)
                    //{
                    //    var indexer = a.FindIndex(str => str.Contains(indice) == true);
                    //    var sr = a.Skip(indexer).First();
                    //    Console.WriteLine("Error ! the id at {0} doesn't exists", sr);
                    //}
                }
            }


            result.Close();

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            args = Console.ReadLine().Split();
            var a = args[0];
            if (String.Compare(a, "Search16s", true) == 0)
            {
                var b = args[1];
                if (String.Compare(b, "-level1", true) == 0)
                {
                    var c = args[2];
                    if (String.Compare(c, "16S.fasta", true) == 0)
                    {
                        var d = args[3];
                        int integer_d;
                        int.TryParse(d, out integer_d);
                        if (integer_d != 0 && integer_d > 0)
                        {
                            var e = args[4];
                            int integer_e;
                            int.TryParse(e, out integer_e);
                            if (integer_e != 0 && integer_e > 0)
                            {
                                int counter = 0; // line counter in text file
                                string line; // line of text
                                int position = 0; // file position of first line
                                List<int> pos = new List<int>(); // an array to keep ine positions in
                                List<int> size = new List<int>(); // an array to keep ine size in

                                // Read the file  
                                StreamReader file =
                                    new StreamReader(@"../../16S.fasta");
                                while ((line = file.ReadLine()) != null)
                                {
                                    pos.Insert(counter, position); // store line position
                                    size.Insert(counter, line.Length + 1); // store line size
                                    counter++;
                                    position = position + line.Length + 1; // add 1 for '\n' character in file
                                }
                                file.Close();

                                // now use the parallel arrays index to access a line directly 
                                using (FileStream fs = new FileStream(@"../../16S.fasta", FileMode.Open, FileAccess.Read))
                                {
                                    // the "using" construct ensures that the FileStream is properly closed/disposed   
                                    //int num = (Console.ReadLine());

                                    for (int n = integer_d - 1; n < integer_d - 1 + integer_e * 2; n++)
                                    {
                                        //display lines starting at the typed line and nth sequence in the file               
                                        byte[] bytes = new byte[size[n]];
                                        fs.Seek(pos[n], SeekOrigin.Begin);// seek to line n (note: there is no actual disk access yet)
                                        fs.Read(bytes, 0, size[n]); // get the data off disk - now there is disk access
                                                                    //System.Console.WriteLine("Line[{n}] : position {n}, size {n}", n, pos[n], size[n]);
                                        Console.WriteLine(Encoding.Default.GetString(bytes)); // display the line
                                    }
                                }

                                
                            }

                        }
                        else if (d != null)
                        {
                            int counter = 0;
                            string line;
                            List<string> firstlist = new List<string>();
                            StreamReader file = new StreamReader(@"../../16S.fasta");

                            while ((line = file.ReadLine()) != null)
                            {
                                firstlist.Insert(counter, line);
                                counter++;
                            }
                            //var n = Console.ReadLine();

                            IEnumerable<string> things = firstlist.Where(strings => strings.Contains(d)).Select(strings => strings);
                            var index = firstlist.FindIndex(str => str.Contains(d) == true);
                            foreach (string thing in things)
                            {
                                if (index >= 0)
                                {
                                    Console.WriteLine(thing);
                                    Console.WriteLine(firstlist.Skip(index + 1).First());
                                }
                            }
                        }





                        //else
                        //{
                        //    Console.WriteLine("Enter proper non-negative non-zero number");
                        //}

                        
                        else
                        {
                            Console.WriteLine("Enter proper non-negative non-zero number");
                        }

                    }

                    

                    else
                    {
                        Console.WriteLine("Enter proper file name");
                    }

                }

                else if (String.Compare(b, "-level4", true) == 0)
                {
                    var c = args[2];
                    if (String.Compare(c, "16S.fasta", true) == 0)
                    {
                        var d = args[3];
                        if (String.Compare(d, "16S.index", true) == 0)
                        {
                            var e = args[4];
                            if (String.Compare(e, "query.txt", true) == 0)
                            {
                                var f = args[5];
                                if (String.Compare(f, "results.txt", true) == 0) // create results.txt file at - \ConsoleApp6\ConsoleApp6\bin\Debug
                                {
                                    Level4 con1 = new Level4();
                                    con1.Write();
                                }
                                else
                                {
                                    Console.WriteLine("Enter proper results file name");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Enter proper query file name");
                            }
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

                else if (String.Compare(b, "-level5", true) == 0)
                {
                    var c = args[2];
                    if (String.Compare(c, "16S.fasta", true) == 0)
                    {
                        var d = args[3];
                        Level5 con2 = new Level5();
                        con2.Input = d;
                        con2.Write();
                    }
                    else
                    {
                        Console.WriteLine("Enter proper fasta file name");
                    }

                }

                else if (String.Compare(b, "-level6", true) == 0)
                {
                    var c = args[2];
                    if (String.Compare(c, "16S.fasta", true) == 0)
                    {
                        var d = args[3];
                        Level6 con3 = new Level6();
                        con3.Input = d;
                        con3.Write();
                    }
                    else
                    {
                        Console.WriteLine("Enter proper fasta file name");
                    }
                }

                else
                {
                    Console.WriteLine("Enter proper level name");
                }
                
            }
            else
            {
                Console.WriteLine("Enter proper program name");
            }

            Console.ReadLine();
        }
    }
}