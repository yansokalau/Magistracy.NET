using BinaryTreeCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace BinaryTreeUnitTests
{
    [TestClass]
    public class UnitTests
    {   

        [TestMethod]
        public void IntTest()
        {
            var intTree = new BinaryTree<int>();
            intTree.AddNode(8);
            intTree.AddNode(6);
            intTree.AddNode(10);
            intTree.AddNode(4);
            intTree.AddNode(7);
            intTree.AddNode(8);
            intTree.AddNode(7);
            intTree.AddNode(11);
            intTree.AddNode(9);

            Assert.IsTrue(IsOrderCorrect(intTree.Postorder(), new[] {4, 7, 8, 7, 6, 9, 11, 10, 8}));

            Assert.IsTrue(IsOrderCorrect(intTree.Preorder(), new[] { 8, 6, 4, 7, 7, 8, 10, 9, 11 }));

            Assert.IsTrue(IsOrderCorrect(intTree.Inorder(), new[] { 4, 6, 7, 7, 8, 8, 9, 10, 11 }));
        }

        [TestMethod]
        public void StringTest()
        {
            var stringTree = new BinaryTree<string>();
            stringTree.AddNode("dog");
            stringTree.AddNode("cat");
            stringTree.AddNode("pig");
            stringTree.AddNode("cow");
            stringTree.AddNode("crab");
            stringTree.AddNode("fish");
            stringTree.AddNode("duck");
            stringTree.AddNode("frog");
            stringTree.AddNode("fly");
            
            Assert.IsTrue(IsOrderCorrect<string>(stringTree.Postorder(), new string[] { "crab", "cow", "cat", "duck", "fly", "frog", "fish", "pig", "dog" }));

            Assert.IsTrue(IsOrderCorrect<string>(stringTree.Preorder(), new string[] { "dog", "cat", "cow", "crab", "pig", "fish", "duck", "frog", "fly" }));

            Assert.IsTrue(IsOrderCorrect<string>(stringTree.Inorder(), new string[] { "cat", "cow", "crab", "dog", "duck", "fish", "fly", "frog", "pig" }));
        }

        [TestMethod]
        public void PointPreorderTest()
        {
            var comparer = new PointComparator();
            var pointTree = new BinaryTree<Point>();
            pointTree.customComparer = comparer;

            var point1 = new Point(8, 2);
            var point2 = new Point(6, 3);
            var point3 = new Point(4, 1);
            var point4 = new Point(7, 0);
            var point5 = new Point(10, 5);
            var point6 = new Point(9, 3);
            var point7 = new Point(11, 2);

            pointTree.AddNode(point1);
            pointTree.AddNode(point2);
            pointTree.AddNode(point3);
            pointTree.AddNode(point4);
            pointTree.AddNode(point5);
            pointTree.AddNode(point6);
            pointTree.AddNode(point7);

            Assert.IsTrue(IsOrderCorrect(pointTree.Postorder(), new[] { point1, point2, point3, point4, point5, point6, point7 }, comparer));
        }

        [TestMethod]
        public void StudentTest()
        {
            var studentTree = new BinaryTree<Student>();
            Student st1 = new Student() { firstName = "Student1", lastName = "Student1", courseName = ".NET", mark = 7 };
            Student st2 = new Student() { firstName = "Student2", lastName = "Student2", courseName = ".NET", mark = 5 };
            Student st3 = new Student() { firstName = "Student3", lastName = "Student3", courseName = ".NET", mark = 4 };
            Student st4 = new Student() { firstName = "Student4", lastName = "Student4", courseName = ".NET", mark = 6 };
            Student st5 = new Student() { firstName = "Student5", lastName = "Student5", courseName = ".NET", mark = 9 };
            Student st6 = new Student() { firstName = "Student6", lastName = "Student6", courseName = ".NET", mark = 8 };
            Student st7 = new Student() { firstName = "Student7", lastName = "Student7", courseName = ".NET", mark = 10 };

            studentTree.AddNode(st1);
            studentTree.AddNode(st2);
            studentTree.AddNode(st3);
            studentTree.AddNode(st4);
            studentTree.AddNode(st5);
            studentTree.AddNode(st6);
            studentTree.AddNode(st7);

            Assert.IsTrue(IsOrderCorrect(studentTree.Postorder(), new[] { st3, st4, st2, st6, st7, st5, st1 }));

            Assert.IsTrue(IsOrderCorrect(studentTree.Preorder(), new[] { st1, st2, st3, st4, st5, st6, st7 }));

            Assert.IsTrue(IsOrderCorrect(studentTree.Inorder(), new[] { st3, st2, st4, st1, st6, st5, st7 }));
        }

        private bool IsOrderCorrect<T>(IEnumerable<T> treeCollection, T[] correctOrder, IComparer<T> comparer = null)
        {
            int i = 0;
            foreach (T data in treeCollection)
            {
                if (comparer != null)
                {
                    if (comparer.Compare(correctOrder[i], data) != 0)
                    {
                        return false;
                    }
                }
                else
                {
                    if (!correctOrder[i].Equals(data))
                    {
                        return false;
                    }
                }

                i++;
            }

            return true;
        }
    }
}