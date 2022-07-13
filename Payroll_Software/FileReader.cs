using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Software
{
    class FileReader
    {
        public List<Staff> ReadFile()
        {       
            List<Staff> mystaffs = new List<Staff>();
            string[] result = new string[2];
            string path = "staff.txt";
            string[] separator = { " , " };
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        result = sr.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
                        if (result[1] == "Manager")
                            mystaffs.Add(new Manager(result[0]));
                        else if (result[1] == "Admin")
                            mystaffs.Add(new Admin(result[0]));
                    }
                    sr.Close();
                }
            }
            else
                Console.WriteLine("Error : File does not exists!");
            return mystaffs;
        }
    }
}
