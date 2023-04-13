using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.Core
{
    public static class Sort
    {
        //QuickSort==========================================================
        //метод обмена элементами массива
        private static void Swap(ref char x, ref char y)
        {
            var t = x;
            x = y;
            y = t;
        }
        //метод возвращает индекс ссылочного элемента
        private static int Partition(char[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }
            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }
        private static char[] QuickSort(char[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }
            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);
            return array;
        }
        public static string QuickSort(string array)
        {
            char[] mass = array.ToCharArray();
            return new string(QuickSort(mass, 0, mass.Length - 1));
        }
        //TreeSort===========================================================
        public static char[] TreeSort(string array)
        {
            var treeNode = new TreeNode(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                treeNode.Insert(new TreeNode(array[i]));
            }

            return treeNode.Transform();
        }
    }
    public class TreeNode
    {
        public TreeNode(char data)
        {
            Data = data;
        }
        //данные
        public char Data { get; set; }
        //левая ветка дерева
        public TreeNode Left { get; set; }
        //правая ветка дерева
        public TreeNode Right { get; set; }
        //рекурсивное добавление узла в дерево
        public void Insert(TreeNode node)
        {
            if (node.Data < Data)
            {
                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Insert(node);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Insert(node);
                }
            }
        }
        //преобразование дерева в отсортированный массив
        public char[] Transform(List<char> elements = null)
        {
            if (elements == null)
            {
                elements = new List<char>();
            }
            if (Left != null)
            {
                Left.Transform(elements);
            }
            elements.Add(Data);
            if (Right != null)
            {
                Right.Transform(elements);
            }
            return elements.ToArray();
        }
    }
    //===================================================================
}