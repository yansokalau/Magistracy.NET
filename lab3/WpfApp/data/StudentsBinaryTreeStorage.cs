using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace WpfApp
{
    public class StudentsBinaryTreeStorage : IStorable<StudentData>
    {
        private const string FilePath = @"D:\.NET Labs\lab3\WpfApp\students.bin";

        private string filePath;

        private BinaryTree<StudentData> tree;

        public StudentsBinaryTreeStorage(string path = null)
        {
            if (path != null)
            {
                filePath = path;
            }
            else
            {
                filePath = FilePath;
            }

            ReadTree();
        } 

        public IEnumerable<StudentData> GetList()
        {
            return tree.ToList();
        }

        public void AddAndSaveItem(StudentData item)
        {
            tree.AddNode(item);
            SaveItem(item);
        }

        private void ReadTree()
        {
            tree = new BinaryTree<StudentData>();

            if (File.Exists(filePath))
            {
                using (var str = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    while (str.Length > str.Position)
                    {
                        var fs = new BinaryFormatter();
                        tree.AddNode((StudentData)fs.Deserialize(str));
                    }
                }
            }
        }

        private void SaveItem(StudentData data)
        {
            using (var fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fs, data);
            }
        }
    }
}
